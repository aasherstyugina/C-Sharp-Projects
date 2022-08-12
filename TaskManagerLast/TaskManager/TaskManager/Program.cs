using System;
using ClassLibrary;
using System.Collections.Generic;

namespace TaskManager
{
    partial class Program
    {
        // Списки пользователей и проектов.
        private static List<User> listOfAllUsers = new List<User>();
        private static List<Project> listOfAllProjects = new List<Project>();
        static void Main()
        {
            // Загузка сохраненной информации и переход в основное меню.
            LoadInfo();
            StartMenu();
        }

        /// <summary>
        /// Памятка о работе в приложении.
        /// </summary>
        private static void Note()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nПримечание: \n\t[1] *пункт меню* - для выбора этого пункта следует нажать клавишу 1");
            Console.ResetColor();
        }

        /// <summary>
        /// Основное меню.
        /// </summary>
        private static void StartMenu()
        {
            Console.Clear();
            Note();
            int flag = 0;
            Console.WriteLine("\nОсновное меню :\n\n\t[1] Меню пользователей\n\t[2] Меню проектов" +
                " \n\t[3] Меню задач в проекте\n\t[4] Выйти из приложения");
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
            switch (key.KeyChar)
            {
                case '1':
                    WorkWithUsers();
                    break;
                case '2':
                    WorkWithProjects();
                    break;
                case '3':
                    WorkWithTasks();
                    break;
                case '4':
                    // Сохранение перед выходом.
                    try
                    {
                        AutoSave();
                    }
                    catch
                    {
                        Console.WriteLine("\nОшибка автосохранения.");
                    }
                    Environment.Exit(0);
                    break;
            }
        }

        
    }
}
