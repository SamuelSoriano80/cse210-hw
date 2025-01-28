using System;

public class Entry
{
    public string Prompt {get; set;}
    public string Response {get; set;}
    public string Date {get; set;}
    public List<string> Tags { get; set; }

    public Entry(string prompt, string response, string date, List<string> tags)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
        Tags = tags;
    }

    public override string ToString()
    {
        string tags = Tags.Count > 0 ? string.Join(", ", Tags) : "No Tags";
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\nTags: {tags}\n";
    }
}