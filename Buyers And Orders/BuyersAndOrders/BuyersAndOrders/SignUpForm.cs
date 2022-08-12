using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace BuyersAndOrders
{
    public partial class SignUpForm : Form
    {
        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public SignUpForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка регистрации.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                // Если введенные данные корректны и пользователя с таким логином еще нет, то регистрируем его.
                if (ValidateInput())
                {
                    if (ValidateLogin(textBoxLoginSignUp.Text))
                    {
                        string hashPassword = HashPassword(textBoxPasswordSignUp.Text, textBoxSurname.Text);
                        // Записываем в файл "Users" информацию о пользователе.
                        File.AppendAllText("Users", $"{textBoxLoginSignUp.Text}*{hashPassword}*{comboBoxUserType.SelectedIndex}*{textBoxSurname.Text}" +
                           $"*{textBoxName.Text}*{textBoxPatronymic.Text}*{textBoxPhone.Text}*{textBoxAdress.Text}\n");
                        Hide();
                        if (comboBoxUserType.SelectedIndex == 0)
                        {
                            // Если регистрировался клиент, то запускаем клиентскую форму.
                            ClientApp clientApp = new ClientApp(SetAllProducts());
                            Client currentClient = new Client(textBoxSurname.Text, textBoxName.Text, textBoxPatronymic.Text, textBoxPhone.Text,
                                textBoxAdress.Text, textBoxLoginSignUp.Text, textBoxPasswordSignUp.Text, "0");
                            clientApp.CurrentClient = currentClient;
                            clientApp.Orders = new List<Order>();
                            clientApp.Show();
                        }
                        else
                        {
                            // Иначе запускаем форму продавца.
                            SellerApp sellerApp = new SellerApp();
                            sellerApp.Show();
                        }
                    }
                    else
                        MessageBox.Show("Пользователь с таким логином уже зарегистрирован.");
                }
                else
                    MessageBox.Show("Проверьте, что все поля заполнены\nОни не должны быть пустыми и не должны содержать *\n" +
                        "Должен быть выбран тип пользователя\n");
            }
            catch
            {
                MessageBox.Show("Ошибка при регистрации.");
            }
        }

        /// <summary>
        /// Проверка правильности введенных данных.
        /// </summary>
        /// <returns> Истина или ложь. </returns>
        private bool ValidateInput()
        {
            try
            {
                return !string.IsNullOrEmpty(textBoxLoginSignUp.Text) && !string.IsNullOrEmpty(textBoxPasswordSignUp.Text)
                    && comboBoxUserType.SelectedIndex >= 0 && !textBoxLoginSignUp.Text.Contains('*') && !textBoxPasswordSignUp.Text.Contains('*')
                    && !string.IsNullOrEmpty(textBoxSurname.Text) && !textBoxSurname.Text.Contains('*') && !string.IsNullOrEmpty(textBoxName.Text)
                    && !textBoxName.Text.Contains('*') && !string.IsNullOrEmpty(textBoxPatronymic.Text) && !textBoxPatronymic.Text.Contains('*')
                    && !string.IsNullOrEmpty(textBoxPhone.Text) && !textBoxPhone.Text.Contains('*') && !string.IsNullOrEmpty(textBoxAdress.Text)
                    && !textBoxAdress.Text.Contains('*');
            }
            catch
            {
                MessageBox.Show("Ошибка при регистрации");
                return false;
            }
        }

        /// <summary>
        /// Проверка, что пользователя с таким логином еще нет.
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns> Истина или ложь. </returns>
        private bool ValidateLogin(string userLogin)
        {
            try
            {
                if (File.Exists("Users"))
                {
                    string[] logins = File.ReadAllLines("Users");
                    foreach (string login in logins)
                    {
                        if (userLogin == login.Split('*')[0])
                            return false;
                    }
                }
                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка при регистрации");
                return false;
            }
        }

        /// <summary>
        /// Список товаров.
        /// </summary>
        /// <returns> Список товаров. </returns>
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
            // Создаем список с заготовленными товарами.
            for (int i = 0; i < 18; i++)
            {
                Product item = new Product(nameArray[i], articleArray[i], int.Parse(priceArray[i]), 0);
                products.Add(item);
            }
            return products;
        }

        // Получение хэш-кода от строки пароль + фамилия.
        private string HashPassword(string password, string surname)
        {
            try
            {
                string passwordAndSalt = password + surname;
                return passwordAndSalt.GetHashCode().ToString();
            }
            catch
            {
                MessageBox.Show("Ошибка при получении хэш-кода.");
                return "";
            }
        }
    }
}
