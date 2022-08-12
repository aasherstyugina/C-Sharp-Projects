using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;
using System.IO;

namespace TaskManager
{
    partial class Program
    {
        /// <summary>
        /// Сохранение всей информации при выходе из программы.
        /// </summary>
        private static void AutoSave()
        {
            // Создаем папку projects, если она уже существует - удаляем и создаем пустую.
            if (Directory.Exists("projects"))
            {
                Directory.Delete("projects", true);
            }
            Directory.CreateDirectory("projects");
            foreach (Project project in listOfAllProjects)
            {
                // Для каждого проекта создаем папку с его именем.
                Directory.CreateDirectory(Path.Combine("projects", project.Name));
                // В каждой папке проекта создаем файл max и записываем в него максимальное количество задач в проекте.
                File.WriteAllText(Path.Combine("projects", project.Name, "max"), $"{project.MaxNumOfTasks}");
                foreach (CommonTasks task in project.listOfTasks)
                {
                    // В каждой папке проекта создаем папки с именем каждой из задач, содержащихся в данном проекте.
                    Directory.CreateDirectory(Path.Combine("projects", project.Name, task.Name));
                    // В папке задачи в файлах date, status, type и implementers записываем соответствующую информацию о задаче.
                    File.WriteAllText(Path.Combine("projects", project.Name, task.Name, "date"), $"{task.Date}");
                    File.WriteAllText(Path.Combine("projects", project.Name, task.Name, "status"), $"{task.Status}");
                    File.WriteAllText(Path.Combine("projects", project.Name, task.Name, "type"), $"{task.GetType().ToString().Replace("ClassLibrary.", "")}");
                    for (int i = 0; i < task.Implementers.Count; i++)
                    {
                        if (i != task.Implementers.Count - 1)
                        {
                            File.AppendAllText(Path.Combine("projects", project.Name, task.Name, "implementers"), $"{task.Implementers[i].Name}\n");
                        }
                        else
                        {
                            File.AppendAllText(Path.Combine("projects", project.Name, task.Name, "implementers"), $"{task.Implementers[i].Name}");
                        }
                    }
                }
            }
            // Создаем папку users, если она уже существует - удаляем и создаем пустую.
            if (Directory.Exists("users"))
            {
                Directory.Delete("users", true);
            }
            Directory.CreateDirectory("users");
            // В папке создаем файл list и записываем в него информацию о всех пользователях.
            for(int i = 0; i < listOfAllUsers.Count; i++)
            {
                if (i != listOfAllUsers.Count - 1)
                {
                    File.AppendAllText(Path.Combine("users", "list"), $"{listOfAllUsers[i].Name}\n");
                }
                else
                {
                    File.AppendAllText(Path.Combine("users", "list"), $"{listOfAllUsers[i].Name}");
                }
            }
        }

        /// <summary>
        /// Загрузка сохраненной информации при запуске приложения.
        /// </summary>
        static void LoadInfo()
        {
            try
            {
                LoadUsers();
                LoadProjects();
            }
            catch
            {
                Console.WriteLine("\nОшибка сохранения данных.");
            }
        }

        /// <summary>
        /// Загрузка сохраненных проектов и их содержимого.
        /// </summary>
        private static void LoadProjects()
        {
            if (Directory.Exists("projects"))
            {
                string[] projects = Directory.GetDirectories("projects");
                foreach (string path in projects)
                {
                    // Получаем название каждой папки проекта = названию проекта и максимальное количество задач из файла max в данной папке, создаем проект.
                    string name = path.Replace(Path.GetDirectoryName(path), "");
                    Project newProject = new Project(name[1..], int.Parse(File.ReadAllText(Path.Combine(path, "max"))));
                    listOfAllProjects.Add(newProject);
                    string[] tasks = Directory.GetDirectories(path);
                    foreach (string taskPath in tasks)
                    {
                        // Получаем название каждой задачи в проекте и всю информацию о ней из файлов status, type, date. Создаем задачу и добавляем в проект.
                        string nameTask = taskPath.Replace(Path.GetDirectoryName(taskPath), "");
                        string status = File.ReadAllText(Path.Combine(taskPath, "status"));
                        string type = File.ReadAllText(Path.Combine(taskPath, "type"));
                        string date = File.ReadAllText(Path.Combine(taskPath, "date"));
                        CommonTasks newTask = null;
                        switch (type)
                        {
                            case "Epic":
                                newTask = new Epic(nameTask[1..], status);
                                break;
                            case "Story":
                                newTask = new Story(nameTask[1..], status);
                                break;
                            case "Task":
                                newTask = new Task(nameTask[1..], status);
                                break;
                            case "Bug":
                                newTask = new Bug(nameTask[1..], status);
                                break;
                        }
                        newTask.Date = DateTime.Parse(date);
                        newProject.listOfTasks.Add(newTask);
                        // Каждого исполнителя ищем по имени в списке всех пользователей и назначаем для данной задачи.
                        if(File.Exists(Path.Combine(taskPath, "implementers")))
                        {
                            string[] implementers = File.ReadAllLines(Path.Combine(taskPath, "implementers"));
                            foreach (string user in implementers)
                            {
                                int i = 0;
                                while (i < listOfAllUsers.Count)
                                {
                                    if (listOfAllUsers[i].Name == user)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        i++;
                                    }
                                }
                                newTask.Implementers.Add(listOfAllUsers[i]);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Закгрузка информации о пользователях.
        /// </summary>
        private static void LoadUsers()
        {
            if (Directory.Exists("users"))
            {
                // Из файла list в папке users получаем имена пользователей, создаем их и добавляем в список.
                string[] users = File.ReadAllLines(Path.Combine("users", "list"));
                foreach(string user in users)
                {
                    listOfAllUsers.Add(new User(user));
                }
            }
        }
    }
}
