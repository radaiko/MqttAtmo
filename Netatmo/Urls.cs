namespace Netatmo
{
    public class Urls
    {
        public static string RequestTokenUrl => $"{UrlBase}{UrlRequestTokenPath}";
        public static string GetStationsDataUrl => $"{UrlBase}{UrlGetStationsData}";
        public static string GetHomesDataUrl => $"{UrlBase}{UrlGetHomesData}";
        public static string GetMeasureUrl => $"{UrlBase}{UrlGetMeasuree}";
        public static string GetRoomMeasureUrl => $"{UrlBase}{UrlGetRoomMeasuree}";
        public static string GetPublicDataUrl => $"{UrlBase}{UrlGetPublicData}";
        public static string GetSetRoomThermpointUrl => $"{UrlBase}{UrlGetSetRoomThermpoint}";

        public const string UrlBase = "https://api.netatmo.com";
        public const string UrlRequestTokenPath = "/oauth2/token";
        public const string UrlGetStationsData = "/api/getstationsdata";
        public const string UrlGetMeasuree = "/api/getmeasure";
        public const string UrlGetRoomMeasuree = "/api/getroommeasure";
        public const string UrlGetPublicData = "/api/getpublicdata";
        public const string UrlGetHomesData = "/api/homesdata";
        public const string UrlGetSetRoomThermpoint = "/api/setroomthermpoint";
    }
}