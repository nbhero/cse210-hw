namespace FinalProject
{
    class User
    {
        public int _userId { get; set; }
        public string _firstName { get; set; }
        public string _lastName { get; set; }
        public int _age { get; set; }
        private bool _active;
        private bool _admin;

        public User(int id, string firstName, string lastName, int age, bool active = true, bool admin = false)
        {
            _userId = id;
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
            this._active = active;
            this._admin = admin;
        }

        public void UserReport()
        {
            string status = _active ? "Active" : "Inactive";
            Console.WriteLine($"User ID: {_userId} - Name: {_firstName} {_lastName} | Age: {_age} | Status: {status} | Admin: {_admin}");
        }

        public void SetUserInactive(int id)
        {
            _active = false;
        }

        public void SetUserActive(int id)
        {
            _active = true;
        }
    }
    
}