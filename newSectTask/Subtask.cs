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
        }

        public void PrintInformation()
        {
            PrintSystem.PrintSubtaskInformation(_isCompleted, _id, _information);
        }

        public void SetCompletedStatus()
        {
            _isCompleted = true;
            PrintSystem.PrintWhenSubtaskSetStatus(_id);
        }
    }
}