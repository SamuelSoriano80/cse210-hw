using System;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Understanding C# Classes", "John Doe", 600);
        Video video2 = new Video("Recipe for pumpkin pie", "Claudia Gonzalez", 720);
        Video video3 = new Video("Can you win a Marvel Rivals match without moving?", "Isaac Soriano", 900);

        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "This really helped me"));
        video1.AddComment(new Comment("Charlie", "Thank you, plus one subscriber"));

        video2.AddComment(new Comment("David", "Awesome tutorial!"));
        video2.AddComment(new Comment("Eva", "Can you make one on cheesecake?"));
        video2.AddComment(new Comment("Frank", "I did it and it was delicious, thanks!"));

        video3.AddComment(new Comment("Grace", "I can't believe you actually did it!"));
        video3.AddComment(new Comment("Henry", "Technically it was thanks to your teammates..."));
        video3.AddComment(new Comment("Sam", "first comment"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}
