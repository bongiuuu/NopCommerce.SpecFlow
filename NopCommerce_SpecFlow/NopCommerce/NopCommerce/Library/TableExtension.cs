using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace NopCommerce.Library
{
    public static class TableExtension
    {
        public static string ToJson(Table table)
        {
            return JsonConvert.SerializeObject(ToDictionary(table));
        }

        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }
    }
}