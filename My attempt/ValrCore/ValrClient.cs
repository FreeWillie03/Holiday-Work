using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ValrCore {
    public partial class ValrClient : IDisposable{
        internal static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings 
        {
            ContractResolver = new DefaultContractResolver {NamingStrategy = new SnakeCaseStrategy() }
        };

        private static readonly CultureInfo Culture = CultureInfo.InvariantCulture;

        private static readonly Dictionary<string, string> EmptyDictionary = new Dictionary<string,string>(0);

         private const int AdditionalPrivateQueryArgs = 2;

        private readonly HttpClient _httpClient = new HttpClient();

        private readonly HMACSHA512 _sha512PrivateKey;
        private readonly SHA256 _sha256 = SHA256.Create();

        public ValrClient(string apikey, string privateKey){
            ApiKey = apikey ?? "";
            PrivateKey = privateKey ?? "";

            _httpClient.BaseAddress = new Uri("https://api.valr.com"); // Check uri
            _sha512PrivateKey = new HMACSHA512(Convert.FromBase64String(PrivateKey));
        }

        public string ApiKey {get;}
        public string PrivateKey {get;}

        public Uri BaseAddress{
            get => _httpClient.BaseAddress;
            set => _httpClient.BaseAddress = value;
        }

        public httpRequestHeaders DefaultHeaders => _httpClient.DefaultRequestHeaders;

        public bool ErrorAsExceptions {get; set;} = true;

        public bool WarningsAsExceptions {get; set;}

        public Func<Task<long>> GetNonce {get; set;} = () => Task.FromResult(DateTime.UtcNow.Ticks);

        public Func<Task<string>> GetTwoFactorPassword {get; set;}

        public Func<ValrRequestContext, Task> InterceptRequest {get; set;}
        public Func<ValrResponseContext, Task> InterceptResponse {get; set;}

        public async Task<ValrResponse<T>> QueryPublic<T>(string requestUrl, Dictionary<string,string>args = null, int apiCallCost = 1){
            if(requestUrl == null) throw new ArgumentNullException(nameof(requestUrl));

            args = args ?? EmptyDictionary;

            //Setup request.
            string urlEncodedArgs = UrlEncode(args);
            var req = new httpRequestMessage(HttpMethod.Post, requestUrl){
                Content = new StringContent(urlEncodedArgs, Encoding.UTF8, "application/x-www-form-urlencoded")
            };
             req.Headers.Add("API-Key", ApiKey);

            // Add content signature header.
            byte[] urlBytes = Encoding.UTF8.GetBytes(requestUrl);
            byte[] dataBytes = _sha256.ComputeHash(Encoding.UTF8.GetBytes(nonce + urlEncodedArgs));

            var buffer = new byte[urlBytes.Length + dataBytes.Length];
            Buffer.BlockCopy(urlBytes, 0, buffer, 0, urlBytes.Length);
            Buffer.BlockCopy(dataBytes, 0, buffer, urlBytes.Length, dataBytes.Length);
            byte[] signature = _sha512PrivateKey.ComputeHash(buffer);

            req.Headers.Add("API-Sign", Convert.ToBase64String(signature));

            // Send request and deserialize response.
            return await SendRequest<T>(req, apiCallCost).ConfigureAwait(false);
        } 

           public void Dispose() => _httpClient.Dispose();

             private async Task<ValrResponse<T>> SendRequest<T>(HttpRequestMessage req, int cost)
        {
            var reqCtx = new ValrRequestContext
            {
                HttpRequest = req,
                ApiCallCost = cost
            };

            // Allow interception of request by the consumer of this client.
            if (InterceptRequest != null)
            {
                await InterceptRequest(reqCtx).ConfigureAwait(false);
            }

            // Perform the HTTP request.
            HttpResponseMessage res = await _httpClient.SendAsync(reqCtx.HttpRequest).ConfigureAwait(false);

            var resCtx = new ValrResponseContext
            {
                HttpResponse = res
            };

            // Throw for HTTP-level error.
            resCtx.HttpResponse.EnsureSuccessStatusCode();

            // Allow interception of response by the consumer of this client.
            if (InterceptResponse != null)
            {
                await InterceptResponse(resCtx).ConfigureAwait(false);
            }

            // Deserialize response.
            string jsonContent = await resCtx.HttpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<ValrResponse<T>>(jsonContent, JsonSettings);
            result.RawJson = jsonContent;

            // Throw for API-level error and warning if configured.
            if (result.Errors.Any(x =>
                ErrorsAsExceptions && x.SeverityCode == ErrorString.SeverityCodeError ||
                WarningsAsExceptions && x.SeverityCode == ErrorString.SeverityCodeWarning))
            {
                throw new ValrException(result.Errors, "There was a problem with a response from Valr.");
            }

            return result;
        }

        private static string UrlEncode(Dictionary<string, string> args) => string.Join(
            "&",
            args.Where(x => x.Value != null).Select(x => x.Key + "=" + WebUtility.UrlEncode(x.Value))
        );

    }
}