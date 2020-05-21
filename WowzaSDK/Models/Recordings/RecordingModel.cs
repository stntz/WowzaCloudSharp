using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WowzaSDK.Models.Recordings
{
    public class RecordingModel : BaseModel
    {
        [JsonProperty("created_at")]
        public DateTime CreeatedAt { get; set; }

        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("transcoder_id")]
        public string TranscoderID { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }


    internal class RecordingStateModel : BaseModel
    {
        [JsonProperty("recording")]
        public InnerStateModel Recording { get; set; }
    }

    public class InnerStateModel
    {
        [JsonProperty("state")]
        public string State { get; set; }
    }

    internal class RecordingReadModel : BaseModel
    {
        [JsonProperty("recording")]
        public RecordingResponseModel Recording { get; set; }
    }

    internal class RecordingListModel : BaseModel
    {
        [JsonProperty("recordings")]
        public List<RecordingModel> Recordings { get; set; }
    }
}
