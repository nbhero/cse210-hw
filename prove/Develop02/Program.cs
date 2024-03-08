using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n1. Write a new entry\n2. Display the journal\n3. Save the journal to a file\n4. Load the journal from a file\n5. Exit\n");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.Display();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
                
            }
        }
    }

    static void WriteNewEntry(Journal journal)
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random rand = new Random();
        string randomPrompt = prompts[rand.Next(prompts.Length)];

        Console.WriteLine($"{randomPrompt}");
        Console.Write("Response: ");

        string response = Console.ReadLine();

        JournalEntry entry = new JournalEntry(randomPrompt, response, DateTime.Now);
        journal.AddEntry(entry);
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter a file name to save: ");
        string fileName = Console.ReadLine();

        journal.SaveToFile(fileName);
        Console.WriteLine("Journal Saved!");
    }

    static void LoadJournal(Journal journal)
    {
        Console.WriteLine("Enter the file name to load: ");
        string fileName = Console.ReadLine();

        journal.LoadFile(fileName);
        Console.WriteLine("Journal Loaded!");
    }

}