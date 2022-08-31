using Newtonsoft.Json;

namespace newSectTask
{
    public class DataSaver
    {
        public static void CreateExportFile(Data data, string path)
        {
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, json);
            Console.WriteLine($@"The ""data"" file is generated, find it in the {path} folder");
        }
    }
}