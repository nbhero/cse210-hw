using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();
    
    public void AddEntry(JournalEntry entry)
    {
        entries.Add(entry);
    }
    public void Display()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }
    }

    public void LoadFile(string fileName)
    {
        entries.Clear();
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                {
                    string prompt = parts[1];
                    string response = parts[2];
                    DateTime date = DateTime.Parse(parts[0]);
                    entries.Add(new JournalEntry(prompt, response, date));
                }
                
            }
        }
    }
}