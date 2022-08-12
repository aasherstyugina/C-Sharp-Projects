using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Интерфейс, который реализовывает класс CommonTasks.
    /// </summary>
    interface IAssignable
    {
        string Name { get; set; }
        DateTime Date { get; set; }
        string Status { get; set; }
        List<User> Implementers { get; set; }

        void AppointImplementer(User implementer);
        void ChangeImplementers(int indexWhomToReplace, User replacementUser);
        void DeleteImplementer(int index);
        void ChangeStatus(string status);
    }

    public abstract class CommonTasks:IAssignable
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public List<User> Implementers { get; set; }

        public CommonTasks(string name, string status)
        {
            this.Name = name;
            this.Date = DateTime.Now;
            this.Status = status;
            this.Implementers = new List<User>();
        }

        /// <summary>
        /// Назначить исполнителя задачи.
        /// </summary>
        /// <param name="implementer"> Пользователь, которого нужно назначить исполнителем. </param>
        public void AppointImplementer(User implementer) 
        {
            if (this.Implementers.Contains(implementer))
            {
                Console.WriteLine("\nЭтот пользователь уже назначен исполнителем задачи.");
            }
            else
            {
                this.Implementers.Add(implementer);
                Console.WriteLine("\nИсполнитель назначен.");
            }
        }

        /// <summary>
        /// Изменить исполнителя задачи.
        /// </summary>
        /// <param name="indexWhomToReplace"> Индекс пользователя из списка исполнителей, которого нужно удалить. </param>
        /// <param name="replacementUser"> Пользователь из общего списка, которого нужно добавить. </param>
        public void ChangeImplementers(int indexWhomToReplace, User replacementUser) 
        {
            this.Implementers.RemoveAt(indexWhomToReplace);
            this.Implementers.Insert(indexWhomToReplace, replacementUser);
        }

        /// <summary>
        /// Удалить исполнителя задачи.
        /// </summary>
        /// <param name="index"> Индекс исполнителя, которого нужно удалить. </param>
        public void DeleteImplementer(int index)
        {
            this.Implementers.RemoveAt(index);
        }
        /// <summary>
        /// Изменить статус задачи.
        /// </summary>
        /// <param name="status"> Новый статус. </param>
        public void ChangeStatus(string status)
        {
            this.Status = status;
        }
    }
}
