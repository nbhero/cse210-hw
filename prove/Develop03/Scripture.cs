using System.Data;

class Scripture
{
    private readonly List<Word> _words = new List<Word>();
    private Reference _reference;
    private string _text { get; set; }

    public void Start(string text, string reference)
    {
        this._text = text;

        _reference = new Reference(reference);
        string[] wordArray = text.Split(new char[] { ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in wordArray)
        {
            this._words.Add(new Word { Words = word, IsHidden = false});
        }
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        int hiddenCount = 0;
        if(count > 5)
        {
            count = 5;
        }
        if(count >= this._words.Count(w => !w.IsHidden))
        {
            count = this._words.Count(w => !w.IsHidden);
        }
        while (hiddenCount < count)
        {
            int index = random.Next(0, this._words.Count);

            if(!this._words[index].IsHidden)
            {
                this._words[index].IsHidden = true;
                hiddenCount++;
            }
        }
    }

    public bool CheckWordsHidden()
    {
        return !this._words.Any(w => !w.IsHidden);
    }

    public void Display() // Check Later
    {
        Console.WriteLine(_reference.getDisplayText());

        foreach (Word words in this._words)
        {
            if(words.IsHidden)
            {
                Console.Write($"___");
            }
            else
            {
                Console.Write($"{words.Words}");
            }
        }
        Console.WriteLine();
    }
}