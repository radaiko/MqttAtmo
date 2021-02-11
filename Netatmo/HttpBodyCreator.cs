using Netatmo.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Netatmo
{
    public class HttpBodyConnector
    {
        public static Dictionary<string, string> GetLoginContent(string clientId, string clientSecret, string email, string password, EScope[] eScope) => new Dictionary<string, string>
        {
            {"grant_type", "password"},
            {"client_id", clientId},
            {"client_secret", clientSecret},
            {"username", email},
            {"password", password},
            {"scope", String.Join(" ", eScope.Where(s => !String.IsNullOrEmpty(s.ToString())))  }
        };

        public static Dictionary<string, string> GetRefreshTokenContent(string refreshToken, string clientId, string clientSecret) => new Dictionary<string, string>
        {
            {"grant_type", "refresh_token"},
            {"refresh_token", refreshToken },
            {"client_id",  clientId},
            {"client_secret", clientSecret}
        };

        public static Dictionary<string, string> GetHomesDataContent(string homeId, string gatewayType)
        {
            var content = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(homeId))
                content.Add("homeId", homeId);
            if (!string.IsNullOrEmpty(gatewayType))
                content.Add("gatewayType", gatewayType);

            return content;
        }

        public static Dictionary<string, string> GetMeasureBody(string deviceId, EScale scale, ETypeMeasure type) => new Dictionary<string, string>
        {
            {"device_id", deviceId},
            {"scale", scale.ToRevertString()},
            {"type", type.ToString()},
        };

        public static Dictionary<string, string> GetLastRoomMeasureBody(string homeId, string roomId, EScale scale, ETypeRoomMeasure type) => new Dictionary<string, string>
        {
            {"home_id", homeId},
            {"room_id", roomId},
            {"scale", scale.ToRevertString()},
            {"type", type.ToString()},
            {"optimize", "false"},
            {"real_time", "false"},
            {"date_end", "last"},
        };
        public static Dictionary<string, string> GetSetRoomThermpointBody(string homeId, string roomId, EMode mode, string temp, string endtime) => new Dictionary<string, string>
        {
            {"home_id", homeId},
            {"room_id", roomId},
            {"mode", mode.ToString()},
            {"temp", temp}
        };
    }
}