using System;
using System.Windows.Forms;

namespace BuyersAndOrders
{
    public partial class PaidClientsReport : Form
    {
        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public PaidClientsReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка сформировать отчет.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMakeReport_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка на корректный ввод заданной суммы.
                if (!string.IsNullOrEmpty(textBoxCost.Text) && int.TryParse(textBoxCost.Text, out int cost) && cost >= 0)
                {
                    // Связь с родительской формой.
                    SellerApp sellerApp = this.Owner as SellerApp;
                    int[] paidMoney = new int[sellerApp.Clients.Count];
                    // Записываем в массив общую сумму, которую заплатил каждый клиент за заказы.
                    foreach (Order order in sellerApp.Orders)
                    {
                        int index = -1;
                        for (int i = 0; i < sellerApp.Clients.Count; i++)
                        {
                            if (order.User.Login == sellerApp.Clients[i].Login)
                            {
                                index = i;
                                break;
                            }
                        }
                        paidMoney[index] += order.TotalPrice;
                    }
                    // Записываем в массив ФИО каждого клиента.
                    string[] clientsFIOs = new string[sellerApp.Clients.Count];
                    for (int i = 0; i < sellerApp.Clients.Count; i++)
                    {
                        clientsFIOs[i] = sellerApp.Clients[i].FIO;
                    }
                    // Сортируем оба массива по убыванию оплаты и записываем в строковый массив в формате ФИО+сумма.
                    string[] result = SortClients(paidMoney, clientsFIOs);
                    // Обновляем список клиентов.
                    listBoxUsers.Items.Clear();
                    foreach (string item in result)
                    {
                        string[] info = item.Split(' ');
                        if (int.Parse(info[info.Length - 1]) > int.Parse(textBoxCost.Text))
                            listBoxUsers.Items.Add(item);
                    }
                }
                else
                    MessageBox.Show("Введена некорректная сумма, она должна быть целочисленной и неотрицательной.");
            }
            catch
            {
                MessageBox.Show("Ошибка при формировании отчета об оплате.");
            }
        }

        /// <summary>
        /// Сортировка клиентов по убыванию оплаты.
        /// </summary>
        /// <param name="paidMoney"> Массив оплаты. </param>
        /// <param name="clientsFIOs"> Массив ФИО клиентов. </param>
        /// <returns> Отсортированный строковый массив в формате ФИО+оплата. </returns>
        private string[] SortClients(int[] paidMoney,string[] clientsFIOs)
        {
            try
            {
                // Сортировка методом пузырька.
                string[] result = new string[paidMoney.Length];
                for (int i = 0; i < paidMoney.Length; i++)
                    for (int j = i + 1; j < paidMoney.Length; j++)
                    {
                        if (paidMoney[i] > paidMoney[j])
                        {
                            int tempInt = paidMoney[i];
                            paidMoney[i] = paidMoney[j];
                            paidMoney[j] = tempInt;
                            string tempStr = clientsFIOs[i];
                            clientsFIOs[i] = clientsFIOs[j];
                            clientsFIOs[j] = tempStr;
                        }
                    }
                Array.Reverse(clientsFIOs);
                Array.Reverse(paidMoney);
                // Формирование финального массива.
                for (int i = 0; i < paidMoney.Length; i++)
                {
                    result[i] = $"{clientsFIOs[i]} заплатил {paidMoney[i]}";
                }
                return result;
            }
            catch
            {
                MessageBox.Show("Ошибка при сортировке клиентов.");
                return null;
            }
        }
    }
}
