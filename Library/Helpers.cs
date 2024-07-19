using System.Text.Json;

namespace Library;

public abstract class Helpers
{
    protected static string NotEmptyInput(string prompt, out string input)
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
    
    protected static int NotEmptyInput(string prompt, out int input)
    {
        input = 0;

        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Будь ласка, введіть коректне значення: ");
        }

        return input;
    }
    
    protected static void WriteFileBooks(string path, List<Book> booksList)
    {
        string booksListJson = JsonSerializer.Serialize(booksList);
        File.WriteAllText(path, booksListJson);
    }
    
    protected static List<Book>? ReadFileBooks(string path)
    {
        string booksListString = File.ReadAllText(path);
        var booksList = JsonSerializer.Deserialize<List<Book>>(booksListString);
        return booksList;
    }
}