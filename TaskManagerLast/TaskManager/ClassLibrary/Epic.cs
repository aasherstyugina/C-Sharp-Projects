using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Epic:CommonTasks
    {
        public List<CommonTasks> subTasks = new List<CommonTasks>();

        /// <summary>
        /// Конструктор объектов типа Epic.
        /// </summary>
        /// <param name="name"> Имя задачи. </param>
        /// <param name="status"> Статус задачи. </param>
        public Epic(string name, string status) : base(name, status)
        {
        }

        /// <summary>
        /// Добавить подзадачу.
        /// </summary>
        /// <param name="task"> Подзадача. </param>
        public void AddSubTask(CommonTasks task)
        {
            this.subTasks.Add(task);
        }

        /// <summary>
        /// Удалить подзадачу.
        /// </summary>
        /// <param name="indexOfTask"> Индекс подзадачи, которую надо удалить. </param>
        public void DeleteSubTask(int indexOfTask)
        {
            this.subTasks.RemoveAt(indexOfTask);
        }
    }
}
