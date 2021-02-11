using System;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Netatmo.Model
{

    public class HomesData
    {
        [JsonPropertyName("body")]
        public HomesDataBody Body { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("time_exec")]
        public double TimeExec { get; set; }

        [JsonPropertyName("time_server")]
        public int TimeServer { get; set; }
    }



}
