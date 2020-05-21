using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WowzaSDK.Models.Players
{
    public class PlayerModel : BaseModel
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("transcoder_id")]
        public string TranscoderID { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    public class PlayerRequestModel : PlayerModel
    {
        [JsonProperty("countdown")]
        public bool Countdown { get; set; }
        [JsonProperty("countdown_at")]
        public DateTime CountdownAt { get; set; }
        [JsonProperty("hosted_page")]
        public bool HostedPage { get; set; }
        [JsonProperty("hosted_page_description")]
        public string HostedPageDescription { get; set; }
        [JsonProperty("hosted_page_logo_image")]
        public string HostedPageLogoImage { get; set; }
        [JsonProperty("hosted_page_sharing_icons")]
        public string HostedPageSharingIcons { get; set; }
        [JsonProperty("hosted_page_title")]
        public string HostedPageTitle { get; set; }
        [JsonProperty("logo_image")]
        public string LogoImage { get; set; }
        [JsonProperty("logo_position")]
        public string LogoPosition { get; set; }
        [JsonProperty("remove_hosted_page_logo_image")]
        public bool RemoveHostedPageLogoImage { get; set; }
        [JsonProperty("remove_logo_image")]
        public bool RemoveLogoImage { get; set; }
        [JsonProperty("remove_video_poster_page")]
        public bool RemoveVideoPosterPage { get; set; }
        [JsonProperty("responsive")]
        public bool Responsive { get; set; }
        [JsonProperty("video_poster_image")]
        public string VideoPosterImage { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
    }

    public class PlayerResponseModel : PlayerModel
    {
        [JsonProperty("countdown")]
        public bool Countdown { get; set; }
        [JsonProperty("countdown_at")]
        public DateTime CountdownAt { get; set; }
        [JsonProperty("embed_code")]
        public string EmbedCode { get; set; }
        [JsonProperty("hds_playback_url")]
        public string HdsPlaybackURL { get; set; }
        [JsonProperty("hls_playback_url")]
        public string HlsPlaybackURL { get; set; }
        [JsonProperty("hosted_page")]
        public bool HostedPage { get; set; }
        [JsonProperty("hosted_page_description")]
        public string HostedPageDescription { get; set; }
        [JsonProperty("hosted_page_logo_image_url")]
        public string HostedPageLogoImageURL { get; set; }
        [JsonProperty("hosted_page_sharing_icons")]
        public string HostedPageSharingIcons { get; set; }
        [JsonProperty("hosted_page_title")]
        public string HostedPageTitle { get; set; }
        [JsonProperty("hosted_page_url")]
        public string HostedPageURL { get; set; }
        [JsonProperty("logo_image_url")]
        public string LogoImageURL { get; set; }
        [JsonProperty("logo_position")]
        public string LogoPosition { get; set; }
        [JsonProperty("responsive")]
        public bool Responsive { get; set; }
        [JsonProperty("video_poster_image_url")]
        public string VideoPosterImageURL { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
    }

    public class InnerStateModel : BaseModel
    {
        [JsonProperty("state")]
        public string State { get; set; }
    }

    internal class PlayerStateModel: BaseModel
    {
        [JsonProperty("player")]
        public InnerStateModel Player { get; set; }
    }

    internal class PlayerListModel: BaseModel
    {
        [JsonProperty("players")]
        public List<PlayerModel> Players { get; set; }
    }

    internal class PlayerReadModel: BaseModel
    {
        [JsonProperty("player")]
        public PlayerResponseModel Player { get; set; }
    }

    internal class PlayerCreateModel : BaseModel
    {
        [JsonProperty("player")]
        public PlayerRequestModel Player { get; set; }
    }
}
