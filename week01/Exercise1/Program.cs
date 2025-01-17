using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string firstn = Console.ReadLine();

        Console.Write("What is your last name? ");
        string lastn = Console.ReadLine();

        Console.WriteLine($"Your name is {lastn}, {firstn} {lastn}.");
    }
}