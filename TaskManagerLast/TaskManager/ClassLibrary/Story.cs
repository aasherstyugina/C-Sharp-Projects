using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Story:CommonTasks
    {
        /// <summary>
        /// Конструктор объектов типа Story.
        /// </summary>
        /// <param name="name">  Имя задачи. </param>
        /// <param name="status"> Статус задачи. </param>
        public Story(string name, string status) : base(name, status)
        {
        }
    }
}
