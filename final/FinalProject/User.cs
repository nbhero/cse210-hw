namespace FinalProject
{
    class User
    {
        public int _userId { get; set; }
        public string _firstName { get; set; }
        public string _lastName { get; set; }
        private bool _active { get; set; }
        public int _age { get; set; }
        private bool _admin { get; set; }

        public User(int id, string firstName, string lastName, int age, bool active = true, bool admin = false)
        {
            _userId = id;
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
        }

        public void UserReport(int id, string firstName, string lastName, int age, bool active = true, bool admin = false)
        {
            _userId = id;
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
            _active = active;
            _admin = admin;

            if (active == true)
            {
                string status = "Active";
                Console.WriteLine($"User ID: {id}\nName: {firstName} {lastName}\nAge: {age}\nStatus: {status}\nAdmin Permission: {admin}");
            }
            else
            {
                string status = "Inactive";
                Console.WriteLine($"User ID: {id}\nName: {firstName} {lastName}\nAge: {age}\nStatus: {status}\nAdmin Permission: {admin}");
            }
        }
    }
    
}