using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WowzaSDK.Models.ErrorHandler
{
    public class WowzaError
    {
        [JsonProperty("meta")]
        public ErrorMeta Meta { get; set; }

        public override string ToString()
        {
            return $"Wowza Meta Error: {Meta.Status} \\n {Meta.Title} \\n {Meta.Code} \\n {Meta.Message} \\n {Meta.Description}";
        }
    }

    public class ErrorMeta
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("links")]
        public List<object> Links { get; set; }
    }
}