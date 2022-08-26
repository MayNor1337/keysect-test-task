using System.Runtime.Serialization;

namespace newSectTask
{
    [DataContract]
    public class Task
    {
        [DataMember]
        private string _id, _information;
        [DataMember]
        private string _completed;
        [DataMember]
        private DateTime _deadLine =  new DateTime();
        [DataMember]
        private static Dictionary<string, Subtask> _subtasks = new Dictionary<string, Subtask>();

        public bool ChekSubtask(string id)
        {
            return _subtasks.ContainsKey(id);
        }

        public bool ChekDate()
        {
            return _deadLine == DateTime.Today;
        }
        
        public void CompletedSubtaskStatus(string id)
        {
            _subtasks[id].CompletedStatus();
        }

        public void AddSubtask(string subtaskId, string subtaskInformation)
        {
            _subtasks[subtaskId] = new Subtask(subtaskId, subtaskInformation);
            Console.WriteLine($"subtask {_id} added to task {subtaskId}");
        }

        public bool SetDeadLine(string deadLine)
        {
            bool f = DateTime.TryParse(deadLine, out _deadLine);
            if(f) Console.WriteLine($"Deadline is set to {deadLine}");
            return f;
            
        }

        public bool СheckComplet()
        {
            return _completed == "V";
        }
        
        public void CompletedStatus()
        {
            _completed = "V";
            Console.WriteLine($"Status {_id} - Performed V");
        }

        public void OutWhenDelete()
        {
            Console.WriteLine($"Task: {_id} - deleted");
        }
        
        public void OutInformation()
        {
            Console.WriteLine($"[{_completed}] {_id} | {_information}");
            if(_deadLine.Date != DateTime.MinValue)
                Console.WriteLine($"\t({_deadLine})");
            foreach (var e in _subtasks)
            {
                Console.Write("\t");
                e.Value.OutInformation();
            }
        }

        public Task(string id, string information, string completed)
        {
            _id = id;
            _information = information;
            _completed = completed;
            Console.WriteLine($"Task created. Id: {_id}");
        }
    }
}