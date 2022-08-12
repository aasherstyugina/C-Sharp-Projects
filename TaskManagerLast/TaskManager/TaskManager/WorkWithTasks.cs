using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;

namespace TaskManager
{
    partial class Program
    {
        /// <summary>
        /// Меню задач в проекте.
        /// </summary>
        private static void WorkWithTasks()
        {
            Console.Clear();
            Note();
            int flag = 0;
            Project project = SelectProjectFromList();
            if (project!=null)
            {
                Console.WriteLine("\nМеню задач в проекте :\n\n\t[1] Добавить новую задачу\n\t[2] Назначить исполнителя задачи" +
                " \n\t[3] Изменить исполнителя задачи\n\t[4] Удалить исполнителя из задачи\n\t[5] Изменить статус задачи\n\t[6] Просмотр списка задач" +
                " \n\t[7] Группировка задач по статусу\n\t[8] Удалить задачу\n\t[9] Действия с Epic\n\t[0] Вернуться в основное меню");
                ConsoleKeyInfo key = Console.ReadKey(true);
                while ((key.KeyChar != '1') && (key.KeyChar != '2') && (key.KeyChar != '3') && (key.KeyChar != '4') && (key.KeyChar != '5')
                    && (key.KeyChar != '6') && (key.KeyChar != '7') && (key.KeyChar != '8') && (key.KeyChar != '9') && (key.KeyChar != '0'))
                {
                    if (flag != 1)
                    {
                        Console.WriteLine("\nВнимание! Нажмите клавишу 0-9 соответственно для выбора.");
                        flag++;
                    }
                    key = Console.ReadKey(true);
                }
                switch (key.KeyChar)
                {
                    case '1':
                        AddTaskToProject(project);
                        break;
                    case '2':
                        ChooseImplementer(project);
                        break;
                    case '3':
                        ChangeImplementer(project);
                        break;
                    case '4':
                        DeleteImplementer(project);
                        break;
                    case '5':
                        ChangeTaskStatus(project);
                        break;
                    case '6':
                        ShowAllTasks(project);
                        break;
                    case '7':
                        SelectTasksByStatus(project);
                        break;
                    case '8':
                        DeleteTask(project);
                        break;
                    case '9':
                        ActionsWithEpic(project);
                        break;
                    case '0':
                        StartMenu();
                        break;
                }
            }
            ReturnToStart();
        }

        /// <summary>
        /// Добавить задачу в проект.
        /// </summary>
        /// <param name="currentProject"> Текущий проект. </param>
        private static void AddTaskToProject(Project currentProject)
        {
            Console.Clear();
            Note();
            int flag = 0;
            // Создать и добавить задачу в проект.
            currentProject.AddTask(CreateTask());
            // Повтор действия или возврат в меню.
            Console.WriteLine("\nВыберите действие :\n\t[1] Добавить задачу в проект\n\t[2] Вернуться в меню задач в проекте");
            ConsoleKeyInfo key = Console.ReadKey(true);
            while ((key.KeyChar != '1') && (key.KeyChar != '2'))
            {
                if (flag != 1)
                {
                    Console.WriteLine("\nВнимание! Нажмите клавишу 1 или 2 соответственно для выбора.");
                    flag++;
                }
                key = Console.ReadKey(true);
            }
            switch (key.KeyChar)
            {
                case '1':
                    AddTaskToProject(currentProject);
                    break;
                case '2':
                    WorkWithTasks();
                    break;
            }
        }

        /// <summary>
        /// Назначить исполнителя задачи.
        /// </summary>
        /// <param name="currentProject"> Текущий проект. </param>
        private static void ChooseImplementer(Project currentProject)
        {
            Console.Clear();
            Note();
            int flag = 0;
            // Выбор задачи и проверка, что она не является типом Epic.
            CommonTasks task = SelectTaskFromList(currentProject);
            if (task != null)
            {
                if (task is Epic)
                {
                    Console.WriteLine($"\nЗадача {task.Name} имеет тип Epic, у нее не может быть исполнителей.");
                }
                else
                {
                    // Проверка, что количество исполнителей не превышает допустимое количество.
                    if ((((task is Task) || (task is Bug)) && (task.Implementers.Count < 1)) || (task is Story))
                    {
                        User implementer = SelectUserFromList();
                        if (implementer != null)
                        {
                            task.AppointImplementer(implementer);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\nДля задачи {task.Name} не может быть назначен новый исполнитель.");
                    }
                }
            }
            // Повтор действия или возврат в меню.
            Console.WriteLine("\nВыберите действие :\n\t[1] Назначить исполнителя для задачи\n\t[2] Вернуться в меню задач в проекте");
            ConsoleKeyInfo key = Console.ReadKey(true);
            while ((key.KeyChar != '1') && (key.KeyChar != '2'))
            {
                if (flag != 1)
                {
                    Console.WriteLine("\nВнимание! Нажмите клавишу 1 или 2 соответственно для выбора.");
                    flag++;
                }
                key = Console.ReadKey(true);
            }
            switch (key.KeyChar)
            {
                case '1':
                    ChooseImplementer(currentProject);
                    break;
                case '2':
                    WorkWithTasks();
                    break;
            }
        }

        /// <summary>
        /// Изменить исполнителя задачи.
        /// </summary>
        /// <param name="currentProject"> Текущий проект. </param>
        private static void ChangeImplementer(Project currentProject)
        {
            Console.Clear();
            Note();
            int flag = 0;
            CommonTasks task = SelectTaskFromList(currentProject);
            if (task != null)
            {
                Console.WriteLine("\nВыбор пользователя из списка исполнителей задачи : ");
                User firstUser = SelectImplementerFromList(task);
                if (firstUser != null)
                {
                    Console.WriteLine("\n Выбор пользователя из списка всех пользователей :");
                    User secondUser = SelectUserFromList();
                    if(secondUser!=null)
                    {
                        task.ChangeImplementers(task.Implementers.IndexOf(firstUser), secondUser);
                        Console.WriteLine("\nИсполнитель заменен на выбранного пользователя из общего списка.");
                    }
                }
            }
            // Повтор действия или возврат в меню.
            Console.WriteLine("\nВыберите действие :\n\t[1] Изменить исполнителя задачи\n\t[2] Вернуться в меню задач в проекте");
            ConsoleKeyInfo key = Console.ReadKey(true);
            while ((key.KeyChar != '1') && (key.KeyChar != '2'))
            {
                if (flag != 1)
                {
                    Console.WriteLine("\nВнимание! Нажмите клавишу 1 или 2 соответственно для выбора.");
                    flag++;
                }
                key = Console.ReadKey(true);
            }
            switch (key.KeyChar)
            {
                case '1':
                    ChangeImplementer(currentProject);
                    break;
                case '2':
                    WorkWithTasks();
                    break;
            }
        }
        
        /// <summary>
        /// Удалить исполнителя задачи.
        /// </summary>
        /// <param name="currentProject"> Текущий проект. </param>
        private static void DeleteImplementer(Project currentProject)
        {
            Console.Clear();
            Note();
            int flag = 0;
            CommonTasks task = SelectTaskFromList(currentProject);
            if (task != null)
            {
                User user = SelectImplementerFromList(task);
                if (user != null)
                {
                    task.DeleteImplementer(task.Implementers.IndexOf(user));
                    Console.WriteLine("\nПользователь удален.");
                }
            }
            // Повтор действия или возврат в меню.
            Console.WriteLine("\nВыберите действие :\n\t[1] Удалить исполнителя задачи\n\t[2] Вернуться в меню задач в проекте");
            ConsoleKeyInfo key = Console.ReadKey(true);
            while ((key.KeyChar != '1') && (key.KeyChar != '2'))
            {
                if (flag != 1)
                {
                    Console.WriteLine("\nВнимание! Нажмите клавишу 1 или 2 соответственно для выбора.");
                    flag++;
                }
                key = Console.ReadKey(true);
            }
            switch (key.KeyChar)
            {
                case '1':
                    DeleteImplementer(currentProject);
                    break;
                case '2':
                    WorkWithTasks();
                    break;
            }
        }

        /// <summary>
        /// Изменить статус задачи.
        /// </summary>
        /// <param name="currentProject"></param>
        private static void ChangeTaskStatus(Project currentProject)
        {
            Console.Clear();
            Note();
            int flag = 0;
            CommonTasks task = SelectTaskFromList(currentProject);
            if (task != null)
            {
                // Выбор нового статуса.
                string status = ChooseStatus();
                task.Status = status;
                Console.WriteLine("\nСтатус задачи изменен.");
            }
            // Повтор действия или возврат в меню.
            Console.WriteLine("\nВыберите действие :\n\t[1] Изменить статус задачи\n\t[2] Вернуться в меню задач в проекте");
            ConsoleKeyInfo key = Console.ReadKey(true);
            while ((key.KeyChar != '1') && (key.KeyChar != '2'))
            {
                if (flag != 1)
                {
                    Console.WriteLine("\nВнимание! Нажмите клавишу 1 или 2 соответственно для выбора.");
                    flag++;
                }
                key = Console.ReadKey(true);
            }
            switch (key.KeyChar)
            {
                case '1':
                    ChangeTaskStatus(currentProject);
                    break;
                case '2':
                    WorkWithTasks();
                    break;
            }
        }

        /// <summary>
        /// Показать список задач.
        /// </summary>
        /// <param name="currentProject"> Текущий проект. </param>
        private static void ShowAllTasks(Project currentProject)
        {
            Console.Clear();
            Note();
            GetListOfTasks(currentProject);
            ReturnToTaskMenu();
        }

        /// <summary>
        /// Показать задачи с выбранным статусом.
        /// </summary>
        /// <param name="currentProject"> Текущий проект. </param>
        private static void SelectTasksByStatus(Project currentProject)
        {
            Console.Clear();
            Note();
            // Выбор статуса.
            string status = ChooseStatus();
            List<string> listOfStatusTasks = GetListOfTasksByStatus(currentProject, status);
            foreach(string item in listOfStatusTasks)
            {
                Console.WriteLine(item);
            }
            ReturnToTaskMenu();
        }

        /// <summary>
        /// Удалить задачу из проекта.
        /// </summary>
        /// <param name="currentProject"> Текущий проект. </param>
        private static void DeleteTask(Project currentProject)
        {
            Console.Clear();
            Note();
            int flag = 0;
            CommonTasks task = SelectTaskFromList(currentProject);
            if (task != null)
            {
                currentProject.DeleteTask(currentProject.listOfTasks.IndexOf(task));
                Console.WriteLine("\nЗадача удалена.");
            }
            // Повтор действия или возврат в меню.
            Console.WriteLine("\nВыберите действие :\n\t[1] Удалить задачу\n\t[2] Вернуться в меню задач в проекте");
            ConsoleKeyInfo key = Console.ReadKey(true);
            while ((key.KeyChar != '1') && (key.KeyChar != '2'))
            {
                if (flag != 1)
                {
                    Console.WriteLine("\nВнимание! Нажмите клавишу 1 или 2 соответственно для выбора.");
                    flag++;
                }
                key = Console.ReadKey(true);
            }
            switch (key.KeyChar)
            {
                case '1':
                    DeleteTask(currentProject);
                    break;
                case '2':
                    WorkWithTasks();
                    break;
            }
        }
        
        /// <summary>
        /// Действия с задачами типа Epic.
        /// </summary>
        /// <param name="currentProject"></param>
        private static void ActionsWithEpic(Project currentProject)
        {
            Console.Clear();
            Note();
            List<string> listOfEpicTasks = GetListOfTasksByType(currentProject, "Epic");
            if (listOfEpicTasks != null)
            {
                Console.WriteLine("\nЗадачи типа Epic : ");
                foreach (string item in listOfEpicTasks)
                {
                    Console.WriteLine(item);
                }
                CommonTasks task = SelectEpicFromList(currentProject);
                if (task != null)
                {
                    ReturnOrDoEpicActions(task as Epic, currentProject);
                }
            }
            ReturnToTaskMenu();
        }

        /// <summary>
        /// Добавить подзадачу.
        /// </summary>
        /// <param name="task"> Задача типа Epic. </param>
        /// <param name="currentProject"> Текущий проект. </param>
        private static void AddSubTaskToEpic(Epic task, Project currentProject)
        {
            // Список задач типа Story.
            List<string> listOfStoryTasks = GetListOfTasksByType(currentProject, "Story");
            if (listOfStoryTasks != null)
            {
                Console.WriteLine("\nЗадачи типа Story : ");
                foreach (string item in listOfStoryTasks)
                {
                    Console.WriteLine(item);
                }
                // Список задач типа Task.
                List<string> listOfTaskTasks = GetListOfTasksByType(currentProject, "Task");
                if (listOfTaskTasks != null)
                {
                    Console.WriteLine("\nЗадачи типа Task : ");
                    foreach (string item in listOfStoryTasks)
                    {
                        Console.WriteLine(item);
                    }
                    CommonTasks subTask = SelectStoryOrTaskFromList(currentProject);
                    if (subTask != null)
                    {
                        task.AddSubTask(subTask);
                        Console.WriteLine("\nПодзадача добавлена.");
                    }
                }
            }
            ReturnOrDoEpicActions(task,currentProject);
        }

        /// <summary>
        /// Удалить подзадачу.
        /// </summary>
        /// <param name="task"> Задача типа Epic. </param>
        /// <param name="currentProject"> Текущий проект. </param>
        private static void DeleteSubTaskFromEpic(Epic task, Project currentProject)
        {
            if (task.subTasks.Count > 0)
            {
                Console.WriteLine("\nСписок подзадач :");
                for (int i = 0; i < task.subTasks.Count; i++)
                {
                    Console.WriteLine($"\n\t{i + 1}. {task.subTasks[i].GetType().ToString().Replace("ClassLibrary.", "")} {task.subTasks[i].Name}, " +
                        $"дата : {task.subTasks[i].Date}, статус : {task.subTasks[i].Status}");
                    CommonTasks subTask = SelectStoryOrTaskFromList(currentProject);
                    if (subTask != null)
                    {
                        task.DeleteSubTask(task.subTasks.IndexOf(subTask));
                        Console.WriteLine("\nПодзадача удалена.");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nСписок подзадач пуст!");
            }
            ReturnOrDoEpicActions(task, currentProject);
        }
    }
}
