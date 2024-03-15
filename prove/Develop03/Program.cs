using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture();
        scripture.Start("And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.", "1 Nephi 3:7");

        bool allWordsHidden = false;
        int hiddenWordCount = 1;

        while (!allWordsHidden)
        {
            Console.Clear();
            scripture.Display();

            Console.WriteLine("Press Enter to hide more words, o type 'quit' to exit the Scripture Memorizer.");
            string userInput = Console.ReadLine();

            if(userInput.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(hiddenWordCount);
            allWordsHidden = scripture.CheckWordsHidden();
        }
        Console.Clear();
        scripture.Display();
    }
}