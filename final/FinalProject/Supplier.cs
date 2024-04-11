namespace FinalProject
{
    class Supplier
    {
        private Dictionary<int, Supplier> _suppliers = new Dictionary<int, Supplier>();
        private int _id;
        private string _name;
        private string _email;

        public Supplier(int id, string name, string email)
        {
            _id = id;
            _name = name;
            _email = email;
        }

        public void AddSupplier(int id, string name, string email)
        {
            if (!_suppliers.ContainsKey(id))
            {
                Console.Clear();
                _suppliers.Add(id,  new Supplier(id, name, email));
                Console.WriteLine("Supplier registered successfully!");
            }
            else
            {
                Console.WriteLine($"Supplier with ID {id} already registered.");
            }
        }

        public void ListAllSuppliers()
        {
            foreach (var supplier in _suppliers)
            {
                Console.WriteLine(supplier.Value._id);
            }
        }
    }
}