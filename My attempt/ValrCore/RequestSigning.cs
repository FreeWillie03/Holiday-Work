using System;
using System.Text;
using System.Security.Cryptography;

public static 
string signRequest(string apiKeySecret, string timestamp, string verb, string path, string body = "")
{
    var payload = timestamp + verb.ToUpper() + path + body;
    byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);

    using (HMACSHA512 hmac = new HMACSHA512(Encoding.UTF8.GetBytes(apiKeySecret))) 
    {
        byte[] hash = hmac.ComputeHash(payloadBytes);
        return toHexString(hash);
    }
}

private static 
string toHexString(byte[] hash)
{
    StringBuilder result = new StringBuilder(hash.Length * 2);
    foreach(var b in hash)
    {
        result.Append(b.ToString("x2"));
    }
    return result.ToString();
}

/* Timestamp in milliseconds. 
 * The same timestamp should be used to generate request signature
 * as well as sent along in the X-VALR-TIMESTAMP header of the request
 */
private static 
string getTimestamp()
{
    return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
}
