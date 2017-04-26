using System.Collections.Generic;

namespace einfache_refactorings
{
    // "a=1;b=2;c=3" => {{"a", "1"}, {"b", "2"}, {"c", "3"}}
    public class ConfigurationBuilder2
    {
        public IDictionary<string, string> ToDictionary(string configuration) {
            var settings = SplitIntoSettings(configuration);
            var pairs = SplitIntoKeyValuePairs(settings);
            var result = BuildDictionary(pairs);

            return result;
        }

        private static Dictionary<string, string> BuildDictionary(List<KeyValuePair<string, string>> pairs) {
            var result = new Dictionary<string, string>();
            foreach (var pair in pairs) {
                result.Add(pair.Key, pair.Value);
            }
            return result;
        }

        private static List<KeyValuePair<string, string>> SplitIntoKeyValuePairs(string[] settings) {
            var pairs = new List<KeyValuePair<string, string>>();
            foreach (var setting in settings) {
                var keyAndValue = setting.Split('=');
                pairs.Add(new KeyValuePair<string, string>(keyAndValue[0], keyAndValue[1]));
            }
            return pairs;
        }

        private static string[] SplitIntoSettings(string configuration) {
            var settings = configuration.Split(';');
            return settings;
        }
    }
}