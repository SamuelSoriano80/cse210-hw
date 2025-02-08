using System;
using System.Collections.Generic;
using System.Linq;

// The program chooses a program at random
class ScriptureReference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; }

    public ScriptureReference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        return EndVerse.HasValue ? $"{Book} {Chapter}:{StartVerse}-{EndVerse}" : $"{Book} {Chapter}:{StartVerse}";
    }
}

class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public override string ToString()
    {
        return IsHidden ? new string('_', Text.Length) : Text;
    }
}

class Scripture
{
    public ScriptureReference Reference { get; }
    private List<Word> Words { get; }

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int count)
    {
        Random rnd = new Random();
        var visibleWords = Words.Where(w => !w.IsHidden).ToList();

        if (visibleWords.Count == 0)
            return;

        int wordsToHide = Math.Min(count, visibleWords.Count);
        for (int i = 0; i < wordsToHide; i++)
        {
            Word wordToHide = visibleWords[rnd.Next(visibleWords.Count)];
            wordToHide.Hide();
            visibleWords.Remove(wordToHide);
        }
    }

    public bool AllWordsHidden()
    {
        return Words.All(w => w.IsHidden);
    }

    public override string ToString()
    {
        return $"{Reference}\n{string.Join(" ", Words)}";
    }
}

class Program
{
    static List<Scripture> scriptures = new List<Scripture>
    {
        new Scripture(new ScriptureReference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
        new Scripture(new ScriptureReference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
        new Scripture(new ScriptureReference("Romans", 8, 28), "And we know that all things work together for good to them that love God, to them who are the called according to his purpose."),
    };

    static void Main()
    {
        Random rnd = new Random();
        Scripture selectedScripture = scriptures[rnd.Next(scriptures.Count)];

        while (true)
        {
            try
            {
                Console.Clear();
            }
                catch (Exception)
            {
                Console.WriteLine("\n[Console Clear Unsupported: Screen will not be cleared. This program works but you can't use it in debugging]");
            }

            Console.WriteLine(selectedScripture);
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();
            
            if (input?.ToLower() == "quit")
                break;
            
            selectedScripture.HideRandomWords(2);
            
            if (selectedScripture.AllWordsHidden())
            {
                try
                {
                    Console.Clear();
                }
                    catch (Exception)
                {
                    Console.WriteLine("\n[Console Clear Unsupported: Screen will not be cleared. This program works but you can't use it in debugging]");
                }
                
                Console.WriteLine(selectedScripture);
                Console.WriteLine("\nAll words are hidden. Program ending.");
                break;
            }
        }
    }
}
