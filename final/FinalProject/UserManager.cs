using System.ComponentModel.DataAnnotations.Schema;
using FinalProject;

public class UserManager
{
    private Dictionary<int, User> users = new Dictionary<int, User>();

    public void UserService()
    {
        bool exitService = false;
        while (!exitService)
        {
            Console.WriteLine();
			Console.WriteLine($"Store Manager: User");
			Console.WriteLine();
            Console.WriteLine("1. Add User");
			Console.WriteLine("2. Remove User");
            Console.WriteLine("3. Search User by ID");
            Console.WriteLine("4. List all users");
            Console.WriteLine("5. Return");
			
            Console.Write("Select an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    UserRegistration();
                    break;
                case "2":
                    RemoveUser();
                    break;
                case "3":
                    SearchUser();
                    break;
                case "4":
                    ListAllUsers();
                    break;
                case "5":
                    exitService = true;
                    break;
                default:
                    Console.WriteLine("The chosen option does not exist.");
                    break;
            }
        }
    }

    public void UserRegistration()
    {
        
        Console.Write("What's the ID? ");
        string userId = Console.ReadLine();
        int userIdFormatted = int.Parse(userId);
        Console.Write("What's the first name? ");
        string firstName = Console.ReadLine();
        Console.Write("What's the last name? ");
        string lastName = Console.ReadLine();
        Console.Write("What's the age? ");
        string age = Console.ReadLine();
        int ageFormatted = int.Parse(age);

        AddUser(userIdFormatted, firstName, lastName, ageFormatted);

    }

    public void SearchUser()
    {
        Console.Write("What's the ID? ");
        string userId = Console.ReadLine();
        int userIdFormatted = int.Parse(userId);
        DisplayUserInfo(userIdFormatted);
    }

    public void RemoveUser()
    {
        Console.Write("What's the ID? ");
        string userId = Console.ReadLine();
        int userIdFormatted = int.Parse(userId);
        Remove(userIdFormatted);
    }

    // Method for adding a new user
    private void AddUser(int id, string firstName, string lastName, int age)
    {
        if (!users.ContainsKey(id))
        {
            Console.Clear();
            users.Add(id, new User(id, firstName, lastName, age));
            Console.WriteLine("User registered successfully!");
        }
        else
        {
            Console.WriteLine($"User with ID {id} already exists.");
        }
    }

    // Method to display an specific user info
    private void DisplayUserInfo(int id)
    {
        if (users.TryGetValue(id, out User user))
        {
            Console.Clear();
            // Console.WriteLine($"User ID: {user._userId}, Name: {user._firstName} {user._lastName}");
            user.UserReport(user._userId, user._firstName, user._lastName, user._age);
        }
        else
        {
            Console.WriteLine($"User with ID {id} not found.");
        }
    }

    // Method to remove a user
    public void Remove(int id)
    {
        if (users.Remove(id))
        {
            Console.Clear();
            Console.WriteLine($"User with ID {id} removed successfully.");
        }
        else
        {
            Console.WriteLine($"No user found with ID {id}.");
        }
    }

    public void ListAllUsers()
    {
        if (users.Values.Count != 0)
            {
                Console.Clear();
                foreach (var user in users.Values)
                {
                    Console.WriteLine($"User ID: {user._userId}, Name: {user._firstName} {user._lastName}");
                }
                
            }
            else
            {
                Console.WriteLine("There are no users to be listed.");
            }
    }

}