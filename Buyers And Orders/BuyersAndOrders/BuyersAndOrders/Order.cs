using System;
using System.Collections.Generic;

namespace BuyersAndOrders
{
    public class Order
    {
        // Поля объекта заказ.
        public List<Product> Products;
        public int Index;
        public DateTime DayAndTime;
        public string Status;
        public Client User;
        public int TotalPrice;

        /// <summary>
        /// Конструктор объекта заказ.
        /// </summary>
        /// <param name="products"> Список товаров. </param>
        /// <param name="index"> Номер. </param>
        /// <param name="dayAndTime"> Датаи время. </param>
        /// <param name="status"> Статус. </param>
        /// <param name="user"> Ссылка на клиента. </param>
        public Order(List<Product> products, int index, DateTime dayAndTime,string status, Client user)
        {
            this.Products = products;
            this.Index = index;
            this.DayAndTime = dayAndTime;
            this.Status = status;
            this.User = user;
            int totalPrice = 0;
            // Считаем общую стоимость заказа.
            foreach(Product product in products)
                totalPrice += int.Parse(product.Price.ToString()) * int.Parse(product.Count.ToString());
            this.TotalPrice = totalPrice;
        }
    }
}
