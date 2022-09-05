using Newtonsoft.Json;

namespace newSectTask
{
    public class DataReader
    {
        public static Data? Import(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Data>(json);
        }
    }
}