namespace BuyersAndOrders
{
    public class Client
    {
        // Поля объекта клиент.
        public string FIO;
        string Phone;
        string Adress;
        public string Login;
        string Password;
        public int Type;

        /// <summary>
        /// Конструктор объекта клиент.
        /// </summary>
        /// <param name="surname"> Фамилия. </param>
        /// <param name="name"> Имя. </param>
        /// <param name="patronymic"> Отчетсво. </param>
        /// <param name="phone"> Телефон. </param>
        /// <param name="adress"> Адрес. </param>
        /// <param name="login"> Логин. </param>
        /// <param name="password"> Пароль. </param>
        /// <param name="type"> Тип пользователя. </param>
        public Client(string surname,string name, string patronymic, string phone, string adress, string login, string password, string type)
        {
            this.FIO = surname+" "+name+" "+patronymic;
            this.Phone = phone;
            this.Adress = adress;
            this.Login = login;
            this.Password = password;
            this.Type = int.Parse(type);
        }
    }
}
