using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Task:CommonTasks
    {
        /// <summary>
        /// Конструктор объекта типа Task.
        /// </summary>
        /// <param name="name"> Имя задачи. </param>
        /// <param name="status"> Статус задачи. </param>
        public Task(string name, string status) : base(name, status)
        {
        }
    }
}
