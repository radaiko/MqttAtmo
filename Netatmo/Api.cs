using MqttAtmo.Config;
using Netatmo.Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Netatmo
{
    public class Api
    {
        public delegate void LoginSuccessfulHandler(object sender);

        public delegate void LoginFailedlHandler(object sender);

        private readonly HttpClient _httpClient;
        private readonly Configuration _configuration = Configuration.Load();

        public event LoginSuccessfulHandler LoginSuccessful;

        public event LoginFailedlHandler LoginFailed;

        public string ClientId { get; }
        public string ClientSecret { get; }
        public OAuthAccessToken OAuthAccessToken { get; private set; }

        public Api()
        {
            ClientId = _configuration.Netatmo.ClientId;
            ClientSecret = _configuration.Netatmo.ClientSecret;
            _httpClient = new HttpClient();
        }

        public async Task<bool> Login(string email, string password, EScope[] eScopes)
        {
            var response = await Request<OAuthAccessToken>(Urls.RequestTokenUrl, HttpBodyConnector.GetLoginContent(ClientId, ClientSecret, email, password, eScopes), true);

            if (response.IsSuccess)
            {
                OAuthAccessToken = response.Result;
                OnLoginSuccessful();
                return true;
            }
            else
            {
                OnLoginFailed();
                return false;
            }
        }

        private async Task<bool> RefreshToken()
        {
            var response = await Request<OAuthAccessToken>(Urls.RequestTokenUrl, HttpBodyConnector.GetRefreshTokenContent(OAuthAccessToken.RefreshToken, ClientId, ClientSecret), true);
            if (!response.IsSuccess)
                return false;

            OAuthAccessToken = response.Result;
            return true;
        }


        private async Task<Response<T>> Request<T>(string url, Dictionary<string, string> content, bool isTokeRenquest = false)
        {
            var httpContent = new MultipartFormDataContent();

            if (!isTokeRenquest)
            {
                if (OAuthAccessToken == null)
                    return Response<T>.CreateUnsuccessful("Please login", HttpStatusCode.Unauthorized);

                if (OAuthAccessToken.NeedsRefresh)
                {
                    var refreshed = await RefreshToken();
                    if (!refreshed)
                        return Response<T>.CreateUnsuccessful("Unable to refresh token", HttpStatusCode.ExpectationFailed);
                }

                httpContent.Add(new StringContent(OAuthAccessToken.AccessToken), "access_token");
            }

            foreach (var key in content.Keys)
            {
                httpContent.Add(new StringContent(content[key]), key);
            }

            var t = Task.Run(() => PostAsync<T>(url, httpContent));
            t.Wait();
            return t.Result;
            
        }

        private async Task<Response<T>> PostAsync<T>(string url, MultipartFormDataContent httpContent)
        {
            var clientResponse = await _httpClient.PostAsync(url, httpContent);
            var responseString = await clientResponse.Content.ReadAsStringAsync();
            var responseResult = clientResponse.IsSuccessStatusCode ?
                Response<T>.CreateSuccessful(JsonSerializer.Deserialize<T>(responseString), clientResponse.StatusCode) :
                Response<T>.CreateUnsuccessful(responseString, clientResponse.StatusCode);


            return responseResult;
        }

        protected virtual void OnLoginSuccessful()
        {
            LoginSuccessful?.Invoke(this);
        }

        protected virtual void OnLoginFailed()
        {
            LoginFailed?.Invoke(this);
        }

        // Get Data

        public async Task<Response<HomesData>> GetHomesData(string homeId = null, string gatewayType = null) => await Request<HomesData>(Urls.GetHomesDataUrl, HttpBodyConnector.GetHomesDataContent(homeId, gatewayType));

        public async Task<Response<Measure>> GetMeasure(string deviceId, EScale scale = EScale.min30, ETypeMeasure type = ETypeMeasure.boileron) => await Request<Measure>(Urls.GetMeasureUrl, HttpBodyConnector.GetMeasureBody(deviceId, scale, type));

        public async Task<Response<LastMeasure>> GetLastRoomMeasure(string homeId, string roomId, EScale scale = EScale.min30, ETypeRoomMeasure type = ETypeRoomMeasure.Temperature) => await Request<LastMeasure>(Urls.GetRoomMeasureUrl, HttpBodyConnector.GetLastRoomMeasureBody(homeId, roomId, scale, type));

        // Send Data

        public async Task<Response<SetRoomThermpoint>> SetRoomThermpoint(string homeId, string roomId, EMode mode, string temp, string endtime = null) => await Request<SetRoomThermpoint>(Urls.GetSetRoomThermpointUrl, HttpBodyConnector.GetSetRoomThermpointBody(homeId, roomId, mode, temp, endtime));
    }
}