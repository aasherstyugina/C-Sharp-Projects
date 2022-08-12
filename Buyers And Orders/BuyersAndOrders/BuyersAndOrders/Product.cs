namespace BuyersAndOrders
{
    public class Product
    {
        // Поля объекта товар.
        public string Name;
        public string Article;
        public int Price;
        public int Count;

        /// <summary>
        /// Конструктор объекта товар.
        /// </summary>
        /// <param name="name"> Наименование. </param>
        /// <param name="article"> Артикул. </param>
        /// <param name="price"> Цена. </param>
        /// <param name="count"> Количество. </param>
        public Product(string name, string article, int price, int count)
        {
            this.Name = name;
            this.Article = article;
            this.Price = price;
            this.Count = count;
        }
    }
}
