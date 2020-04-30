using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WowzaSDK.Models.Interfaces;

namespace WowzaSDK.Models
{
    internal class LiveStreamCreateModel : BaseModel
    {
        [JsonProperty("live_stream")]
        public LiveStreamRequestModel LiveStream { get; set; }
    }

    internal class LiveStreamReadModel : BaseModel
    {
        [JsonProperty("live_stream")]
        public LiveStreamResponseModel LiveStream { get; set; }
    }

    internal class LiveStreamListModel : BaseModel
    {
        [JsonProperty("live_streams")]
        public List<LiveStreamResponseModel> LiveStreams { get; set; }
    }

    internal class LiveStreamStateModel : BaseModel
    {
        [JsonProperty("live_stream")]
        public InnerStateModel LiveStream { get; set; }        
    }

    public class InnerStateModel
    {
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("connection_code")]
        public string ConnectionCode { get; set; }

        [JsonProperty("thumbnail_url")]
        public string ThumbnailURL { get; set; }

        [JsonProperty("ip_address")]
        public string IPAddress { get; set; }
    }

    internal class LiveStreamMetricModel : BaseModel
    {
        [JsonProperty("live_stream")]
        public InnerMetricModel LiveStream { get; set; }        
    }

    public class InnerMetricModel
    {
        [JsonProperty("audio_codec")]
        public StatusValue AudioCodec { get; set; }

        [JsonProperty("bits_in_rate")]
        public StatusValue BitsInRate { get; set; }

        [JsonProperty("bits_out_rate")]
        public StatusValue BitsOutRate { get; set; }

        [JsonProperty("bytes_in_rate")]
        public StatusValue BytesInRate { get; set; }

        [JsonProperty("bytes_out_rate")]
        public StatusValue BytesOutRate { get; set; }

        [JsonProperty("configured_bytes_out_rate")]
        public StatusValue ConfiguresBytesOutRate { get; set; }

        [JsonProperty("connected")]
        public StatusValue Connected { get; set; }

        [JsonProperty("frame_size")]
        public StatusValue FrameSize { get; set; }

        [JsonProperty("frame_rate")]
        public StatusValue FrameRate { get; set; }

        [JsonProperty("height")]
        public StatusValue Height { get; set; }

        [JsonProperty("keyframe_interval")]
        public StatusValue KeyframeInterval { get; set; }

        [JsonProperty("stream_target_status_OUTPUTIDX_STREAMTARGETIDX")]
        public StatusValue StreamTargetStatus { get; set; }

        [JsonProperty("unique_views")]
        public StatusValue UniqueViews { get; set; }

        [JsonProperty("video_codec")]
        public StatusValue VideoCodec { get; set; }

        [JsonProperty("width")]
        public StatusValue Width { get; set; }
        
    }

    public class StatusValue
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class LiveStreamModel : BaseModel
    {
        [JsonProperty("aspect_ratio_height")]
        public int AspectRatioHeight { get; set; }

        [JsonProperty("aspect_ratio_width")]
        public int AspectRatioWidth { get; set; }

        [JsonProperty("billing_mode")]
        public string BillingMode { get; set; }

        [JsonProperty("broadcast_location")]
        public string BroadcastLocation { get; set; }

        [JsonProperty("encoder")]
        public string Encoder { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("transcoder_type")]
        public string TranscoderType { get; set; }

        [JsonProperty("closed_caption_type")]
        public string ClosedCaptionType { get; set; }

        [JsonProperty("delivery_method")]
        public string DeliveryMethod { get; set; }

        [JsonProperty("delivery_protocols")]
        public List<string> DeliveryProtocols { get; set; }

        [JsonProperty("delivery_type")]
        public string DeliveryType { get; set; }        

        [JsonProperty("hosted_page")]
        public bool HostedPage { get; set; }

        [JsonProperty("hosted_page_description")]
        public string HostedPageDescription { get; set; }        

        [JsonProperty("hosted_page_sharing_icons")]
        public bool HostedPageSharingIcons { get; set; }

        [JsonProperty("hosted_page_title")]
        public string HostedPageTitle { get; set; }

        [JsonProperty("low_latency")]
        public bool LowLatency { get; set; }       

        [JsonProperty("player_countdown")]
        public bool PlayerCountdown { get; set; }

        [JsonProperty("player_countdown_at")]
        public DateTime PlayerCountdownAt { get; set; }       

        [JsonProperty("player_logo_position")]
        public string PlayerLogoPosition { get; set; }

        [JsonProperty("player_responsive")]
        public bool PlayerResponsive { get; set; }

        [JsonProperty("player_type")]
        public string PlayerType { get; set; }
       
        [JsonProperty("player_width")]
        public int PlayerWidth { get; set; }

        [JsonProperty("recording")]
        public bool Recording { get; set; }        

        [JsonProperty("target_deliivery_protocol")]
        public string TargetDeliveryProtocol { get; set; }

        [JsonProperty("use_stream_source")]
        public bool UseStreamSource { get; set; }               
    }
}