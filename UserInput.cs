using System;
using System.Xml.Serialization;

public class UserInput
{
    public static void Info(string info){
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine(info);
        Console.ResetColor();
    }

    public static string AskUserString(string prompt)
    {
        Console.ForegroundColor = ConsoleColor.Yellow; // Set the color to yellow
        Console.Write($"{prompt}: ");
        Console.ResetColor(); // Reset the color back to the default
        return Console.ReadLine();
    }

    public static bool AskUserBool(string prompt)
    {
        Console.ForegroundColor = ConsoleColor.Yellow; // Set the color to yellow
        Console.Write($"{prompt}: ");
        Console.ResetColor(); // Reset the color back to the default
        string UserAnswer = Console.ReadLine();
        if (UserAnswer.StartsWith("y", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}