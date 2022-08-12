using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;

namespace TaskManager
{
    partial class Program
    {
        /// <summary>
        /// Меню проектов.
        /// </summary>
        private static void WorkWithProjects()
        {
            Console.Clear();
            Note();
            int flag = 0;
            Console.WriteLine("\nМеню проектов :\n\n\t[1] Создание проекта\n\t[2] Просмотр списка проектов" +
                " \n\t[3] Изменение названия проекта\n\t[4] Удаление проекта\n\t[5] Вернуться в основное меню");
            ConsoleKeyInfo key = Console.ReadKey(true);
            while ((key.KeyChar != '1') && (key.KeyChar != '2') && (key.KeyChar != '3') && (key.KeyChar != '4') && (key.KeyChar != '5'))
            {
                if (flag != 1)
                {
                    Console.WriteLine("\nВнимание! Нажмите клавишу 1, 2, 3, 4 или 5 соответственно для выбора.");
                    flag++;
                }
                key = Console.ReadKey(true);
            }
            switch (key.KeyChar)
            {
                case '1':
                    AddProject();
                    break;
                case '2':
                    ShowAllProjects();
                    break;
                case '3':
                    ChangeProjectName();
                    break;
                case '4':
                    DeleteProject();
                    break;
                case '5':
                    StartMenu();
                    break;
            }
        }

        /// <summary>
        /// Создать проект.
        /// </summary>
        private static void AddProject()
        {
            Console.Clear();
            Note();
            int flag = 0;
            // Получение имени и максимального количества задач в проекте, создание проекта.
            Console.WriteLine("\nВведите имя проекта: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nВведите максимальное число задач в проекте (>=0 и <=500) : ");
            if ((!string.IsNullOrEmpty(name)) && (int.TryParse(Console.ReadLine(), out int maxNumOfTasks)) && (maxNumOfTasks >= 0) && (maxNumOfTasks <= 500))
            {
                listOfAllProjects.Add(new Project(name, maxNumOfTasks));
                Console.WriteLine($"\nПроект {name} добавлен в общий список.");
            }
            else
            {
                Console.WriteLine("\nНекорректное имя проекта или максимальное число задач в нем. Он не будет добавлен.");
            }
            // Повтор действия или возврат в меню.
            Console.WriteLine("\nВыберите действие :\n\t[1] Добавить проект \n\t[2] Вернуться в меню проектов");
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
                    AddProject();
                    break;
                case '2':
                    WorkWithProjects();
                    break;
            }
        }

        /// <summary>
        /// Показать список проектов.
        /// </summary>
        private static void ShowAllProjects()
        {
            Console.Clear();
            Note();
            int flag = 0;
            GetListOfProjects();
            // Повтор действия или возврат в меню.
            Console.WriteLine("\n[1] Вернуться в меню проектов");
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
                    WorkWithProjects();
                    break;
            }
        }

        /// <summary>
        /// Удалить проект.
        /// </summary>
        private static void DeleteProject()
        {
            Console.Clear();
            Note();
            int flag = 0;
            GetListOfProjects();
            if (listOfAllProjects.Count > 0)
            {
                Console.WriteLine("\n\nВведите индекс проекта, который нужно удалить : ");
                if ((int.TryParse(Console.ReadLine(), out int indexOfProject)) && (indexOfProject > 0) && (indexOfProject <= listOfAllProjects.Count))
                {
                    listOfAllProjects.RemoveAt(indexOfProject - 1);
                    Console.WriteLine("\n Проект удален.");
                }
                else
                {
                    Console.WriteLine("\n Индекс введен некорректно.");
                }
            }
            // Повтор действия или возврат в меню.
            Console.WriteLine("\nВыберите действие :\n\t[1] Удалить проект \n\t[2] Вернуться в меню проектов");
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
                    DeleteProject();
                    break;
                case '2':
                    WorkWithProjects();
                    break;
            }
        }

        /// <summary>
        /// Изменить имя проекта.
        /// </summary>
        private static void ChangeProjectName()
        {
            Console.Clear();
            Note();
            int flag = 0;
            Project project = SelectProjectFromList();
            if (project != null)
            {
                Console.WriteLine("\nВведите новое имя для проекта : ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    project.Name = name;
                    Console.WriteLine("\n Имя проекта изменено.");
                }
                else
                {
                    Console.WriteLine("\n Некорректное имя.");
                }
            }
            // Повтор действия или возврат в меню.
            Console.WriteLine("\nВыберите действие :\n\t[1] Изменить имя проекта\n\t[2] Вернуться в меню проектов");
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
                    ChangeProjectName();
                    break;
                case '2':
                    WorkWithProjects();
                    break;
            }
        }
    }
}
