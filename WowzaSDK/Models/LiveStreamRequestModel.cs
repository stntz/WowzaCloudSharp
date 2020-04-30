using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WowzaSDK.Models
{
    public class LiveStreamRequestModel : LiveStreamModel
    {
        [JsonProperty("disable_authentication")]
        public bool DisableAuthentication { get; set; }       

        [JsonProperty("hosted_page_logo_image")]
        public string HostedPageLogoImage { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("player_logo_image")]
        public string PlayerLogoImage { get; set; }

        [JsonProperty("player_video_poster_image")]
        public string PlayerVideoPosterImage { get; set; }

        [JsonProperty("remove_hosted_page_logo_image")]
        public bool RemoveHostedPageLogoImage { get; set; }

        [JsonProperty("remove_player_logo_image")]
        public bool RemovePlayerLogoImage { get; set; }

        [JsonProperty("remove_player_video_poster_iamge")]
        public bool RemovePlayerVideoPosterImage { get; set; }

        [JsonProperty("source_url")]
        public string SourceURL { get; set; }       

        [JsonProperty("username")]
        public string Username { get; set; }
    }
}