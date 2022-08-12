using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;

namespace TaskManager
{
    partial class Program
    {
        /// <summary>
        /// Меню пользователей.
        /// </summary>
        private static void WorkWithUsers()
        {
            Console.Clear();
            Note();
            int flag = 0;
            Console.WriteLine("\nМеню пользователей :\n\n\t[1] Создание пользователя\n\t[2] Просмотр списка пользователей" +
                " \n\t[3] Удаление пользователя\n\t[4] Вернуться в основное меню");
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
                    AddUser();
                    break;
                case '2':
                    ShowAllUsers();
                    break;
                case '3':
                    DeleteUser();
                    break;
                case '4':
                    StartMenu();
                    break;
            }
        }

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        private static void AddUser()
        {
            Console.Clear();
            Note();
            int flag = 0;
            // Получение имени пользователя и создание его.
            Console.WriteLine("\nВведите имя пользователя: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                listOfAllUsers.Add(new User(name));
                Console.WriteLine($"\nПользователь {name} добавлен в общий список.");
            }
            else
            {
                Console.WriteLine("\nНекорректное имя пользователя. Он не будет добавлен.");
            }
            // Повтор действия или возврат в меню.
            Console.WriteLine("\nВыберите действие :\n\t[1] Добавить пользователя \n\t[2] Вернуться в меню пользователей");
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
                    AddUser();
                    break;
                case '2':
                    WorkWithUsers();
                    break;
            }
        }

        /// <summary>
        /// Вывод списка всех пользователей.
        /// </summary>
        private static void ShowAllUsers()
        {
            Console.Clear();
            Note();
            int flag = 0;
            GetListOfUsers();
            // Возврат в меню пользователей.
            Console.WriteLine("\n[1] Вернуться в меню пользователей");
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
                    WorkWithUsers();
                    break;
            }
        }

        /// <summary>
        /// Удаление пользователя.
        /// </summary>
        private static void DeleteUser()
        {
            Console.Clear();
            Note();
            int flag = 0;
            GetListOfUsers();
            if (listOfAllUsers.Count > 0)
            {
                Console.WriteLine("\n\nВведите индекс пользователя, которого нужно удалить : ");
                if ((int.TryParse(Console.ReadLine(), out int indexOfUser)) && (indexOfUser > 0) && (indexOfUser <= listOfAllUsers.Count))
                {
                    listOfAllUsers.RemoveAt(indexOfUser - 1);
                    Console.WriteLine("\n Пользователь удален.");
                }
                else
                {
                    Console.WriteLine("\n Индекс введен некорректно.");
                }
            }
            // Повтор действия или возврат в меню.
            Console.WriteLine("\nВыберите действие :\n\t[1] Удалить пользователя \n\t[2] Вернуться в меню пользователей");
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
                    DeleteUser();
                    break;
                case '2':
                    WorkWithUsers();
                    break;
            }
        }
    }
}
