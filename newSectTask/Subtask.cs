using System.Runtime.Serialization;

namespace newSectTask
{
    [DataContract]
    public class Subtask
    {
        [DataMember]
        private string _id, _information;
        [DataMember]
        private string _completed = " ";

        public void OutInformation()
        {
            Console.WriteLine($"[{_completed}] {_id} - {_information}");
        }

        public void CompletedStatus()
        {
            _completed = "V";
            Console.WriteLine($"Status {_id} - Performed V");
        }

        public Subtask(string id, string information)
        {
            _id = id;
            _information = information;
            Console.WriteLine($"Subtask created {_id} - {_information}");
        }
    }
}