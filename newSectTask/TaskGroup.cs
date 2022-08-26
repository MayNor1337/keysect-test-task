using System.Runtime.Serialization;

namespace newSectTask
{
    [DataContract]
    public class TaskGroup
    {
        [DataMember]
        private string _id, _name;
        [DataMember]
        private List<string> _taskInGroup = new List<string>();

        public List<string> ReturnListTasks()
        {
            Console.WriteLine($"group {_id} - {_name}:");
            return _taskInGroup;
        }

        public void DeleteTask(string taskId)
        {
            _taskInGroup.Remove(taskId);
            Console.WriteLine($"Removed task {taskId} from groups {_id} - {_name}");
        }

        public void AddTask(string taskId)
        {
            _taskInGroup.Add(taskId);
            Console.WriteLine($"Added task {taskId} to group {_id} - {_name}");
        }
        
        public void OutWhenDelete()
        {
            Console.WriteLine($"Group: {_id}, {_name} - deleted");
        }

        public TaskGroup(string id, string name)
        {
            _id = id;
            _name = name;
            Console.WriteLine($"Created a group {_id} - {_name}");
        }
    }
}