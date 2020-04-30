using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WowzaSDK.Exceptions;
using WowzaSDK.Extensions;
using WowzaSDK.Models;
using WowzaSDK.Models.ErrorHandler;

namespace WowzaSDK
{
    public abstract class WowzaServiceClient<T> where T : BaseModel
    {
        const string ProductionApiURL = "https://api.cloud.wowza.com";
        const string SandboxApiURL = "https://api.sandbox.cloud.wowza.com";
        const string ApiVersion = "1.4";
        readonly string ApiSignaturePath = $"/api/v{ApiVersion}";
        const string ClientAgent = "WowzaCloud-CSharp-SDK";

        protected abstract string EndPoint { get; }
        
        HttpClient httpClient = null;

        public Wowza Wowza { get; internal set; }


        public WowzaServiceClient(Wowza wowza)
        {
            Wowza = wowza;

            CreateHttpClient();
        }

        string BasePath => $"{(Wowza.IsSandbox ? SandboxApiURL : ProductionApiURL)}/api/v{ApiVersion}{EndPoint}";

        void CreateHttpClient()
        {
            httpClient = new HttpClient();
            AddDefaultRequestHeaders();
        }

        void AddDefaultRequestHeaders()
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", ClientAgent);

            // This is left here as it is constant for all request to Wowza whether you use HMAC or api key authentication
            httpClient.DefaultRequestHeaders.Add("wsc-access-key", Wowza.AccessKey);           
        }
        protected async Task<TResult> CreateActionAsync<TResult>(string additionalUrlPath, TResult data, WowzaQueryParams queryParams = null)
        {
            return await CreateActionAsync<TResult, TResult>(additionalUrlPath, data, queryParams);
        }
        protected async Task<TResult> CreateActionAsync<TRequest, TResult>(string additionalUrlPath, TRequest data, WowzaQueryParams queryParams = null)
        {
            return await SendRequest<TRequest, TResult>(HttpMethod.Post, additionalUrlPath, data, BasePath, queryParams);                 
        }

        protected async Task<TResult> PatchActionAsync<TResult>(string additionalUrlPath, TResult data, WowzaQueryParams queryParams = null)
        {
            return await PatchActionAsync<TResult, TResult>(additionalUrlPath, data, queryParams);
        }

        protected async Task<TResult> PatchActionAsync<TRequest, TResult>(string additionalUrlPath, TRequest data, WowzaQueryParams queryParams = null)
        {
            return await SendRequest<TRequest, TResult>(HttpMethod.Patch, additionalUrlPath, data, BasePath, queryParams);
        }


        protected async Task<TResult> PutActionAsync<TResult>(string additionalUrlPath, TResult data, WowzaQueryParams queryParams = null)
        {
            return await PutActionAsync<TResult, TResult>(additionalUrlPath, data, queryParams);
        }

        protected async Task<TResult> PutActionAsync<TRequest, TResult>(string additionalUrlPath, TRequest data, WowzaQueryParams queryParams = null)
        {
            return await SendRequest<TRequest, TResult>(HttpMethod.Put, additionalUrlPath, data, BasePath, queryParams);
        }

        protected async Task<TResult> DeleteActionAsync<TResult>(string additionalUrlPath, WowzaQueryParams queryParams = null)
        {
            return await SendRequest<T, TResult>(HttpMethod.Delete, additionalUrlPath, null, BasePath, queryParams);
        }

        protected async Task<TResult> GetActionAsync<TResult>(string additionalUrlPath, WowzaQueryParams queryParams)
        {
            return await SendRequest<T, TResult>(HttpMethod.Get, additionalUrlPath, null, BasePath);
        }

        async Task<TResult> SendRequest<TRequest, TResult>(HttpMethod httpMethod, string additionalUrlPath, TRequest data, string endpointURL, WowzaQueryParams queryParams = null)
        {
            HttpResponseMessage response;
            using (var request = new HttpRequestMessage(httpMethod, $"{endpointURL}{additionalUrlPath}"))
            {
                request.BuildQueryParams(queryParams);
                request.AddWowzaRequestHeaders(Wowza.Apikey, $"{ApiSignaturePath}{EndPoint}", Wowza.UseBasicAuth);

                if (httpMethod != HttpMethod.Get && data != null)
                {
                    var jsonSerializer = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                    request.Content = new StringContent(JsonConvert.SerializeObject(data, Formatting.Indented, jsonSerializer), Encoding.UTF8, "application/json");
                }
                response = await httpClient.SendAsync(request);
            }
            if (response != null && response.IsSuccessStatusCode)
            {                
                var jsonContent = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(jsonContent))
                {
                    try
                    {
                        TResult result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(jsonContent));
                        return result;
                    }
                    catch (Exception ex)
                    {
                        throw new WowzaException(ex.Message, ex.InnerException);
                    }
                }
                else
                {
                    return default;
                }
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            try
            {
                var errorResult = await Task.Run(() => JsonConvert.DeserializeObject<WowzaError>(errorContent));
                throw new WowzaException(errorResult.Meta.Status, errorResult.Meta.Code, errorResult.Meta.Message);
            }
            catch (JsonException jsonException)
            {
                throw new WowzaException(response.ReasonPhrase, jsonException.InnerException);
            }
        }
    }    
}