namespace newSectTask
{
    public class PrintSystem
    {
        public static void PrintTaskInformation(bool isCompleted, string id, string information, DateTime deadLine,
            Dictionary<string, Subtask> subtasks)
        {
            string signOfReadiness = (isCompleted ? "V" : " ");
            Console.WriteLine("[{0}] {1} | {2}", signOfReadiness, id, information);
            if (deadLine.Date != DateTime.MinValue)
                Console.WriteLine($"\t({deadLine})");
            foreach (var e in subtasks)
            {
                Console.Write("\t");
                e.Value.PrintInformation();
            }
        }

        public static void PrintWhenTaskCreate(string taskId)
        {
            Console.WriteLine($"Task created. Id: {taskId}");
        }

        public static void PrintWhenDeadline(DateTime deadLine)
        {
            Console.WriteLine($"Deadline is set to {deadLine}");
        }

        public static void PrintWhenDeleteTask(string taskId)
        {
            Console.WriteLine($"Task: {taskId} - deleted");
        }
        
        public static void PrintWhenChangeTaskStatus(string taskId)
        {
            Console.WriteLine($"Status {taskId} - Performed V");
        }

        public static void PrintWhenExport(string path)
        {
            Console.WriteLine($@"The ""data"" file is generated, find it in the {path} folder");
        }

        public static void PrintWhenImport()
        {
            Console.WriteLine("Data replaced");
        }

        public static void PrintWhenTaskGroupCreated(string groupId, string groupName)
        {

            Console.WriteLine($"Created a group {groupId} - {groupName}");
        }

        public static void PrintWhenDeletedTaskFromGroup(string taskId, string groupId, string groupName)
        {
            Console.WriteLine($"Removed task {taskId} from groups {groupId} - {groupName}");
        }

        public static void PrintWhenAddedTaskInGroup(string taskId, string groupId, string groupName)
        {
            Console.WriteLine($"Added task {taskId} to group {groupId} - {groupName}");
        }

        public static void PrintWhenDeletedGroup(string groupId)
        {
            Console.WriteLine($"Group: {groupId} - deleted");
        }

        public static void PrintWhenSubtaskCreated(string subtaskId, string taskId)
        {
            Console.WriteLine($"Subtask {subtaskId} added to task {taskId}");
        }

        public static void PrintSubtaskInformation(bool isCompleted, string taskId, string taskInformation)
        {
            string statusSubtask = isCompleted ? "V" : " ";
            Console.WriteLine($"[{statusSubtask}] {taskId} - {taskInformation}", statusSubtask);
        }

        public static void PrintWhenSubtaskSetStatus(string taskId)
        {
            Console.WriteLine($"Status {taskId} - Performed V");
        }

        public static void PrintError()
        {
            Console.WriteLine("We don't know what you want. YOU WRONG");
        }

        public static void PrintEmptyDateRequest()
        {
            Console.WriteLine("No tasks for today");
        }

        public static void PrintWithUnknownCommand()
        {
            Console.WriteLine("We do not know this command");
        }

        public static void PrintInfo()
        {
            Console.WriteLine("pls w8 this section is under construction");
        }
    }
}