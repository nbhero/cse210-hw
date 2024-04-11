namespace FinalProject
{
    class Supplier
    {
        public int _id { get; }
        public string _name { get; }
        public string _email { get; }
        private bool _active;

        public Supplier(int id, string name, string email, bool active = true)
        {
            _id = id;
            _name = name;
            _email = email;
            this._active = active;
        }

        public void SupplierReport()
        {
            string status = _active ? "Active" : "Inactive";
            Console.WriteLine($"Supplier ID: {_id} - Name: {_name} | E-mail: {_email} | Status: {status}");
        }
        
        public void SetSupplierInactive(int id)
        {
            _active = false;
        }

        public void SetSupplierActive(int id)
        {
            _active = true;
        }
    }
}