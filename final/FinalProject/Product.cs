namespace FinalProject
{
    class Product
    {
        public int _id { get; set; }
        public string _name { get; set; }
        public decimal _price { get; set; }
        public int _quantity { get; set; }
        private bool _teste;

        public Product(int id, string name, decimal price, int quantity, bool teste = true)
        {
            _id = id;
            _name = name;
            _price = price;
            _quantity = quantity;
            _teste = teste;
        }

        public void ProductReport()
        {
            Console.WriteLine($"ID: {_id} - Product: {_name} | Price: $ {_price} | Quantity: {_quantity}");
        }
    }
}