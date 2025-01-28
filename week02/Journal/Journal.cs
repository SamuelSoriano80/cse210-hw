using System;

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "In a scale of 1 to 10 how would I rate today?",
        "Did I do something to take care of my health today?",
        "What could I have done to make today better?",
        "How did I help someone today?",
        "What are the things that I have to do today?"
    };

    public void AddEntry()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your Response: ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        
        Console.Write("Enter tags for this entry (comma-separated): ");
        string tagsInput = Console.ReadLine();
        List<string> tags = new List<string>(tagsInput.Split(',', StringSplitOptions.RemoveEmptyEntries));

        for (int i = 0; i < tags.Count; i++)
        {
            tags[i] = tags[i].Trim();
        }

    entries.Add(new Entry(prompt, response, date, tags));
    Console.WriteLine("Entry added successfully!\n");
}

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries to display.\n");
            return;
        }

        Console.WriteLine("Journal Entries:\n");
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter the filename to save the journal: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    string tags = string.Join(",", entry.Tags);
                    writer.WriteLine($"{entry.Date}~|~{entry.Prompt}~|~{entry.Response}~|~{tags}");
                }
            }
            Console.WriteLine("Journal saved successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving the journal: {ex.Message}\n");
        }
    }

    public void LoadFromFile()
    {
        Console.Write("Enter the filename to load the journal: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                entries.Clear();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split("~|~");
                    if (parts.Length == 4)
                    {
                        var tags = new List<string>(parts[3].Split(',', StringSplitOptions.RemoveEmptyEntries));
                        entries.Add(new Entry(parts[1], parts[2], parts[0], tags));
                    }
                }
            }
            Console.WriteLine("Journal loaded successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading the journal: {ex.Message}\n");
        }
    }
}