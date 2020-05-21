using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WowzaSDK.Models;
using WowzaSDK.Models.Players;

namespace WowzaSDK.Services
{
    public class PlayerService : WowzaServiceClient<PlayerModel>
    {
        public PlayerService(Wowza wowza) : base(wowza) {  }

        protected override string EndPoint => "/players";

        public async Task<List<PlayerModel>> FetchAllPlayersAsync(int page = 1, int recordsPerPage = 1000)
        {
            var queryParams = new WowzaQueryParams
            {
                {"page", page },
                {"per_page", recordsPerPage }
            };

            var result = await GetActionAsync<PlayerListModel>("", queryParams).ConfigureAwait(false);
            return result?.Players ?? null;
        }

        public async Task<PlayerResponseModel> FetchPlayerAsync(string playerID)
        {
            if (string.IsNullOrWhiteSpace(playerID))
                throw new NullReferenceException($"You need a player id to fetch this information");

            var result = await GetActionAsync<PlayerReadModel>($"/{playerID}", null).ConfigureAwait(false);
            return result?.Player ?? null;
        }

        public async Task<PlayerResponseModel> UpdatePlayerAsync(string playerID, PlayerRequestModel playerModel)
        {
            if (string.IsNullOrWhiteSpace(playerID))
                throw new NullReferenceException($"You need a player id to update this player");

            if (playerModel == null)
                throw new ArgumentNullException(nameof(playerModel), "Player Object cannot be null");

            var playerCreateModel = new PlayerCreateModel
            {
                Player = playerModel
            };

            var result = await PatchActionAsync<PlayerCreateModel, PlayerReadModel>($"/{playerID}", playerCreateModel, null).ConfigureAwait(false);
            return result?.Player ?? null;
        }

        public async Task<InnerStateModel> RebuildPlayerCodeAsync(string playerID)
        {
            if (string.IsNullOrWhiteSpace(playerID))
                throw new NullReferenceException($"You need a player id to update this player");

            var result = await CreateActionAsync<PlayerStateModel>($"/{playerID}/rebuild", null, null).ConfigureAwait(false);
            return result?.Player ?? null;
        }

        public async Task<InnerStateModel> FetchPlayerStateAsync(string playerID)
        {
            if (string.IsNullOrWhiteSpace(playerID))
                throw new NullReferenceException($"You need a player id to update this player");

            var result = await GetActionAsync<PlayerStateModel>($"/{playerID}/state", null).ConfigureAwait(false);
            return result?.Player ?? null;
        }

        public async Task<PlayerUrlResponseModel> CreatePlayerUrlAsync(string playerID, PlayerUrlModel playerUrlModel)
        {
            if (string.IsNullOrWhiteSpace(playerID))
                throw new NullReferenceException($"You need a player id to update this player");

            if (playerUrlModel == null)
                throw new ArgumentNullException(nameof(playerUrlModel), "PlayerUrlModel Object cannot be null");

            var urlData = new UrlDataModel
            {
                Url = playerUrlModel
            };
            var result = await CreateActionAsync<UrlDataModel, PlayerUrlReadModel>($"/{playerID}/urls", urlData, null).ConfigureAwait(false);
            return result?.Url ?? null;
        }


        public async Task<List<PlayerUrlResponseModel>> FetchAllPlayerUrlAsync(string playerID)
        {
            if (string.IsNullOrWhiteSpace(playerID))
                throw new NullReferenceException($"You need a player id to update this player");

            var result = await GetActionAsync<PlayerUrlListModel>($"/{playerID}/urls", null).ConfigureAwait(false);
            return result?.PlayerUrls ?? null;
        }

        public async Task<PlayerUrlResponseModel> FetchPlayerUrlAsync(string playerID, string id)
        {
            if (string.IsNullOrWhiteSpace(playerID))
                throw new NullReferenceException($"You need a player id to fetch this data");
            if (string.IsNullOrWhiteSpace(id))
                throw new NullReferenceException($"You need a url id to fetch this data");

            var result = await GetActionAsync<PlayerUrlReadModel>($"/{playerID}/urls/{id}", null).ConfigureAwait(false);
            return result?.Url ?? null;
        }

        public async Task<PlayerUrlResponseModel> UpdatePlayerUrlAsync(string playerID, string id, PlayerUrlModel playerUrlModel)
        {
            if (string.IsNullOrWhiteSpace(playerID))
                throw new NullReferenceException($"You need a player id to fetch this data");
            if (string.IsNullOrWhiteSpace(id))
                throw new NullReferenceException($"You need a url id to fetch this data");
            if (playerUrlModel == null)
                throw new ArgumentNullException(nameof(playerUrlModel), "PlayerUrlModel Object cannot be null");

            var playerCreateModel = new PlayerUrlCreateModel
            {
                Url = playerUrlModel
            };

            var result = await PatchActionAsync<PlayerUrlCreateModel, PlayerUrlReadModel>($"/{playerID}/urls/{id}", playerCreateModel, null).ConfigureAwait(false);
            return result?.Url ?? null;
        }

        public async Task<WowzaApiResponse> DeletePlayerUrlAsync(string playerID, string id)
        {
            if (string.IsNullOrWhiteSpace(playerID))
                throw new NullReferenceException($"You need a player id to delete this data");
            if (string.IsNullOrWhiteSpace(id))
                throw new NullReferenceException($"You need a url id to delete this data");            

            return await DeleteActionAsync<WowzaApiResponse>($"/{playerID}/urls/{id}", null).ConfigureAwait(false);            
        }
    }
}
