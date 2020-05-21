using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WowzaSDK.Models.Interfaces;

namespace WowzaSDK.Models.LiveStreams
{
    public class LiveStreamResponseModel : LiveStreamModel
    {
        [JsonProperty("id")]
        public string ID { get; private set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; private set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; private set; }

        [JsonProperty("connection_code")]
        public string ConnectionCode { get; private set; }

        [JsonProperty("connection_code_expires_at")]
        public DateTime ConnectionCodeExpiresAt { get; private set; }

        [JsonProperty("direct_playback_urls")]
        public PlaybackURL DirectPlaybackUrls { get; private set; }

        [JsonProperty("hosted_page_logo_image_url")]
        public string HostedPageLogoImageUrl { get; private set; }

        [JsonProperty("hosted_page_url")]
        public string HostedPagURL { get; private set; }

        [JsonProperty("player_embed_code")]
        public string PlayerEmbedCode { get; private set; }

        [JsonProperty("player_hls_playback_url")]
        public string PlayerHlsPlaybackURL { get; private set; }

        [JsonProperty("player_id")]
        public string PlayerID { get; private set; }

        [JsonProperty("player_logo_image_url")]
        public string PlayerLogoImageURL { get; private set; }

        [JsonProperty("player_video_poster_image_url")]
        public string PlayerVideoPosterImageURL { get; private set; }

        [JsonProperty("source_connection_information")]
        public SourceConnectionInfo SourceConnectionInformation { get; private set; }

        [JsonProperty("stream_source_id")]
        public string StreamSourceID { get; private set; }

        [JsonProperty("stream_targets")]
        public List<IDInfo> StreamTargets { get; private set; }

        
       
    }

    public class SourceConnectionInfo
    {
        [JsonProperty("primary_server")]
        public string PrimaryServer { get; private set; }

        [JsonProperty("host_port")]
        public string HostPort { get; private set; }

        [JsonProperty("stream_name")]
        public string StreamName { get; private set; }

        [JsonProperty("disable_authentication")]
        public bool DisableAuthentication { get; private set; }

        [JsonProperty("username")]
        public string SourceUsername { get; private set; }

        [JsonProperty("password")]
        public string SourcePassword { get; private set; }
    }

    public class IDInfo
    {
        [JsonProperty("id")]
        public string ID { get; set; }
    }

    public class PlaybackURL
    {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("output_id")]
        public string OutputID { get; private set; }

        [JsonProperty("url")]
        public string URL { get; private set; }
    }
}

