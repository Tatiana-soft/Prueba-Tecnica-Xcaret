using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Infrastructure.ApiResult
{
    public class ErrorResponse
    {
        public string Code { get; set; }
        public string[] Messages { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object DeveloperMessage { get; set; }
        public ErrorResponse(string code, string message)
        {
            string[] messages = { message };
            Code = code;
            Messages = messages;
        }
        public ErrorResponse(string code, string[] messages)
        {
            Code = code;
            Messages = messages;
        }
    }
}
