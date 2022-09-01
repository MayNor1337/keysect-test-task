using Newtonsoft.Json;

namespace newSectTask
{
    public class DataSaver
    {
        public static void CreateExportFile(Data data, string path)
        {
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, json);
            PrintSystem.PrintWhenExport(path);
        }
    }
}