using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace BuyersAndOrders
{
    public partial class SellerApp : Form
    {
        // Поля список клиентов, список всех заказов, 
        public List<Client> Clients;
        public List<Order> Orders;
        public string ChoosenStatus;

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public SellerApp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие при закрытии формы, а именно автосохранение.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SellerApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Очищаем предыдущие сохраненные данные.
                Directory.CreateDirectory("Orders");
                foreach (Order order in Orders)
                {
                    File.WriteAllText(Path.Combine("Orders", order.User.Login), "");
                }
                // Переводим в текст информацию о каждом заказе.
                foreach (Order order in Orders)
                {
                    List<string> ordersInfo = new List<string>();
                    // Информация о каждом товаре в текущем заказе.
                    foreach (Product product in order.Products)
                    {
                        ordersInfo.Add($"{product.Name} {product.Article} {product.Price} {product.Count}");
                    }
                    ordersInfo.Add(order.Index.ToString());
                    ordersInfo.Add(order.DayAndTime.ToString());
                    ordersInfo.Add(order.Status);
                    ordersInfo.Add(order.User.FIO);
                    ordersInfo.Add("*");
                    // Записываем информацию о заказе в папку Orders в файл, название которого = имени клиента, сделавшего заказ.
                    File.AppendAllLines(Path.Combine("Orders", order.User.Login), ordersInfo);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка автосохранения.");
            }
            finally
            {
                // Закрываем приложение.
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Автозагрузка сохраненных ранее данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SellerApp_Load(object sender, EventArgs e)
        {
            try
            {
                this.Clients = LoadClients();
                this.Orders = LoadOrders();
                // Обновление списка заказов.
                foreach (Order order in this.Orders)
                {
                    listBoxOrders.Items.Add($"Заказ номер {order.Index}");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка автозагрузки данных.");
            }
        }

        /// <summary>
        /// Загрузка списка клиентов.
        /// </summary>
        /// <returns> Список клиентов. </returns>
        private List<Client> LoadClients()
        {
            try
            {
                List<Client> clients = new List<Client>();
                // Из файла Users 
                string[] clientsInfo = File.ReadAllLines("Users");
                foreach (string client in clientsInfo)
                {
                    Client user = ParseClient(client);
                    // Если пользователь - клиент, то добавляем его в список клиентов.
                    if (user.Type == 0)
                    {
                        listBoxUsers.Items.Add(user.FIO);
                        clients.Add(user);
                    }
                }
                return clients;
            }
            catch
            {
                MessageBox.Show("Ошибка автозагрузки данных о клиентах.");
                return null;
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
                    clientInfo.Split('*')[7], clientInfo.Split('*')[0], clientInfo.Split('*')[1], clientInfo.Split('*')[2]);
            }
            catch
            {
                MessageBox.Show("Ошибка авторизации.");
                return null;
            }
        }

        /// <summary>
        /// Загрузка списка всех заказов.
        /// </summary>
        /// <returns> Список заказов. </returns>
        private List<Order> LoadOrders()
        {
            try
            {
                List<Order> orders = new List<Order>();
                if (Directory.Exists("Orders"))
                {
                    // Проходим по всем файлам в папке Orders, где в каждом из них хранится информация о заказах отдельного клиента.
                    string[] path = Directory.GetFiles("Orders");
                    foreach (string file in path)
                    {
                        string[] info = File.ReadAllLines(file);
                        int index = -1;
                        // Получаем информацию о заказах, они разделены *.
                        for (int i = 0; i < info.Length; i++)
                        {
                            if (info[i] == "*")
                            {
                                // Получаем информацию о товарах в заказе.
                                List<Product> products = new List<Product>();
                                for (int j = index + 1; j < i - 4; j++)
                                {
                                    string[] productInfo = info[j].Split(' ');
                                    products.Add(new Product(productInfo[0], productInfo[1], int.Parse(productInfo[2]), int.Parse(productInfo[3])));
                                }
                                int userIndex = -1;
                                // Ищем из списка клиентов того, кто сделал этот заказ.
                                for (int g = 0; g < this.Clients.Count; g++)
                                {
                                    if (this.Clients[g].Login == Path.GetFileNameWithoutExtension(file))
                                    {
                                        userIndex = g;
                                        break;
                                    }
                                }
                                // Добавляем заказ в список.
                                orders.Add(new Order(products, int.Parse(info[i - 4]), DateTime.Parse(info[i - 3]), info[i - 2], this.Clients[userIndex]));
                                index = i;
                            }
                        }
                    }
                }
                return orders;
            }
            catch
            {
                MessageBox.Show("Ошибка автозагрузки данных.");
                return null;
            }
        }

        /// <summary>
        /// Событие при изменении выделенного пользователя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Если клиент выделен, то отображаем все его заказы.
                if (listBoxUsers.SelectedIndex >= 0)
                {
                    listBoxOrders.Items.Clear();
                    foreach (Order order in this.Orders)
                    {
                        if (order.User.Login == this.Clients[listBoxUsers.SelectedIndex].Login)
                            listBoxOrders.Items.Add($"Заказ номер {order.Index}");
                    }
                }
                // Если никто не выделен, то отображаем все заказы.
                else
                {
                    listBoxOrders.Items.Clear();
                    foreach (Order order in this.Orders)
                        listBoxOrders.Items.Add($"Заказ номер {order.Index}");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при выборе клиента.");
            }
        }

        /// <summary>
        /// Изменить статус заказа.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxOrders.SelectedIndex >= 0)
                {
                    // Открываем форму для изменениея статуса.
                    ChangeStatus changeStatus = new ChangeStatus();
                    changeStatus.Owner = this;
                    changeStatus.ShowDialog();
                }
                else
                    MessageBox.Show("Чтобы изменить статус заказа, необходимо выделить заказ.");
            }
            catch
            {
                MessageBox.Show("Ошибка при попытке изменить статус заказа.");
            }
        }

        /// <summary>
        /// Двойной клик по ListBox со списком клиентов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBoxUsers_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // При двойном клике убираем выделение со всех клиентов.
                listBoxUsers.ClearSelected();
            }
            catch
            {
                MessageBox.Show("Ошибка при выборе заказа.");
            }
        }

        /// <summary>
        /// Отображение активных заказов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxActiveOrders_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                // Если CheckBox выбран, то отображаем все неисполненные заказы.
                if (checkBoxActiveOrders.Checked)
                {
                    listBoxOrders.Items.Clear();
                    foreach (Order order in this.Orders)
                    {
                        if (!order.Status.Contains("4"))
                            listBoxOrders.Items.Add($"Заказ номер {order.Index}");
                    }
                }
                // Если не выбран, то отображаем все заказы.
                else
                {
                    listBoxOrders.Items.Clear();
                    foreach (Order order in this.Orders)
                        listBoxOrders.Items.Add($"Заказ номер {order.Index}");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при попытке отобразить активные заказы.");
            }
        }

        /// <summary>
        /// Справка.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Чтобы увидеть сумму оплаченных заказов клиента, необходимо выделить клиента\nЧтобы изменить статус заказа, " +
                "необходимо выделить заказ.\nЧтобы снять выделение с клиентов, необходимо сделать двойной клик по полю, где отображаются клиенты.");
        }

        /// <summary>
        /// Узнать общую сумму оплаченных заказов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayedOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int cost = 0;
                if (listBoxUsers.SelectedIndex >= 0)
                {
                    // Из общего списка заказов выбираем те, которые совершил и оплатил выбранный пользователь. Считаем общую сумму.
                    foreach (Order order in this.Orders)
                    {
                        if (order.User.Login == this.Clients[listBoxUsers.SelectedIndex].Login && order.Status.Contains("2"))
                            cost += order.TotalPrice;
                    }
                    MessageBox.Show($"Общая сумма по оплаченным заказам = {cost}");
                }
                else
                    MessageBox.Show("Чтобы увидеть общую сумму по оплаченным заказам клиента, необходимо выделить желаемого клиента.");
            }
            catch
            {
                MessageBox.Show("Ошибка при попытке узнать общую сумму оплаченных заказов.");
            }
        }

        /// <summary>
        /// Нажатие кнопки получения подробной информации о заказе.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, что выделен какой-то заказ.
                if (listBoxOrders.SelectedIndex >= 0)
                {
                    Order order = this.Orders[listBoxOrders.SelectedIndex];
                    string text = "";
                    // Информация о каждом товаре.
                    foreach (Product product in order.Products)
                    {
                        text += $"{product.Name} {product.Article} Цена : {product.Price} Количество : {product.Count}\n";
                    }
                    // Остальная информация о заказе.
                    text += $"Номер заказа : {order.Index}\n";
                    text += $"Статус заказа : {StatusText(listBoxOrders.SelectedIndex)}\n";
                    text += $"Дата заказа : {order.DayAndTime}\n";
                    text += $"ФИО заказчика : {order.User.FIO}\n";
                    text += $"Общая стоимость заказа : {order.TotalPrice}";
                    MessageBox.Show(text);
                }
                else
                    MessageBox.Show("Чтобы посмотреть информацию о заказе, необходимо выделить его.");
            }
            catch
            {
                MessageBox.Show("Ошибка при попытке получить подробную информацию о заказе.");
            }
        }

        /// <summary>
        /// Перевод статуса заказа в текст.
        /// </summary>
        /// <param name="index"> Индекс заказа в общем списке. </param>
        /// <returns> Текстовое представление статуса. </returns>
        private string StatusText(int index)
        {
            try
            {
                string status = this.Orders[index].Status;
                string text = "";
                if (status.Contains("1"))
                    text += "Обработан ";
                if (status.Contains("2"))
                    text += "Оплачен ";
                if (status.Contains("3"))
                    text += "Отгружен";
                if (status.Contains("4"))
                    text += "Исполнен";
                return text;
            }
            catch
            {
                MessageBox.Show("Ошибка при формировании статуса заказа.");
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
            for (int i = 0; i < 18; i++)
            {
                Product item = new Product(nameArray[i], articleArray[i], int.Parse(priceArray[i]), 0);
                products.Add(item);
            }
            return products;
        }

        /// <summary>
        /// Получить отчет о клиентах, оплативших товар на сумму, превышающую заданную.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaidOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Запуск формы отчета.
                PaidClientsReport paidClientsReport = new PaidClientsReport();
                paidClientsReport.Owner = this;
                paidClientsReport.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Ошибка при формировании отчета.");
            }
        }

        /// <summary>
        /// Получить отчет о клиентах, которые заказывали конкретный товар.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Запуск формы отчета.
                ProductReport productReport = new ProductReport(SetAllProducts());
                productReport.Owner = this;
                productReport.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Ошибка при формировании отчета.");
            }
        }
    }
}
