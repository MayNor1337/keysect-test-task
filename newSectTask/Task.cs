using System.Runtime.Serialization;

namespace newSectTask
{
    [DataContract]
    public class Task
    {
        [DataMember] private string _id;
        [DataMember] private string _information;
        [DataMember] private bool _isCompleted;
        [DataMember] private DateTime _deadLine =  new DateTime();
        [DataMember] private static Dictionary<string, Subtask> _subtasks = new Dictionary<string, Subtask>();
        
        public Task(string id, string information)
        {
            _id = id;
            _information = information;
            Console.WriteLine($"Task created. Id: {_id}");
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
            Console.WriteLine($"subtask {_id} added to task {subtaskId}");
        }

        public bool SetDeadLine(string deadLine)
        {
            bool isParsed = DateTime.TryParse(deadLine, out _deadLine);
            if(isParsed) Console.WriteLine($"Deadline is set to {deadLine}");
            return isParsed;
        }

        public bool GetCompletionStatus()
        {
            return _isCompleted;
        }

        public void SetCompletedStatus()
        {
            _isCompleted = true;
            Console.WriteLine($"Status {_id} - Performed V");
        }

        public void PrintWhenDelete()
        {
            Console.WriteLine($"Task: {_id} - deleted");
        }
        
        public void PrintInformation()
        {
            string signOfReadiness = (_isCompleted ? "V" : " ");
            Console.WriteLine("[{0}] {1} | {2}", signOfReadiness, _id, _information);
            if(_deadLine.Date != DateTime.MinValue)
                Console.WriteLine($"\t({_deadLine})");
            foreach (var e in _subtasks)
            {
                Console.Write("\t");
                e.Value.PrintInformation();
            }
        }
    }
}