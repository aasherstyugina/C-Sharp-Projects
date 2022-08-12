using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Project
    {
        public int MaxNumOfTasks { get; set; }
        public string Name { get; set; }
        public List<CommonTasks> listOfTasks;

        public Project(string name, int maxNumOfTasks)
        {
            this.Name = name;
            this.MaxNumOfTasks = maxNumOfTasks;
            this.listOfTasks = new List<CommonTasks>();
        }

        /// <summary>
        /// Добавить задачу в проект.
        /// </summary>
        /// <param name="task"> Задача. </param>
        public void AddTask(CommonTasks task)
        {
            // Проверка, чтобы количество задач в проекте не превышало максимальное количество.
            if (this.listOfTasks.Count >= this.MaxNumOfTasks)
            {
                Console.WriteLine($"Невозможно добавить задачу {task.Name} в проект {this.Name}, так как в нём уже максимальное количество задач.");
            }
            else
            {
                this.listOfTasks.Add(task);
            }
        }

        /// <summary>
        /// Удалить задачу из проекта.
        /// </summary>
        /// <param name="indexOfTask"> Индекс задачи, которую надо удалить. </param>
        public void DeleteTask(int indexOfTask)
        {
            this.listOfTasks.RemoveAt(indexOfTask);
        }
    }
}
