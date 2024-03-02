using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUser();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string PromptUser()
        {
            Console.Write("Please, enter your name: ");
            string username = Console.ReadLine();

            return username;
        }

        static int PromptUserNumber()
        {
            Console.Write("What's your favorite number? ");
            string number = Console.ReadLine();
            int favNumber = int.Parse(number);

            return favNumber;
        }
        
        static int SquareNumber(int number)
        {
            int square = number * number;
            
            return square;
        }

        static void DisplayResult(string name, int number)
        {
            Console.WriteLine($"{name}, the square of your number is {number}.");
        }
    }
}