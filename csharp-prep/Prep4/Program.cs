using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int user_input = -1;
        
        while (user_input != 0)
        {
            Console.Write("Enter a number (Press 0 to Quit): ");
            string answer = Console.ReadLine();
            user_input = int.Parse(answer);

            if (user_input != 0)
            {
                numbers.Add(user_input);
            }

            
        }
        int sum = 0;

        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");
        
        int max = numbers[0];
        

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The highest number is: {max}");
    }
}