using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Api.Serialization
{
    /// <summary>
    /// 
    /// </summary>
    public class JsonSerializer
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ContractResolver = new JsonContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string SerializeObject(object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.Indented, settings);
        }
        /// <summary>
        /// 
        /// </summary>
        public sealed class JsonContractResolver : CamelCasePropertyNamesContractResolver {}
    }
}