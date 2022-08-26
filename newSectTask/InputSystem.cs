﻿namespace newSectTask
{
    public static class InputSystem
    {
        private static Data _data = new Data();

        private static void OutputOnError()
        {
            Console.WriteLine("We don't know what you want. YOU WRONG");
        }

        private static void InformationOut(string key)
        {
            _data.GetTask()[key].OutInformation();
        }

        private static bool CreateCommands(string[] commands)
        {
            if (commands[0] == "/create-task")
            {
                string idTask = commands[1];
                string information = (commands.Length > 2 ? commands[2] : "no information");
                string completed = (commands.Length > 3 ? commands[3] : " ");
                _data.GetTask()[idTask] = new Task(idTask, information, completed);
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
                case "/export":
                    ImportExport.CreateExportFile(_data);
                    break;
                case "/import":
                    _data = ImportExport.Import();
                    break;
                case "/list-task":
                    foreach (var e in _data.GetTask())
                    {
                        InformationOut(e.Key);
                    }
                    break;
                case "/completed-tasks":
                    foreach (var e in _data.GetTask())
                        if(e.Value.СheckComplet())
                            InformationOut(e.Key);
                    break;
                case "/list-group":
                    foreach (var e in _data.GetGroup())
                    {
                        List<string> taskInGroup = e.Value.ReturnListTasks();
                        foreach (var i in taskInGroup)
                        {
                            Console.Write("\t");
                            InformationOut(i);
                        }
                    }
                    break;
                case "/tasks-for-today":
                    bool flag = true;
                    foreach (var e in _data.GetTask())
                    {
                        if (e.Value.ChekDate())
                        {
                            e.Value.OutInformation();
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
                    _data.GetTask()[commands[1]].OutWhenDelete();
                    _data.GetTask().Remove(commands[1]);
                    break;
                case "/change-status-task":
                    _data.GetTask()[commands[1]].CompletedStatus();
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
                    if (commands.Length > 2 & _data.GetTask()[commands[1]].ChekSubtask(commands[2]))
                        _data.GetTask()[commands[1]].CompletedSubtaskStatus(commands[2]);
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
                    _data.GetGroup()[commands[1]].OutWhenDelete();
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
                                                     & CreateCommands(commands) == false)
            {
                OutputOnError();
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