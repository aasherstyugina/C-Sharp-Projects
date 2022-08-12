using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace BuyersAndOrders
{
    public partial class AuthorizationForm : Form
    {
        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка регистрации пользователя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreateUser_Click(object sender, EventArgs e)
        {
            Hide();
            // Открываем форму с регистрацией.
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
        }

        /// <summary>
        /// Кнопка авторизации пользователя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateLogin())
                {
                    if (File.Exists("Users"))
                    {
                        // Среди всех пользователей ищем того, чей логин и пароль совпадает с введенными данными.
                        string[] users = File.ReadAllLines("Users");
                        int index = -1, currentIndex = -1;
                        for (int i = 0; i < users.Length; i++)
                        {
                            // Проверяем, что хэш-код введенного пароля + хранящейся фамилии = хранящемуся хэш-коду пароля.
                            if (users[i].Split('*')[0] == textBoxLoginSignIn.Text &&(textBoxPasswordSignIn.Text
                                + users[i].Split('*')[3]).GetHashCode().ToString() == users[i].Split('*')[1])
                            {
                                index = int.Parse(users[i].Split('*')[2]);
                                currentIndex = i;
                                break;
                            }
                        }
                        // Если это клиент, то запускаем форму с функционалом для клиентов.
                        if (index == 0)
                        {
                            Hide();
                            ClientApp clientApp = new ClientApp(SetAllProducts());
                            Client currentClient = ParseClient(users[currentIndex]);
                            clientApp.CurrentClient = currentClient;
                            clientApp.Orders = LoadOrders(currentClient);
                            clientApp.Show();
                        }
                        // Если это продавец, то запускаем форму с функционалом для продавцов.
                        else if (index == 1)
                        {
                            Hide();
                            SellerApp sellerApp = new SellerApp();
                            sellerApp.Show();
                        }
                        else
                            MessageBox.Show("Такой пользователь не зарегистрирован.");
                    }
                    else
                        MessageBox.Show("Такой пользователь не зарегистрирован.");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка авторизации.");
            }
        }

        /// <summary>
        /// Проверка правильности введенных данных.
        /// </summary>
        /// <returns> Истина или ложь. </returns>
        private bool ValidateLogin()
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxLoginSignIn.Text) && !string.IsNullOrEmpty(textBoxPasswordSignIn.Text)
                    && !textBoxLoginSignIn.Text.Contains('*') && !textBoxPasswordSignIn.Text.Contains('*'))
                    return true;
                else
                {
                    MessageBox.Show("Проверьте правильность заполнения полей\nПоля не должны быть пустыми и не должны содержать *");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка авторизации.");
                return false;
            }
        }

        /// <summary>
        /// Из строковой информации о клиенте создаем сам объект.
        /// </summary>
        /// <param name="clientInfo"> Строковая информация о клиенте. </param>
        /// <returns> Созданный клиент. </returns>
        private Client ParseClient(string clientInfo)
        {
            try
            {
                return new Client(clientInfo.Split('*')[3], clientInfo.Split('*')[4], clientInfo.Split('*')[5], clientInfo.Split('*')[6],
                    clientInfo.Split('*')[7], textBoxLoginSignIn.Text, textBoxPasswordSignIn.Text,"0");
            }
            catch
            {
                MessageBox.Show("Ошибка авторизации.");
                return null;
            }
        }

        /// <summary>
        /// Создаем список товаров в магазине.
        /// </summary>
        /// <returns> Список объектов. </returns>
        private List<Product> SetAllProducts()
        {
            string name = "Микроволновка Чайник Утюг Холодильник Телевизор Пылесос Ноутбук Мультиварка Тостер Принтер Сканер Электрогриль " +
                "Кофеварка Наушники Весы Вентилятор Кондиционер Мясорубка";
            string[] nameArray = name.Split(' ');
            string article = "00-01-0456 30-40-8576 44-23-3458 99-87-5780 78-12-3444 05-00-9804 59-60-8745 90-12-3248 80-00-5783 30-88-5489" +
                " 98-07-8774 32-11-3498 35-58-0984 43-99-8757 00-98-7890 49-32-5789 66-34-8746 09-80-4738";
            string[] articleArray = article.Split(' ');
            string price = "3500 2400 2650 25000 48000 13000 67000 15500 2000 13700 10000 7800 50000 15000 1000 3700 20000 6200";
            string[] priceArray = price.Split(' ');
            List<Product> products = new List<Product>();
            // Заполняем список.
            for(int i = 0; i < 18; i++)
            {
                Product item = new Product(nameArray[i], articleArray[i], int.Parse(priceArray[i]), 0);
                products.Add(item);
            }
            return products;
        }

        /// <summary>
        /// Загрузка сохраненных заказов.
        /// </summary>
        /// <param name="user"> Текущий пользователь. </param>
        /// <returns> Список заказов. </returns>
        private List<Order> LoadOrders(Client user)
        {
            try
            {
                List<Order> orders = new List<Order>();
                // Заказы пользователя лежат в папке Orders в файле, название которого = логину пользователя.
                string[] info = File.ReadAllLines(Path.Combine("Orders", user.Login));
                int index = -1;
                // Парсим заказы, разделенные *.
                for (int i = 0; i < info.Length; i++)
                {
                    if (info[i] == "*")
                    {
                        // Товары в заказе.
                        List<Product> products = new List<Product>();
                        for (int j = index + 1; j < i - 4; j++)
                        {
                            string[] productInfo = info[j].Split(' ');
                            products.Add(new Product(productInfo[0], productInfo[1], int.Parse(productInfo[2]), int.Parse(productInfo[3])));
                        }
                        orders.Add(new Order(products, int.Parse(info[i - 4]), DateTime.Parse(info[i - 3]), info[i - 2], user));
                        index = i;
                    }
                }
                return orders;
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки товаров.");
                return null;
            }
        }
    }
}
