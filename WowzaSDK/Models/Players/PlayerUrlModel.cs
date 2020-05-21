using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WowzaSDK.Models.Players
{
    public class PlayerUrlModel : BaseModel
    {
        [JsonProperty("bitrate")]
        public int Bitrate { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }        
    }

    public class PlayerUrlResponseModel: PlayerUrlModel
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("id")]
        public string ID { get; private set; }
        [JsonProperty("player_id")]
        public string PlayerID { get; private set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    internal class UrlDataModel: BaseModel
    {
        [JsonProperty("url")]
        public PlayerUrlModel Url { get; set; }
    }

    internal class PlayerUrlListModel: BaseModel
    {
        [JsonProperty("urls")]
        public List<PlayerUrlResponseModel> PlayerUrls { get; set; }
    }

    internal class PlayerUrlReadModel: BaseModel
    {
        [JsonProperty("url")]
        public PlayerUrlResponseModel Url { get; set; }
    }

    internal class PlayerUrlCreateModel : BaseModel
    {
        [JsonProperty("url")]
        public PlayerUrlModel Url { get; set; }
    }
}