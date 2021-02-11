using System;
using System.Text.Json.Serialization;

namespace Netatmo.Model
{
    public class OAuthAccessToken
    {
        private readonly int _minusExpiresSeconds = 1;
        private string _accessToken;
        private DateTime _creationTime;

        [JsonPropertyName("access_token")]
        public string AccessToken
        {
            get
            {
                return _accessToken;
            }
            set
            {
                _accessToken = value;
                _creationTime = DateTime.Now;
            }
        }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("scope")]
        public string[] Scope { get; set; }

        [JsonPropertyName("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonPropertyName("expire_in")]
        public long ExpireIn { get; set; }

        [JsonIgnore]
        public bool NeedsRefresh => _creationTime.AddSeconds(ExpiresIn - _minusExpiresSeconds) <= DateTime.Now;
    }
}