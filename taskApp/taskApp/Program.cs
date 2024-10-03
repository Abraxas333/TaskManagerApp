// See https://aka.ms/new-console-template for more information


using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main() {
        Dictionary<int, string> taskMap = new Dictionary<int, string>();
        bool loop = true;
        
        while (loop) {
            Console.WriteLine("Please input add for adding a new Task.\nInput all for viewing all tasks.\nInput update for viewing a specific task.\nInput del for deleting a specific task.\nPress any key for exiting the Program.");
            var input = Console.ReadLine();
            switch (input)
            {
                case "add":
                    Console.WriteLine("Plese input Task and press enter to submit.");
                    string task = Console.ReadLine();
                    int taskId = 0;
                    foreach (var key in taskMap.Keys) {
                        if (key > taskId) taskId = key;
                    }
                    taskId += 1;
                    taskMap.Add(taskId, task);
                    break;

                case "all":
                    foreach (KeyValuePair<int, string> entry in taskMap)
                    {
                        Console.WriteLine("Task: {0}, {1}", entry.Key, entry.Value);
                    }
                    break;

                case "update":
                    foreach (var key in taskMap.Keys)
                    {
                        Console.WriteLine(key);
                    }
                    int id;
                    do
                    {
                        Console.WriteLine("Input task ID for viewing task:");
                        var idInput = Console.ReadLine();
                      
                        if (int.TryParse(idInput, out id) && taskMap.ContainsKey(id))
                        {
                            task = taskMap[id];
                            Console.WriteLine($"Task: {task}");
                            Console.WriteLine($"Enter update for task {id}");
                            taskMap[id] = Console.ReadLine();  
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid task ID.");
                        }
                    } while (!taskMap.ContainsKey(id)) ;
                    break;

                case "del":
                    int idDel;
                    foreach (var key in taskMap.Keys)
                    {
                        Console.WriteLine(key);
                    }
                    do
                    {
                        Console.WriteLine("input task id for deleting task:");
                        var Idinput = Console.ReadLine();
                        if (int.TryParse(Idinput, out idDel) && taskMap.ContainsKey(idDel))
                        {
                            taskMap.Remove(idDel);
                            Console.WriteLine($"Removed No {idDel} from tasks");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Pleae enter a valid task ID.");
                        }
                    } while (taskMap.ContainsKey(idDel));

                    int count = taskMap.Count;
                    Dictionary<int, string> dict = new Dictionary<int, string>();

                    foreach (var index in Enumerable.Range(0, taskMap.Count))
                    {
                        var taskValue = taskMap.ElementAt(index).Value;
                       
                        dict.Add(index +1, taskValue);
                    }
                    taskMap = dict;

                    break;

                default:
                    loop = false;
                    break;
            }
        }

    }

}



