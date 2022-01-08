using Microsoft.AspNetCore.Mvc;

namespace Api.Presenters
{
    /// <summary>
    /// 
    /// </summary>
    public class JsonContentResult : ContentResult
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}