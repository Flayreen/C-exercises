
namespace Library;

internal abstract class Program
{
    private static void Main()
    {
         string useChoice;
         Console.WriteLine("Вас вітає бібліотека!");
         Library library = new Library();
         do
         {
             Console.WriteLine("Виберіть дію з переліку, вибравши її номер");
             Console.WriteLine($"1. Переглянути усі книги \n2. Додати книгу \n3. Приховати книгу \n4. Видалити книгу з прихованих \n5. Знайти книгу \n6. Список авторів \n8. Вихід з програми");
             Console.Write("Ваш вибір: ");
             useChoice = Console.ReadLine();

             switch (useChoice)
             {
                 case "1":
                     Console.Clear();
                     library.ShowAllBooks();
                     Console.Write("\nНажміть будь-яку кнопку, щоб повернутися до головного меню... ");
                     Console.ReadKey();
                     Console.Clear();
                     break;
                 case "2":
                     Console.Clear();
                     library.AddBook();
                     Console.Write("\nНажміть будь-яку кнопку, щоб повернутися до головного меню... ");
                     Console.ReadKey();
                     Console.Clear();
                     break;
                 case "3":
                     Console.Clear();
                     library.HideBook();
                     Console.ReadKey();
                     Console.Clear();
                     break;
                 case "4":
                     Console.Clear();
                     library.DeleteFromHiddenBook();
                     Console.Write("\nНажміть будь-яку кнопку, щоб повернутися до головного меню... ");
                     Console.ReadKey();
                     Console.Clear();
                     break;
                 case "5":
                     Console.Clear();
                     library.FindTheBook();
                     Console.Write("\nНажміть будь-яку кнопку, щоб повернутися до головного меню... ");
                     Console.ReadKey();
                     Console.Clear();
                     break;
                 case "6":
                     Console.Clear();
                     library.ShowAllAuthors();
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
}
