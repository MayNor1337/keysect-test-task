using System.Runtime.Serialization;

namespace newSectTask
{
    [DataContract]
    public class Task
    {
        [DataMember] private string _id;
        [DataMember] private string _information;
        [DataMember] private bool _isCompleted;
        [DataMember] private DateTime _deadLine;
        [DataMember] private static Dictionary<string, Subtask> _subtasks = new Dictionary<string, Subtask>();
        
        public Task(string id, string information)
        {
            _id = id;
            _information = information;
        }

        public bool IsSubtaskExists(string id)
        {
            return _subtasks.ContainsKey(id);
        }

        public bool IsTodayDate()
        {
            return _deadLine == DateTime.Today;
        }
        
        public void SetCompletedSubtaskStatus(string id)
        {
            _subtasks[id].SetCompletedStatus();
        }

        public void AddSubtask(string subtaskId, string subtaskInformation)
        {
            _subtasks[subtaskId] = new Subtask(subtaskId, subtaskInformation);
        }

        public bool SetDeadLine(string deadLine)
        {
            bool isParsed = DateTime.TryParse(deadLine, out _deadLine);
            if(isParsed) PrintSystem.PrintWhenDeadline(_deadLine);
            return isParsed;
        }

        public bool GetCompletionStatus()
        {
            return _isCompleted;
        }

        public void SetCompletedStatus()
        {
            _isCompleted = true;
        }

        public void PrintInformation()
        {
            PrintSystem.PrintTaskInformation(_isCompleted, _id, _information, _deadLine, _subtasks);
        }
    }
}