using System;

class MainClass
{
    // Method check input string from console. Is not null of empty and length >= length
    public static bool stringChecker(string inputString, int length)
    {
        if (!String.IsNullOrEmpty(inputString) && inputString.Length >= length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Recursive method get text from console, check (use check method) and return valui value
    public static string getStringFromConsole(string message, int length)
    {
        Console.Write(message);
        var textFromConsole = Console.ReadLine();
        if (stringChecker(textFromConsole, length))
        {
            return textFromConsole;
        }
        else
        {
            return getStringFromConsole(message, length);
        }
    }

    // Method check int value, if NOT int - return 0
    public static int checkInt(string inputString)
    {
        int tempInt = 0;
        int.TryParse(inputString, out tempInt);
        return tempInt;
    }

    // Recoursive method, get values from console, check (use check method) and return valui value
    public static int getIntFromConsole(string message)
    {
        Console.Write(message);
        var textFromConsole = Console.ReadLine();
        if (!string.IsNullOrEmpty(textFromConsole))
        {
            if (checkInt(textFromConsole) > 0)
            {
                return checkInt(textFromConsole);
            }
            else
            {
                return getIntFromConsole(message);
            }
        }
        else
        {
            return getIntFromConsole(message);
        }
    }

    // Method get from console "count" values and return string[count] array
    public static string[] getArrayStringFromConsole(int count)
    {
        string[] returnArray = new string[count];
        for (int i = 0; i < count; i++)
        {
            returnArray[i] = getStringFromConsole($"Enter name of Pet number {i + 1}:", 2);
        }
        return returnArray;
    }

    // Recoursive method get from console string value, check (use check method) and return correct bool value
    public static bool getBooleanFromConsole(string message)
    {
        Console.Write(message);
        var textFromConsole = Console.ReadLine();
        if (!String.IsNullOrEmpty(textFromConsole) && (textFromConsole.ToLower().Trim() == "yes" || textFromConsole.ToLower().Trim() == "y" || textFromConsole.ToLower().Trim() == "да" || textFromConsole.ToLower().Trim() == "д"))
        {
            return true;
        }
        else if (!String.IsNullOrEmpty(textFromConsole) && (textFromConsole.ToLower().Trim() == "no" || textFromConsole.ToLower().Trim() == "n" || textFromConsole.ToLower().Trim() == "нет" || textFromConsole.ToLower().Trim() == "н"))
        {
            return false;
        }
        else
        {
            return getBooleanFromConsole(message);
        }
    }

    // Main Input method, compile many values from other methods in cortege and return it
    public static (string, string, int, bool, int, string[], int, string[]) InputMethod()
    {
        string firstName = getStringFromConsole("Enter Firstname:", 3);
        string secondName = getStringFromConsole("Enter Secondname:", 3);
        int age = getIntFromConsole("How old are you?:");
        bool havePet = getBooleanFromConsole("Have you a pet? (Yes/No):");
        int petCount;
        string[] patNames;
        if (havePet)
        {
            petCount = getIntFromConsole("How many pet do you have?:");
            patNames = getArrayStringFromConsole(petCount);
        }
        else
        {
            petCount = 0;
            patNames = new string[0];
        }
        int favoriteColorsCount = getIntFromConsole("How many favorite color do you have?:");
        string[] colorNames = getArrayStringFromConsole(favoriteColorsCount);
        var result = (firstName: firstName, secondName: secondName, age: age, havePet: havePet, petCount: petCount, patNames: patNames, favoriteColorsCount: favoriteColorsCount, colorNames: colorNames);
        return result;
    }

    // Method write in console all values from input cortage
    public static void OutputMethod((string firstName, string secondName, int age, bool havePet, int petCount, string[] patNames, int favoriteColorsCount, string[] colorNames) inputCortege)
    {
        Console.WriteLine($"Your name is \"{inputCortege.firstName}\"");
        Console.WriteLine($"Your second name is \"{inputCortege.secondName}\"");
        Console.WriteLine($"You {inputCortege.age} Years old");

        if (inputCortege.havePet)
        {
            Console.WriteLine($"You have {inputCortege.petCount} pets");
            string petNames = "";

            foreach (string petName in inputCortege.patNames)
            {
                petNames += $" {petName},";
            }
            Console.Write($"His names is:{petNames.TrimEnd(',')}");
        }
        else
        {
            Console.WriteLine($"You have no pets");
        }
        Console.WriteLine();

        string colornames = "";

        foreach (string colorName in inputCortege.colorNames)
        {
            colornames += $" {colorName},";
        }
        Console.Write($"You have {inputCortege.favoriteColorsCount} favorites colors:{colornames.TrimEnd(',')}");
    }

    // Main method, just start
    public static void Main(string[] args)
    {
        OutputMethod(InputMethod());
    }
}