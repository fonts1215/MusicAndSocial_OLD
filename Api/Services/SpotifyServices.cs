using System.Threading.Tasks;
using System.Net.Http;
using MusicAndSocial.Api.Model.Response;
using MusicAndSocial.Api.Model.Request;
using MusicAndSocial.Common.Constants;
using System.Collections.Generic;
using Newtonsoft.Json;
using MusicAndSocial.Api.Services.Interfaces;

namespace MusicAndSocial.Api.Services
{
    public class SpotifyServices : ISpotifyServices
    {
        private readonly HttpClient client;

        public SpotifyServices(HttpClient client)
        {
            this.client = client;
        }

        public async Task<AuthorizeResponse> AuthorizationAccess(AuthorizeRequest authorizeRequest)
        {
            HttpResponseMessage response = await client.GetAsync(
               Endpoints.SpotifyEndpoints.SpotifyAuthorization(authorizeRequest));

            if (response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<AuthorizeResponse>();
            }
            else
                return await response.Content.ReadAsAsync<AuthorizeResponse>();
        }

        public async Task<AuthorizationToken> RefreshToken(string refreshToken, TokenRequest tokenRequest)
        {
            var values = new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "code", tokenRequest.Code },
                { "redirect_uri", "https://localhost:44319/api/SpotifyAuthentication" },
                { "client_secret", tokenRequest.Client_Secret },
                { "client_id", tokenRequest.Client_Id}
            };

            var content = new FormUrlEncodedContent(values);
            client.DefaultRequestHeaders.Add("Authorization", refreshToken);
            var response = await client.PostAsync(Endpoints.SpotifyEndpoints.SpotifyAccessToken(), content);

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AuthorizationToken>(responseString);

        }

        public Task<AuthorizationToken> RefreshToken(AuthorizationToken authorizationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<AuthorizationToken> RequestToken(TokenRequest tokenRequest)
        {
            var values = new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "code", tokenRequest.Code },
                { "redirect_uri", "https://localhost:44319/api/SpotifyAuthentication" },
                { "client_secret", tokenRequest.Client_Secret },
                { "client_id", tokenRequest.Client_Id}
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(Endpoints.SpotifyEndpoints.SpotifyAccessToken(), content);

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AuthorizationToken>(responseString);
        }

    }
}
