using System.Runtime.Serialization;

namespace newSectTask
{
    [DataContract]
    public class Data
    { 
        [DataMember]
        private static Dictionary<string, Task> _tasks = new Dictionary<string, Task>();
        [DataMember]
        private static Dictionary<string, TaskGroup> _group = new Dictionary<string, TaskGroup>();

        public Dictionary<string, Task> GetTask()
        {
            return _tasks;
        }

        public Dictionary<string, TaskGroup> GetGroup()
        {
            return _group;
        }
    }
}