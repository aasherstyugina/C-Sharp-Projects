using System;
using System.Linq;
using System.Windows.Forms;

namespace BuyersAndOrders
{
    public partial class ChangeStatus : Form
    {
        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public ChangeStatus()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажатие кнопки ОК.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            try
            {// Связь с родительской формой.
                SellerApp sellerApp = this.Owner as SellerApp;
                string status = "";
                // Записываем в выбранный пользователем статус.
                foreach (int index in checkedListBox.CheckedIndices)
                {
                    if (index == 0)
                        status += "1";
                    if (index == 1)
                        status += "3";
                    if (index == 2)
                        status += "4";
                }
                ListBox listBox = sellerApp.Controls[0].Controls[0] as ListBox;
                string indexOrder = listBox.Items[listBox.SelectedIndex].ToString().Replace("Заказ номер ", "");
                // В списке заказов находим выбранный, добавляем в него статусы из выбранных, которых там еще нет.
                foreach (Order order in sellerApp.Orders)
                {
                    if (order.Index == int.Parse(indexOrder))
                    {
                        for (int i = 0; i < status.Length; i++)
                        {
                            if (!order.Status.Contains(status[i]))
                                order.Status += status[i];
                        }
                        MessageBox.Show($"Статус заказа {indexOrder} успешно изменен.");
                        break;
                    }
                }
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка при изменении статуса.");
            }
        }
    }
}
