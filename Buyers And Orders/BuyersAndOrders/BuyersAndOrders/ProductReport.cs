using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace BuyersAndOrders
{
    public partial class ProductReport : Form
    {
        // Поле заготовленных товаров.
        List<Product> Products;

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        /// <param name="products"> Список товаров. </param>
        public ProductReport(List<Product> products)
        {
            InitializeComponent();
            this.Products = products;
        }

        /// <summary>
        /// Событие при изменении выделенного товара.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Связь с родительской формой. Очищаем отображаемый список клиентов.
                SellerApp sellerApp = this.Owner as SellerApp;
                listBoxUsers.Items.Clear();
                if (listBoxProducts.SelectedIndex >= 0)
                {
                    if (Directory.Exists("Orders"))
                    {
                        string[] path = Directory.GetFiles("Orders");
                        // Проходимся по файлам в папке Orders, в каждом из которых лежит информация о заказах конкретного пользователя.
                        foreach (string file in path)
                        {
                            string info = File.ReadAllText(file);
                            // Если данный товар был заказан пользователем, то выводим ФИО пользователя и даты заказов, где этот товар присутствовал.
                            if (info.Contains(this.Products[listBoxProducts.SelectedIndex].Name))
                            {
                                foreach (Client client in sellerApp.Clients)
                                {
                                    if (client.Login == Path.GetFileNameWithoutExtension(file))
                                    {
                                        listBoxUsers.Items.Add($"{client.FIO} {GetDate(info, this.Products[listBoxProducts.SelectedIndex].Name)}");
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при формировании отчета.");
            }
        }

        /// <summary>
        /// Получить даты заказов, в которых присутствовал товар.
        /// </summary>
        /// <param name="info"> Информация о заказах. </param>
        /// <param name="name"> Наименование товара. </param>
        /// <returns></returns>
        private string GetDate(string info, string name)
        {
            try
            {
                // После каждого упоминания товара в заказах находим дату и сохраняем ее в строку-результат.
                string result = "";
                while (info.Contains(name))
                {
                    info = info.Substring(info.IndexOf(name));
                    result += info.Substring(info.IndexOf('.') - 2, 19);
                    result += " ";
                    info = info.Substring(info.IndexOf('.'));
                }
                return result;
            }
            catch
            {
                MessageBox.Show("Ошибка при формировании отчета.");
                return "";
            }
        }

        /// <summary>
        /// Отображаем товары при запуске формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductReport_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Product product in this.Products)
                {
                    listBoxProducts.Items.Add($"{product.Name} {product.Article} Цена = {product.Price}");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке товаров.");
            }
        }
    }
}
