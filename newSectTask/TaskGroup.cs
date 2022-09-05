using System.Runtime.Serialization;

namespace newSectTask
{
    [DataContract]
    public class TaskGroup
    {
        [DataMember] private string _id;
        [DataMember] private string _name;
        [DataMember] private List<string> _incomingTasks = new List<string>();
        
        public TaskGroup(string id, string name)
        {
            _id = id;
            _name = name;
            PrintSystem.PrintWhenTaskGroupCreated(id, name);
        }

        public List<string> GetTasks()
        {
            Console.WriteLine($"group {_id} - {_name}:");
            return _incomingTasks;
        }

        public void DeleteTask(string taskId)
        {
            _incomingTasks.Remove(taskId);
            PrintSystem.PrintWhenDeletedTaskFromGroup(taskId, _id, _name);
        }

        public void AddTask(string taskId)
        {
            _incomingTasks.Add(taskId);
            PrintSystem.PrintWhenAddedTaskInGroup(taskId,_id, _name);
        }
    }
}