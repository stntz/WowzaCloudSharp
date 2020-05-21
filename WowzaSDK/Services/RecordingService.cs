using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WowzaSDK.Models;
using WowzaSDK.Models.Recordings;

namespace WowzaSDK.Services
{
    public class RecordingService : WowzaServiceClient<RecordingModel>
    {
        public RecordingService(Wowza wowza) : base(wowza) { }

        protected override string EndPoint => "/recordings";

        public async Task<List<RecordingModel>> FetAllRecordingsAsync(int page = 1, int recordsPerPage = 1000)
        {
            var paramsList = new WowzaQueryParams
            {
                {"page", page },
                {"per_page", recordsPerPage }
            };
            var result = await GetActionAsync<RecordingListModel>("", paramsList).ConfigureAwait(false);
            return result.Recordings ?? null;
        }

        public async Task<RecordingResponseModel> FetchARecordingAsync(string recordingID)
        {
            if (string.IsNullOrWhiteSpace(recordingID))
                throw new ArgumentNullException(nameof(recordingID), "The ID of the recording is needed to retrieve the recording");

            var result = await GetActionAsync<RecordingReadModel>($"/{recordingID}", null).ConfigureAwait(false);
            return result?.Recording ?? null;
        }


        public async Task<WowzaApiResponse> DeleteRecordingAsync(string recordingID)
        {
            if (string.IsNullOrWhiteSpace(recordingID))
                throw new ArgumentNullException(nameof(recordingID), "The ID of the recording is needed to delete the recording");

            return await DeleteActionAsync<WowzaApiResponse>($"/{recordingID}", null).ConfigureAwait(false);
        }

        public async Task<InnerStateModel> FetchRecordingStateAsync(string recordingID)
        {
            if (string.IsNullOrWhiteSpace(recordingID))
                throw new ArgumentNullException(nameof(recordingID), "The ID of the recording is needed to fetch the state of the recording");
            var result = await GetActionAsync<RecordingStateModel>($"/{recordingID}/state", null).ConfigureAwait(false);
            return result?.Recording ?? null;
        }
    }
}