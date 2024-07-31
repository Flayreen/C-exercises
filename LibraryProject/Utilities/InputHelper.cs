namespace LibraryProject.Utilities;

public class InputHelper
{
    public static string NotEmptyInput(string prompt, out string input)
    {
        input = string.Empty;

        while (string.IsNullOrWhiteSpace(input))
        {
            Console.Write(prompt);
            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Це поле є обовʼяковим. Будь ласка, введіть коректне значення");
            }
        }

        return input;
    }

    public static int NotEmptyInput(string prompt, out int input)
    {
        input = 0;

        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Будь ласка, введіть коректне значення: ");
        }

        return input;
    }
}