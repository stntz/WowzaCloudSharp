using System;
using Newtonsoft.Json;

namespace WowzaSDK.Models.Interfaces
{
    public interface IHaveID
    {
        [JsonProperty("id")]
        string ID { get; set; }
    }
}
