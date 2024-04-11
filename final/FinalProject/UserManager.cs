using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace FinalProject
{
    public class UserManager
    {
        private Dictionary<int, User> users = new Dictionary<int, User>();

        public void UserService()
        {
            bool exitService = false;
            while (!exitService)
            {
                Console.WriteLine($"\nStore Manager: User\n");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Remove User");
                Console.WriteLine("3. Search User by ID");
                Console.WriteLine("4. List all users");
                Console.WriteLine("5. Return");
                
                Console.Write("What menu do you want to access? Choose a number: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        RegisterUser();
                        break;
                    case "2":
                        PromptToRemoveUser();
                        break;
                    case "3":
                        PromptToSearchUser();
                        break;
                    case "4":
                        DisplayAllUsers();
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

        private void RegisterUser()
        {
            try
            {
                Console.Write("What's the ID? ");
                int userId = int.Parse(Console.ReadLine());
                Console.Write("What's the first name? ");
                string firstName = Console.ReadLine();
                Console.Write("What's the last name? ");
                string lastName = Console.ReadLine();
                Console.Write("What's the age? ");
                int age = int.Parse(Console.ReadLine());

                AddUser(userId, firstName, lastName, age);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter the correct format.");
            }

        }

        private void PromptToSearchUser()
        {
            try
            {
                Console.Write("What's the ID? ");
                int userId = int.Parse(Console.ReadLine());
                DisplayUserInfo(userId);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
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
                user.UserReport();
            }
            else
            {
                Console.WriteLine($"User with ID {id} not found.");
            }
        }

        // Method to remove a user
        private void PromptToRemoveUser()
        {
            try
            {
                Console.Write("What's the ID? ");
                int userId = int.Parse(Console.ReadLine());
                RemoveUser(userId);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        
        private void RemoveUser(int id)
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

        private void DisplayAllUsers()
        {
            if (users.Values.Count > 0)
                {
                    Console.Clear();
                    foreach (var user in users.Values)
                    {
                        user.UserReport();
                    }
                    
                }
                else
                {
                    Console.WriteLine("There are no users to be listed.");
                }
        }

    }
}

