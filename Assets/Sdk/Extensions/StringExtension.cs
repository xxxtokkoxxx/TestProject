namespace Sdk.Extensions
{
    public static class StringExtension 
    {
        public static string GetModifiedJson(this string json, string jsonObject)
        {
            var modifiedJson = "{" + $"\"{jsonObject}\":" + json + "}";
            return modifiedJson;
        }
    }
}
