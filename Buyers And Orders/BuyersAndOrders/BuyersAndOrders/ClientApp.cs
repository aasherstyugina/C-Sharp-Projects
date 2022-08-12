using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace BuyersAndOrders
{
    public partial class ClientApp : Form
    {
        /// <summary>
        /// Поля текущий клиент, список товаров и список заказов клиента.
        /// </summary>
        public Client CurrentClient;
        public List<Product> Products;
        public List<Order> Orders;

        /// <summary>
        /// Конструктор клиентской формы.
        /// </summary>
        /// <param name="products"> Список товаров. </param>
        public ClientApp(List<Product> products)
        {
            InitializeComponent();
            // Добавляем в таблицу список товаров.
            this.Products = products;
            foreach(Product item in products)
            {
                dataGridViewProducts.Rows.Add(item.Name, item.Article, item.Count, item.Price);
            }
        }

        /// <summary>
        /// Событие при закрытии формы, а именно сохранение всей информации.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Directory.CreateDirectory("Orders");
                List<string> ordersInfo = new List<string>();
                // Записываем в папку Orders в файл, название которого = логину текущего пользователя информацию обо всех заказах, разделяя их *.
                foreach (Order order in Orders)
                {
                    // Информация о каждом товаре в заказе. 
                    foreach (Product product in order.Products)
                    {
                        ordersInfo.Add($"{product.Name} {product.Article} {product.Price} {product.Count}");
                    }
                    ordersInfo.Add(order.Index.ToString());
                    ordersInfo.Add(order.DayAndTime.ToString());
                    ordersInfo.Add(order.Status);
                    ordersInfo.Add(this.CurrentClient.FIO);
                    ordersInfo.Add("*");
                }
                File.WriteAllLines(Path.Combine("Orders", this.CurrentClient.Login), ordersInfo);
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
        /// Справка.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Чтобы собрать заказ, необходимо указать в столбце \"Количество\", сколько штук каждого товара должно быть в заказе и нажать" +
                " на кнопку \"Собрать заказ\"\n Чтобы узнать подробную информацию о существующем заказе или оплатить его, необходимо выделить его в списке.");
        }

        /// <summary>
        /// Нажатие кнопки создать заказ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, что все ячейки в столбце Количество имеют целочисленное неотрицательное значение.
                int flag = 0;
                foreach (DataGridViewRow row in dataGridViewProducts.Rows)
                {
                    if (!(int.TryParse(row.Cells[2].Value.ToString(), out int count) && count >= 0))
                    {
                        MessageBox.Show("Проверьте заполнение ячеек столбца \"Количество\". Значения должны быть целочисленными и неотрицательными.");
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    // Создаем список товаров и заполняем его товарами, количество которых больше 0.
                    List<Product> productsInOrder = new List<Product>();
                    for (int i = 0; i < dataGridViewProducts.Rows.Count; i++)
                    {
                        if (int.Parse(dataGridViewProducts.Rows[i].Cells[2].Value.ToString()) > 0)
                            productsInOrder.Add(new Product(this.Products[i].Name, this.Products[i].Article, this.Products[i].Price,
                                int.Parse(dataGridViewProducts.Rows[i].Cells[2].Value.ToString())));
                    }
                    if (productsInOrder.Count > 0)
                    {
                        // Обновляем отображаемый список заказов.
                        this.Orders.Add(new Order(productsInOrder, GenerateUnicIndex(), DateTime.Now, "", this.CurrentClient));
                        listBoxOrders.Items.Clear();
                        foreach (Order order in this.Orders)
                        {
                            listBoxOrders.Items.Add($"Заказ номер {order.Index}");
                        }
                    }
                    else
                        MessageBox.Show("Вы не можете создать пустой заказ.");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при создании заказа.");
            }
        }

        /// <summary>
        /// Загрузка созданных ранее заказов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientApp_Load(object sender, EventArgs e)
        {
            try
            {
                listBoxOrders.Items.Clear();
                foreach (Order order in this.Orders)
                {
                    listBoxOrders.Items.Add($"Заказ номер {order.Index}");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке сохраненных ранее заказов.");
            }
        }

        /// <summary>
        /// Генерация уникального номера заказа.
        /// </summary>
        /// <returns> Номер заказа. </returns>
        private int GenerateUnicIndex()
        {
            try
            {
                Random random = new Random();
                int index = 0, counter, flag = 0;
                // Генерируем рандомный натуральный номер, если какой-то заказ уже имеет такой номер - повторяем генерацию.
                while (flag == 0)
                {
                    index = random.Next(1, 10000);
                    counter = 0;
                    foreach (Order order in this.Orders)
                    {
                        if (int.Parse(order.Index.ToString()) != index)
                            counter++;
                    }
                    if (counter == this.Orders.Count)
                        flag = 1;
                }
                return index;
            }
            catch
            {
                MessageBox.Show("Ошибка при генерации номера заказа.");
                return 0;
            }
        }

        /// <summary>
        /// Нажатие кнопки получения подробной информации о заказе.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetOrderInfoToolStripMenuItem_Click(object sender, EventArgs e)
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
        /// Оплата заказа.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, что выделен какой-то заказ.
                if (listBoxOrders.SelectedIndex >= 0)
                {
                    // Проверяем, что заказ имеет статус Обработан.
                    if (this.Orders[listBoxOrders.SelectedIndex].Status.Contains("1"))
                    {
                        MessageBox.Show($"Заказ {this.Orders[listBoxOrders.SelectedIndex].Index} успешно оплачен!");
                        // Добавляем заказу статус оплачен.
                        this.Orders[listBoxOrders.SelectedIndex].Status += "2";
                    }
                    else
                        MessageBox.Show("Оплатить можно только заказ имеющий статус \"обработан\"");
                }
                else
                    MessageBox.Show("Чтобы оплатить заказ, необходимо выделить его.");
            }
            catch
            {
                MessageBox.Show("Ошибка при оплате заказа.");
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
    }
}
