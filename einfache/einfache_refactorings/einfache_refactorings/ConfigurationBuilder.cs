using System.Collections.Generic;

namespace einfache_refactorings
{
    public class ConfigurationBuilder
    {
        public IDictionary<string, string> ToDictionary(string configuration) {
            var result = new Dictionary<string, string>();
            var settings = configuration.Split(';');
            foreach (var setting in settings) {
                var key_and_value = setting.Split('=');
                result.Add(key_and_value[0], key_and_value[1]);
            }

            return result;
        }























        private static Dictionary<string, string> InsertIntoDictionary(List<KeyValuePair<string, string>> pairs) {
            // Insert pairs into dictionary
            var result = new Dictionary<string, string>();
            foreach (var pair in pairs) {
                result.Add(pair.Key, pair.Value);
            }
            return result;
        }

        private static List<KeyValuePair<string, string>> SplitIntoKeyValuePairs(string[] settings) {
            // Split settings into key/value pairs
            var pairs = new List<KeyValuePair<string, string>>();
            foreach (var setting in settings) {
                var keyAndValue = setting.Split('=');
                pairs.Add(new KeyValuePair<string, string>(keyAndValue[0], keyAndValue[1]));
            }
            return pairs;
        }

        private static string[] SplitIntoSettings(string configuration) {
            // Split configuration into settings
            var settings = configuration.Split(';');
            return settings;
        }
    }

    public class Lalala
    {
        public void Run() {
            var d = new ConfigurationBuilder().ToDictionary("");
        }
    }
}