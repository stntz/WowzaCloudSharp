using System;
using Newtonsoft.Json;

namespace WowzaSDK.Models.Recordings
{
    public class RecordingResponseModel : RecordingModel
    {
        [JsonProperty("download_url")]
        public string DownloadURL { get; set; }
        [JsonProperty("duration")]
        public long Duration { get; set; }
        [JsonProperty("file_name")]
        public string FileName { get; set; }
        [JsonProperty("file_size")]
        public long FileSize { get; set; }
        [JsonProperty("starts_at")]
        public string StartsAt { get; set; }
        [JsonProperty("transcoder_name")]
        public string TranscoderName { get; set; }
        [JsonProperty("transcoding_uptime_id")]
        public DateTime TranscodingUptimeID { get; set; }
    }
}