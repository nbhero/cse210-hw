using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string welcomeMessage = "Welcome to the Activity Tracker!";
        string menuMessage = "Please choose an activity:";
        Console.WriteLine(welcomeMessage);
        while(true){
            Console.Clear();
            Console.WriteLine(menuMessage);
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listening");
            Console.WriteLine("4. Exit");
            Console.WriteLine("--------------------");
            string input = Console.ReadLine();
            switch(input){
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.DisplayStartingMessage();
                    breathing.Run();
                    breathing.DisplayEndingMessage();
                    break;
                case "2":
                    ReflectionActivity reflextion = new ReflectionActivity();
                    reflextion.DisplayStartingMessage();
                    reflextion.Run();
                    reflextion.DisplayEndingMessage();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.DisplayStartingMessage();
                    listing.Run();
                    listing.DisplayEndingMessage();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter a valid input.");
                    break;
            }
        }
    }
}