using System;

class Program
{
    static void Main(string[] args)
    {
        List<float> listNumbers = new List<float>();
        
        Console.Write("Enter a list of numbers, type 0 when finished. ");

        float userNumber = 1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number: ");
            userNumber = float.Parse(Console.ReadLine());
            
            if (userNumber != 0)
            {
                listNumbers.Add(userNumber);
            }
        }

        float sum = 0;
        foreach (float number in listNumbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = sum / listNumbers.Count;
        Console.WriteLine($"The average is: {average}");

        float max = listNumbers[0];

        foreach (int number in listNumbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}