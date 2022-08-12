using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;

namespace TaskManager
{
    partial class Program
    {
        /// <summary>
        /// Вывод списка всех проектов.
        /// </summary>
        private static void GetListOfProjects()
        {
            if (listOfAllProjects.Count > 0)
            {
                Console.WriteLine("\nСписок проектов :");
                for (int i = 0; i < listOfAllProjects.Count; i++)
                {
                    Console.WriteLine($"\n\t{i + 1}. {listOfAllProjects[i].Name}, количество задач = {listOfAllProjects[i].listOfTasks.Count}");
                }
            }
            else
            {
                Console.WriteLine("\nСписок проектов пуст!");
            }
        }

        /// <summary>
        /// Вывод списка всех пользователей.
        /// </summary>
        private static void GetListOfUsers()
        {
            if (listOfAllUsers.Count > 0)
            {
                Console.WriteLine("\nСписок пользователей :");
                for (int i = 0; i < listOfAllUsers.Count; i++)
                {
                    Console.WriteLine($"\n\t{i + 1}. {listOfAllUsers[i].Name}");
                }
            }
            else
            {
                Console.WriteLine("\nСписок пользователей пуст!");
            }
        }

        /// <summary>
        /// Вывод списка всех задач в текущем проекте.
        /// </summary>
        /// <param name="currentProject"> Текущий проект. </param>
        private static void GetListOfTasks(Project currentProject)
        {
            if (currentProject.listOfTasks.Count > 0)
            {
                Console.WriteLine($"\nСписок задач в проекте {currentProject.Name} :");
                for (int i = 0; i < currentProject.listOfTasks.Count; i++)
                {
                    // Получаем тип задачи через GetType().
                    Console.WriteLine($"\n\t{i + 1}. {currentProject.listOfTasks[i].GetType().ToString().Replace("ClassLibrary.","")} " +
                        $"{currentProject.listOfTasks[i].Name}, дата : {currentProject.listOfTasks[i].Date}, " +
                        $"статус : {currentProject.listOfTasks[i].Status}");
                }
            }
            else
            {
                Console.WriteLine($"\nВ проекте {currentProject.Name} нет задач!");
            }
        }

        /// <summary>
        /// Вывод списка исполнителей задачи.
        /// </summary>
        /// <param name="task"> Текущая задача. </param>
        private static void GetListOfImplementer(CommonTasks task)
        {
            if (task.Implementers.Count > 0)
            {
                Console.WriteLine("\nСписок исполнителей задачи :");
                for (int i = 0; i < task.Implementers.Count; i++)
                {
                    Console.WriteLine($"\n\t{i + 1}. {task.Implementers[i].Name}");
                }
            }
            else
            {
                Console.WriteLine("\nСписок исполнителей задачи пуст!");
            }
        }

        /// <summary>
        /// Вывод списка задач с данным статусом.
        /// </summary>
        /// <param name="currentProject"> Текущий проект. </param>
        /// <param name="status"> Статус. </param>
        /// <returns></returns>
        private static List<string> GetListOfTasksByStatus(Project currentProject, string status)
        {
            List<string> listOfStatusTasks = new List<string>();
            if (currentProject.listOfTasks.Count > 0)
            {
                for (int i = 0; i < currentProject.listOfTasks.Count; i++)
                {
                    // Выбираем только задачи с необходимым статусом.
                    if (currentProject.listOfTasks[i].Status == status)
                    {
                        listOfStatusTasks.Add($"\n\t{i + 1}. {currentProject.listOfTasks[i].GetType().ToString().Replace("ClassLibrary.", "")} " +
                            $"{currentProject.listOfTasks[i].Name}, " +
                        $"дата : {currentProject.listOfTasks[i].Date}, статус : {currentProject.listOfTasks[i].Status}");
                    }
                }
                if (listOfStatusTasks.Count > 0)
                {
                    return listOfStatusTasks;
                }
                else
                {
                    Console.WriteLine("\nВ проекте нет задач с выбранным статусом.");
                    return null;
                }
            }
            else
            {
                Console.WriteLine($"\nВ проекте {currentProject.Name} нет задач!");
                return null;
            }
        }

        /// <summary>
        /// Получить список задач определенного типа.
        /// </summary>
        /// <param name="currentProject"> Текцщий проект. </param>
        /// <param name="type"> Тип задачи. </param>
        /// <returns></returns>
        private static List<string> GetListOfTasksByType(Project currentProject, string type)
        {
            List<string> listOfTypeTasks = new List<string>();
            if (currentProject.listOfTasks.Count > 0)
            {
                for (int i = 0; i < currentProject.listOfTasks.Count; i++)
                {
                    // Выбираем только задачи необходимого типа.
                    if (currentProject.listOfTasks[i].GetType().ToString() == "ClassLibrary."+type)
                    {
                        listOfTypeTasks.Add($"\n\t{i + 1}. {currentProject.listOfTasks[i].GetType().ToString().Replace("ClassLibrary.", "")} " +
                            $"{currentProject.listOfTasks[i].Name}, " +
                        $"дата : {currentProject.listOfTasks[i].Date}, статус : {currentProject.listOfTasks[i].Status}");
                    }
                }
                if (listOfTypeTasks.Count > 0)
                {
                    return listOfTypeTasks;
                }
                else
                {
                    Console.WriteLine($"\nВ проекте нет задач типа {type}.");
                    return null;
                }
            }
            else
            {
                Console.WriteLine($"\nВ проекте {currentProject.Name} нет задач!");
                return null;
            }
        }

        /// <summary>
        /// Выбор пользователя из списка через его индекс.
        /// </summary>
        /// <returns></returns>
        private static User SelectUserFromList()
        {
            GetListOfUsers();
            Console.WriteLine($"\nВведите индекс пользователя : ");
            if ((int.TryParse(Console.ReadLine(), out int indexUser)) && (indexUser > 0) && (indexUser <= listOfAllUsers.Count))
            {
                return listOfAllUsers[indexUser - 1];
            }
            else
            {
                Console.WriteLine("\nВведен некорректный индекс.");
                return null;
            }
        }

        /// <summary>
        /// Выбор задачи из списка через ее индекс.
        /// </summary>
        /// <param name="currentProject"></param>
        /// <returns></returns>
        private static CommonTasks SelectTaskFromList(Project currentProject)
        {
            GetListOfTasks(currentProject);
            if (currentProject.listOfTasks.Count > 0)
            {
                Console.WriteLine("\n\nВведите индекс задачи : ");
                if ((int.TryParse(Console.ReadLine(), out int index)) && (index > 0) && (index <= currentProject.listOfTasks.Count))
                {
                    return currentProject.listOfTasks[index - 1];
                }
                else
                {
                    Console.WriteLine("\nВведен некорректный индекс.");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Выбор исполнителя задачи из списка через его индекс.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        private static User SelectImplementerFromList(CommonTasks task)
        {
            GetListOfImplementer(task);
            if (task.Implementers.Count > 0)
            {
                Console.WriteLine("\n\nВведите индекс пользователя : ");
                if ((int.TryParse(Console.ReadLine(), out int index)) && (index > 0) && (index <= task.Implementers.Count))
                {
                    return task.Implementers[index - 1];
                }
                else
                {
                    Console.WriteLine("\nВведен некорректный индекс.");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Выбор проекта из списка через его индекс.
        /// </summary>
        /// <returns></returns>
        private static Project SelectProjectFromList()
        {
            GetListOfProjects();
            Console.WriteLine("\n\nВведите индекс проекта : ");
            if ((int.TryParse(Console.ReadLine(), out int index)) && (index > 0) && (index <= listOfAllProjects.Count))
            {
                return listOfAllProjects[index - 1];
            }
            else
            {
                Console.WriteLine("\nВведен некорректный индекс.");
                return null;
            }
        }

        /// <summary>
        /// Выбор задачи типа Epic из списка через ее индекс.
        /// </summary>
        /// <param name="currentProject"></param>
        /// <returns></returns>
        private static CommonTasks SelectEpicFromList(Project currentProject)
        {
            Console.WriteLine("\n\nВведите индекс : ");
            // Также проверяем, что выбранная задача действительно типа Epic.
            if ((int.TryParse(Console.ReadLine(), out int index)) && (index > 0) && (index <= currentProject.listOfTasks.Count)
                &&(currentProject.listOfTasks[index-1] is Epic))
            {
                return currentProject.listOfTasks[index - 1];
            }
            else
            {
                Console.WriteLine("\nВведен некорректный индекс.");
                return null;
            }
        }
        
        /// <summary>
        /// Выбор задачи типа Story или Task из списка через ее индекс.
        /// </summary>
        /// <param name="currentProject"></param>
        /// <returns></returns>
        private static CommonTasks SelectStoryOrTaskFromList(Project currentProject)
        {
            Console.WriteLine("\n\nВведите индекс : ");
            /// Также проверяем, что задача действительно типа Story или Task.
            if ((int.TryParse(Console.ReadLine(), out int index)) && (index > 0) && (index <= currentProject.listOfTasks.Count)
                && ((currentProject.listOfTasks[index - 1] is Story) || (currentProject.listOfTasks[index - 1] is Task)))
            {
                return currentProject.listOfTasks[index - 1];
            }
            else
            {
                Console.WriteLine("\nВведен некорректный индекс.");
                return null;
            }
        }

        /// <summary>
        /// Создать задачу.
        /// </summary>
        /// <returns></returns>
        private static CommonTasks CreateTask()
        {
            int flag = 0;
            // Выбор типа задачи.
            Console.WriteLine("\nВыберите тип задачи :\n\t[1] Epic\n\t[2] Story\n\t[3] Task\n\t[4] Bug");
            ConsoleKeyInfo key = Console.ReadKey(true);
            while ((key.KeyChar != '1') && (key.KeyChar != '2') && (key.KeyChar != '3') && (key.KeyChar != '4'))
            {
                if (flag != 1)
                {
                    Console.WriteLine("\nВнимание! Нажмите клавишу 1, 2, 3 или 4 соответственно для выбора.");
                    flag++;
                }
                key = Console.ReadKey(true);
            }
            // Получение имени задачи.
            Console.WriteLine("\nВведите имя задачи : ");
            string name = Console.ReadLine();
            // Выбор статуса задачи.
            string status = ChooseStatus();
            CommonTasks createdTask = null;
            if (!string.IsNullOrEmpty(name))
            {
                switch (key.KeyChar)
                {
                    case '1':
                        createdTask = new Epic(name, status);
                        break;
                    case '2':
                        createdTask = new Story(name, status);
                        break;
                    case '3':
                        createdTask = new Task(name, status);
                        break;
                    case '4':
                        createdTask = new Bug(name, status);
                        break;
                }
                Console.WriteLine("\nЗадача создана.");
                return createdTask;
            }
            else
            {
                Console.WriteLine("\nНекорректное имя задачи.");
                return null;
            }
        }

        /// <summary>
        /// Выбор статуса задачи.
        /// </summary>
        /// <returns></returns>
        private static string ChooseStatus()
        {
            int flag = 0;
            // Выбор статуса через нажатие клавиши.
            Console.WriteLine("\nВыберите статус задачи :\n\t[1] Открытая задача\n\t[2] Задача в работе\n\t[3] Завершенная задача\n\t[4] По умолчанию");
            ConsoleKeyInfo key = Console.ReadKey(true);
            while ((key.KeyChar != '1') && (key.KeyChar != '2') && (key.KeyChar != '3') && (key.KeyChar != '4'))
            {
                if (flag != 1)
                {
                    Console.WriteLine("\nВнимание! Нажмите клавишу 1, 2, 3 или 4 соответственно для выбора.");
                    flag++;
                }
                key = Console.ReadKey(true);
            }
            string status = "";
            switch (key.KeyChar)
            {
                case '1':
                    status = "Открытая задача";
                    break;
                case '2':
                    status = "Задача в работе";
                    break;
                case '3':
                    status = "Завершенная задача";
                    break;
                case '4':
                    status = "Открытая задача";
                    break;
            }
            return status;
        }
        
        /// <summary>
        /// Вернуться в основное меню.
        /// </summary>
        private static void ReturnToStart()
        {
            int flag = 0;
            Console.WriteLine("\n[1] Вернуться в основное меню");
            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key.KeyChar != '1')
            {
                if (flag != 1)
                {
                    Console.WriteLine("\nВнимание! Нажмите клавишу 1 для выбора.");
                    flag++;
                }
                key = Console.ReadKey(true);
            }
            switch (key.KeyChar)
            {
                case '1':
                    StartMenu();
                    break;
            }
        }

        /// <summary>
        /// Вернуться в меню задач в проекте.
        /// </summary>
        private static void ReturnToTaskMenu()
        {
            int flag = 0;
            Console.WriteLine("\nВыберите действие :\n\t[1] Вернуться в меню задач в проекте");
            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key.KeyChar != '1')
            {
                if (flag != 1)
                {
                    Console.WriteLine("\nВнимание! Нажмите клавишу 1 для выбора.");
                    flag++;
                }
                key = Console.ReadKey(true);
            }
            switch (key.KeyChar)
            {
                case '1':
                    WorkWithTasks();
                    break;
            }
        }

        /// <summary>
        /// Вернуться в меню задач в проекте или выбрать действие для задачи типа Epic.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="currentProject"></param>
        private static void ReturnOrDoEpicActions(Epic task,Project currentProject)
        {
            int flag = 0;
            Console.WriteLine("\nВыберите действие :\n\t[1] Добавить подзадачу\n\t[2] Удалить подзадачу\n\t[3] Вернуться в меню задач в проекте");
            ConsoleKeyInfo key = Console.ReadKey(true);
            while ((key.KeyChar != '1') && (key.KeyChar != '2') && (key.KeyChar != '3'))
            {
                if (flag != 1)
                {
                    Console.WriteLine("\nВнимание! Нажмите клавишу 1, 2 или 3 соответственно для выбора.");
                    flag++;
                }
                key = Console.ReadKey(true);
            }
            switch (key.KeyChar)
            {
                case '1':
                    AddSubTaskToEpic(task as Epic, currentProject);
                    break;
                case '2':
                    DeleteSubTaskFromEpic(task as Epic,currentProject);
                    break;
                case '3':
                    WorkWithTasks();
                    break;
            }
        }
    }
}
