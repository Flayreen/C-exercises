using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LibraryProject.Services;
using LibraryProject.Core.Models;
using LibraryProject.Core.Interfaces;
using LibraryProject.Entity;

namespace LibraryProject;

internal abstract class Program
{
    private static void Main()
    {
        var host = CreateHostBuilder().Build();
        var libraryService = host.Services.GetRequiredService<LibraryService>();
        
         string useChoice;
         Console.WriteLine("Вас вітає бібліотека!");
         do
         {
             Console.WriteLine("Виберіть дію з переліку, вибравши її номер");
             Console.WriteLine($"1. Переглянути усі книги \n2. Додати книгу \n3. Приховати книгу \n4. Видалити книгу з прихованих \n5. Знайти книгу \n6. Список авторів \n7. Добавити автора \n8. Вихід з програми");
             Console.Write("Ваш вибір: ");
             useChoice = Console.ReadLine();

             switch (useChoice)
             {
                 case "1":
                     Console.Clear();
                     libraryService.ShowAllBooks();
                     Console.Write("\nНажміть будь-яку кнопку, щоб повернутися до головного меню... ");
                     Console.ReadKey();
                     Console.Clear();
                     break;
                 case "2":
                     Console.Clear();
                     libraryService.AddBook();
                     Console.Write("\nНажміть будь-яку кнопку, щоб повернутися до головного меню... ");
                     Console.ReadKey();
                     Console.Clear();
                     break;
                 case "3":
                     Console.Clear();
                     libraryService.HideBook();
                     Console.ReadKey();
                     Console.Clear();
                     break;
                 case "4":
                     Console.Clear();
                     libraryService.DeleteFromHiddenBook();
                     Console.Write("\nНажміть будь-яку кнопку, щоб повернутися до головного меню... ");
                     Console.ReadKey();
                     Console.Clear();
                     break;
                 case "5":
                     Console.Clear();
                     libraryService.FindTheBook();
                     Console.Write("\nНажміть будь-яку кнопку, щоб повернутися до головного меню... ");
                     Console.ReadKey();
                     Console.Clear();
                     break;
                 case "6":
                     Console.Clear();
                     libraryService.ShowAllAuthors();
                     Console.Write("\nНажміть будь-яку кнопку, щоб повернутися до головного меню... ");
                     Console.ReadKey();
                     Console.Clear();
                     break;
                 case "7":
                     Console.Clear();
                     libraryService.AddAuthor();
                     Console.Write("\nНажміть будь-яку кнопку, щоб повернутися до головного меню... ");
                     Console.ReadKey();
                     Console.Clear();
                     break;
                 case "8":
                     Console.WriteLine("Пока!");
                     break;
                 default:
                     Console.Clear();
                     Console.WriteLine("Невірне значення");
                     Console.ReadKey();
                     Console.Clear();
                     break;
             }
         } while (useChoice != "8");
    }
    
    private static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((_, services) =>
            {
                services.AddTransient<ILibraryRepository>(provider => new LibraryRepository());
                services.AddTransient<LibraryService>();
            });
    }
}