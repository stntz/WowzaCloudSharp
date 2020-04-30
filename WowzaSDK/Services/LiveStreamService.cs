using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WowzaSDK.Models;

namespace WowzaSDK.Services
{
    public class LiveStreamService : WowzaServiceClient<LiveStreamModel>
    {
        public LiveStreamService(Wowza wowza) : base(wowza)
        {
        }

        protected override string EndPoint => "/live_streams";

        public async Task<LiveStreamResponseModel> CreateLiveStreamAsync(LiveStreamRequestModel liveStreamModel)
        {
            if (liveStreamModel == null)
                throw new ArgumentNullException(nameof(liveStreamModel), "LiveStream Object cannot be null");

            var liveStreamCreate = new LiveStreamCreateModel
            {
                LiveStream = liveStreamModel
            };

            var result = await CreateActionAsync<LiveStreamCreateModel, LiveStreamReadModel>("", liveStreamCreate).ConfigureAwait(false);
            return result?.LiveStream ?? null;           
        }

        public async Task<List<LiveStreamResponseModel>> GetLiveStreamsAsync(int page = 1, int recordsPerPage = 20)
        {
            var paramList = new WowzaQueryParams
            {
                { "page", page },
                { "per_page", recordsPerPage }
            };
            var result =  await GetActionAsync<LiveStreamListModel>("", paramList).ConfigureAwait(false);
            return result?.LiveStreams ?? null;
        }

        public async Task<InnerStateModel> StartLiveStreamAsync(string liveStreamID)
        {
            if (string.IsNullOrWhiteSpace(liveStreamID))
                throw new ArgumentNullException(nameof(liveStreamID), "The ID of the live stream is needed to start the stream");

            var result =  await PutActionAsync<LiveStreamStateModel>($"/{liveStreamID}/start", null, null).ConfigureAwait(false);
            return result?.LiveStream ?? null;
        }

        public async Task<InnerStateModel> StopLiveStreamAsync(string liveStreamID)
        {
            if (string.IsNullOrWhiteSpace(liveStreamID))
                throw new ArgumentNullException(nameof(liveStreamID), "The ID of the live stream is needed to stop the stream");

            var result =  await PutActionAsync<LiveStreamStateModel>($"/{liveStreamID}/stop", null, null).ConfigureAwait(false);
            return result?.LiveStream ?? null;
        }

        public async Task<LiveStreamResponseModel> GetLiveStreamAsync(string liveStreamID)
        {
            if (string.IsNullOrWhiteSpace(liveStreamID))
                throw new ArgumentNullException(nameof(liveStreamID), "The ID of the live stream is needed to retrieve the stream");

            var result =  await GetActionAsync<LiveStreamReadModel>($"/{liveStreamID}", null).ConfigureAwait(false);
            return result?.LiveStream ?? null;
        }

        public async Task<LiveStreamResponseModel> UpdateLiveStreamAsync(string liveStreamID, LiveStreamRequestModel liveStreamModel)
        {
            if (liveStreamModel == null)
                throw new ArgumentNullException(nameof(liveStreamModel), "LiveStream Object cannot be null");
            if (string.IsNullOrWhiteSpace(liveStreamID))
                throw new ArgumentNullException(nameof(liveStreamID), "The ID of the live stream is needed to update the stream");

            var liveStreamCreate = new LiveStreamCreateModel
            {
                LiveStream = liveStreamModel
            };
            var result =  await PatchActionAsync<LiveStreamCreateModel, LiveStreamReadModel>($"/{liveStreamID}", liveStreamCreate).ConfigureAwait(false);
            return result?.LiveStream ?? null;
        }

        public async Task<WowzaApiResponse> DeleteLiveStreamAsync(string liveStreamID)
        {
            if (string.IsNullOrWhiteSpace(liveStreamID))
                throw new ArgumentNullException(nameof(liveStreamID), "The ID of the live stream is needed to delete the stream");

            return await DeleteActionAsync<WowzaApiResponse>($"/{liveStreamID}", null).ConfigureAwait(false);
        }

        public async Task<InnerStateModel> ResetLiveStreamAsync(string liveStreamID)
        {
            if (string.IsNullOrWhiteSpace(liveStreamID))
                throw new ArgumentNullException(nameof(liveStreamID), "The ID of the live stream is needed to reset the stream");

            var result = await PutActionAsync<LiveStreamStateModel>($"/{liveStreamID}/reset", null, null).ConfigureAwait(false);
            return result?.LiveStream ?? null;
        }

        public async Task<InnerStateModel> RegenerateLiveStreamCodeAsync(string liveStreamID)
        {
            if (string.IsNullOrWhiteSpace(liveStreamID))
                throw new ArgumentNullException(nameof(liveStreamID), "The ID of the live stream is needed to reset the stream");

            var result = await PutActionAsync<LiveStreamStateModel>($"/{liveStreamID}/reset", null, null).ConfigureAwait(false);
            return result?.LiveStream ?? null;
        }

        public async Task<InnerStateModel> FetchLiveStreamThumbnailAsync(string liveStreamID)
        {
            if (string.IsNullOrWhiteSpace(liveStreamID))
                throw new ArgumentNullException(nameof(liveStreamID), "The ID of the live stream is needed to fetch the state of the stream");

            var result = await GetActionAsync<LiveStreamStateModel>($"/{liveStreamID}/thumbnail_url", null).ConfigureAwait(false);
            return result?.LiveStream ?? null;
        }

        public async Task<InnerStateModel> FetchLiveStreamStateAsync(string liveStreamID)
        {
            if (string.IsNullOrWhiteSpace(liveStreamID))
                throw new ArgumentNullException(nameof(liveStreamID), "The ID of the live stream is needed to fetch the state of the stream");

            var result = await GetActionAsync<LiveStreamStateModel>($"/{liveStreamID}/state", null).ConfigureAwait(false);
            return result?.LiveStream ?? null;
        }

        public async Task<InnerMetricModel> FetchLiveStreamMetricsAsync(string liveStreamID)
        {
            if (string.IsNullOrWhiteSpace(liveStreamID))
                throw new ArgumentNullException(nameof(liveStreamID), "The ID of the live stream is needed to fetch the metrics for the stream");

            var result = await GetActionAsync<LiveStreamMetricModel>($"/{liveStreamID}/stats", null).ConfigureAwait(false);
            return result?.LiveStream ?? null;
        }
    }
}
