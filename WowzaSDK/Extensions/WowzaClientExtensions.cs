using System;
using System.Collections.Generic;
using System.Net.Http;
using WowzaSDK.Models;

namespace WowzaSDK.Extensions
{
    public static class WowzaClientExtensions
    {
        public static void AddWowzaRequestHeaders(this HttpRequestMessage httpRequest, string apiKey, string requestpath, bool useBasicAuth = false)
        {
            if (useBasicAuth)
            {
                httpRequest.Headers.Add("wsc-api-key", apiKey);
            }
            else
            {
                var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                httpRequest.Headers.Add("wsc-timestamp", timestamp.ToString());
                httpRequest.Headers.Add("wsc-signature", WowzaAuthGenerator.GenerateHmacSignature(apiKey, requestpath, timestamp));
            }
        }

        public static void BuildQueryParams(this HttpRequestMessage httpRequest, WowzaQueryParams queryParams)
        {
            if (queryParams != null && queryParams.Count > 0)
            {
                var paramList = new List<string>();
                foreach (var dictValue in queryParams)
                {
                    paramList.Add($"{dictValue.Key}={dictValue.Value}");
                }
                httpRequest.RequestUri = new Uri(httpRequest.RequestUri.ToString() + "?" + string.Join("&", paramList));
            }
        }
    }
}