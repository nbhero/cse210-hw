using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        Random randomGen = new Random();
        int magicnumber = randomGen.Next(1, 101);

        int guess = -1;

        while (guess != magicnumber)
        {
            Console.WriteLine("What's your guess? ");
            guess = int.Parse(Console.ReadLine());
            
            if (magicnumber > guess)
            {
                Console.WriteLine("Higher!");
            }
            else if (magicnumber < guess)
            {
                Console.WriteLine("Lower!");
            }
            else
            {
                Console.WriteLine("You guessed the right number!");
            }
        }
        
    }
}