const string INPUT_DATA = "";

const string CN_FAST_HASH= "";

const string CN_SLOW_HASH_V0= "";
const string CN_SLOW_HASH_V1= "";
const string CN_SLOW_HASH_V2= "";

const string CN_LITE_SLOW_HASH_V0 = "";
const string CN_LITE_SLOW_HASH_V1 = "";
const string CN_LITE_SLOW_HASH_V2 = "";

const string CN_DARK_SLOW_HASH_V0 = "";
const string CN_DARK_SLOW_HASH_V1 = "";
const string CN_DARK_SLOW_HASH_V2 = "";

const string CN_DARK_LITE_SLOW_HASH_V0 ="";
const string CN_DARK_LITE_SLOW_HASH_V1 ="";
const string CN_DARK_LITE_SLOW_HASH_V2 ="";

const string CN_TURTLE_SLOW_HASH_V0 = "";
const string CN_TURTLE_SLOW_HASH_V1 = "";
const string CN_TURTLE_SLOW_HASH_V2 = "";

const string CN_TURTLE_LITE_SLOW_HASH_V0 = "";
const string CN_TURTLE_LITE_SLOW_HASH_V1 = "";
const string CN_TURTLE_LITE_SLOW_HASH_V2 = "";

const string CHUKWA = "";

const string CN_SOFT_SHELL_V0[] = {"",""};

const string CN_SOFT_SHELL_V1[] = {"",""};

const string CN_SOFT_SHELL_V2[] = {"",""};

/*Returns true when hashs are the same*/
static bool CompareHashes(string left, string right){
    return (left == right);
}

/*Checks if testing v1 or v2
Posible use of a substring if .find doesn't work*/
bool need43BytesOfData(string hashFunctionName){
 return (hashFunctionName.find("v1")!= npos || hashFunctionName.find("v2") != npos)
}

/*Returns the name of the function called ------- Redo*/
string TEST_HASH_FUNCTION (hashFunction, expectedOutput){

}

/*Redo*/
string TEST_HASH_FUNCTION_WITH_HEIGHT()
