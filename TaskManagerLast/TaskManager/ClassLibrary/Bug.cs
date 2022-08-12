using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Bug:CommonTasks
    {
        /// <summary>
        /// Конструктор объектов типа Bug.
        /// </summary>
        /// <param name="name"> Имя задачи. </param>
        /// <param name="status"> Статус задачи. </param>
        public Bug(string name, string status) : base(name, status)
        {
        }
    }
}
