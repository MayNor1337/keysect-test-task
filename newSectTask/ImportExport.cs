using Newtonsoft.Json;

namespace newSectTask
{
    public class ImportExport
    {
        public static void CreateExportFile(Data data)
        {
            string json = JsonConvert.SerializeObject(data);
            Console.WriteLine(json);
            File.WriteAllText(@"..\..\..\..\data\data.json", json);
            Console.WriteLine(@"The ""data"" file is generated, find it in the ""data"" folder");
        }
        
        public static Data? Import()
        {
            string json = File.ReadAllText(@"..\..\..\..\data\data.json");
            Console.WriteLine("Data replaced");
            return JsonConvert.DeserializeObject<Data>(json);
        }
    }
}