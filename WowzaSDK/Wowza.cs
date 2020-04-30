using System;

namespace WowzaSDK
{
    public class Wowza
    {              
        public Wowza(string ApiKey, string AccessKey)
        {
            this.Apikey = ApiKey;
            this.AccessKey = AccessKey;
        }

        public string Apikey { get; internal set; }
        public string AccessKey { get; internal set; }

        public bool IsSandbox { get; set; }

        public bool UseBasicAuth { get; set; }
    }
}