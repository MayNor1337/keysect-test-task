namespace newSectTask
{
    public static class InputSystem
    {
        private static Data _data = new Data();

        private static void PrintError()
        {
            Console.WriteLine("We don't know what you want. YOU WRONG");
        }

        private static void PrintInformation(string key)
        {
            _data.GetTask()[key].PrintInformation();
        }

        private static bool CreateCommands(string[] commands)
        {
            if (commands[0] == "/create-task")
            {
                string idTask = commands[1];
                string information = (commands.Length > 2 ? commands[2] : "no information");
                _data.GetTask()[idTask] = new Task(idTask, information);
                return true;
            }
            
            if (commands[0] == "/create-group")
            {
                string idGroup = commands[1], name = (commands.Length > 2 ? commands[2] : "no name");
                _data.GetGroup()[idGroup] = new TaskGroup(idGroup, name);
                return true;
            }

            return false;
        }

        private static void CommandsInOneWord(string[] commands)
        {
            switch (commands[0])
            {
                case  "/info":
                    Console.WriteLine("pls w8 this section is under construction");
                    break;
                case "/list-task":
                    foreach (var e in _data.GetTask())
                    {
                        PrintInformation(e.Key);
                    }
                    break;
                case "/completed-tasks":
                    foreach (var e in _data.GetTask())
                        if(e.Value.GetCompletionStatus())
                            PrintInformation(e.Key);
                    break;
                case "/list-group":
                    foreach (var e in _data.GetGroup())
                    {
                        List<string> taskInGroup = e.Value.GetTasks();
                        foreach (var i in taskInGroup)
                        {
                            Console.Write("\t");
                            PrintInformation(i);
                        }
                    }
                    break;
                case "/tasks-for-today":
                    bool flag = true;
                    foreach (var e in _data.GetTask())
                    {
                        if (e.Value.IsTodayDate())
                        {
                            e.Value.PrintInformation();
                            flag = false;
                        }
                    }
                    if(flag)
                        Console.WriteLine("No tasks for today");
                    break;
                default:
                    Console.WriteLine("We do not know this command");
                    break;
            }
        }

        private static bool CommandsWithTasks(string[] commands)
        {
            if (!_data.GetTask().ContainsKey(commands[1]))
                return false;
            
            switch (commands[0])
            {
                case "/delete-task":
                    _data.GetTask()[commands[1]].PrintWhenDelete();
                    _data.GetTask().Remove(commands[1]);
                    break;
                case "/change-status-task":
                    _data.GetTask()[commands[1]].SetCompletedStatus();
                    break;
                case "/set-deadline":
                    string date = null;
                    for (int i = 2; i < commands.Length; i++)
                        date += commands[i];
                    if (!_data.GetTask()[commands[1]].SetDeadLine(date))
                        return false;
                    break;
                case "/add": //Task - Group
                    if (_data.GetGroup().ContainsKey(commands[2]))
                    {
                        _data.GetGroup()[commands[2]].AddTask(commands[1]);
                    }
                    else
                        return false;
                    break;
                case "/delete-task-from-group": //Task - Group
                    if (commands.Length > 2 & _data.GetGroup().ContainsKey(commands[2]))
                        _data.GetGroup()[commands[2]].DeleteTask(commands[1]);
                    else
                        return false;
                    break;
                case "/add-subtask": // task - idSubtask - informationSubtask
                    string information = commands.Length > 3 ? commands[3] : "No information";
                    _data.GetTask()[commands[1]].AddSubtask(commands[2], information);
                    break;
                case "/completed-subtask": // taskId - subtaskId
                    if (commands.Length > 2 & _data.GetTask()[commands[1]].IsSubtaskExists(commands[2]))
                        _data.GetTask()[commands[1]].SetCompletedSubtaskStatus(commands[2]);
                    else
                        return false;
                    break;
                default:
                    return false;
            }
            
            return true;
        }

        private static bool DataCommands(string[] commands)
        {
            string path = "";
            
            if (commands.Length >= 2)
            {
                for (int i =1; i < commands.Length; i++)
                {
                    path += commands[i];
                }
            }

            switch (commands[0])
            {
                case "/export":
                    DataSaver.CreateExportFile(_data, path);
                    break;
                case "/import":
                    if (DataReader.Import(path) != null)
                    {
                        _data = DataReader.Import(path);
                        Console.WriteLine("Data replaced");
                    }
                    else
                        return false;
                    break;
                default:
                    return false;
            }

            return true;
        }

        private static bool CommandsWithGroup(string[] commands)
        {
            if (!_data.GetGroup().ContainsKey(commands[1]))
                return false;
            
            switch (commands[0])
            {
                case "/delete-group":
                    _data.GetGroup()[commands[1]].PrintWhenDelete();
                    _data.GetGroup().Remove(commands[1]);
                    break;
                default:
                    return false;
            }

            return true;
        }

        private static void ProcessingInput(string[] commands)
        {
            if(commands.Length == 1)
            {
                CommandsInOneWord(commands);
                return;
            }

            if (CommandsWithGroup(commands) == false & CommandsWithTasks(commands) == false 
                                                     & CreateCommands(commands) == false & DataCommands(commands))
            {
                PrintError();
            }
        }

        public static void ReadingInput()
        {
            while (true)
            {
                ProcessingInput(Console.ReadLine().Split(' '));
            }
        }

}
}