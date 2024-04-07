using System;
using FinalProject;

class Program
{
    static void Main(string[] args)
    {
        UserManager user = new UserManager();

        // user.AddUser(1, "Bruno", "Rafael", 26);
        // user.AddUser(2, "Felipe", "Lima", 26);
        // user.AddUser(5, "Alix", "Torres", 26);
        // user.RemoveUser(3);

        user.UserService();

        
    }
}