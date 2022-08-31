using System.Runtime.Serialization;

namespace newSectTask
{
    [DataContract]
    public class Subtask
    {
        [DataMember] private string _id;
        [DataMember] private string _information;
        [DataMember] private bool _isCompleted;
        
        public Subtask(string id, string information)
        {
            _id = id;
            _information = information;
            Console.WriteLine($"Subtask created {_id} - {_information}");
        }
        
        private string PrintCompletionStatus()
        {
            return _isCompleted ? "V" : " ";
        }

        public void PrintInformation()
        {
            string statusSubtask = PrintCompletionStatus();
            Console.WriteLine($"[{statusSubtask}] {_id} - {_information}", statusSubtask);
        }

        public void SetCompletedStatus()
        {
            _isCompleted = true;
            Console.WriteLine($"Status {_id} - Performed V");
        }
    }
}