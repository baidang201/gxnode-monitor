using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace gxnode_monitor
{
    public class MonitorConfig
    {
        [JsonIgnore]
        public string ConfigFilePath { get; set; }

        public string witness_id { get; set; }
        public string wallet_passwd { get; set; }
        public List<string> produce_public_keys { get; set; }
        public int miss_block_interval { get; set; }
        public int warn_miss_block_count { get; set; }
        public int switch_miss_block_count { get; set; }
        public string cli_wallet_path { get; set; }
        public string wallet_file_path { get; set; }
        public string api_url { get; set; }
        public string wss_url { get; set; }
        public bool enable_node_switch { get; set; }
        public string dingding_alarm_url { get; set; }
        public bool enbable_vote_monitor { get; set; }
        public ulong votes_alarm_count { get; set; }

        public static MonitorConfig LoadFromConfig(string configFilePath)
        {
            var mc = JsonConvert.DeserializeObject<MonitorConfig>(File.ReadAllText(configFilePath));
            mc.ConfigFilePath = configFilePath;

            return mc;
        }

        public void SaveConfig()
        {
            File.WriteAllText(ConfigFilePath, this.ToString());
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
