
namespace Library;

internal abstract class Program
{
    private static void Main()
    {
         int useChoice;
         Console.WriteLine("Вас вітає бібліотека!");
         Library library = new Library();
         do
         {
             Console.WriteLine("Виберіть дію з переліку, вибравши її номер");
             Console.WriteLine($"1. Переглянути усі книги \n2. Додати книгу \n3. Приховати книгу \n4. Видалити книгу з прихованих \n5. Знайти книгу \n6. Вихід з програми");
             Console.Write("Ваш вибір: ");
             useChoice = Convert.ToInt32(Console.ReadLine());

             switch (useChoice)
             {
                 case 1:
                     Console.Clear();
                     library.ShowAllBooks();
                     Console.ReadKey();
                     Console.Clear();
                     break;
                 case 2:
                     Console.Clear();
                     library.AddBook();
                     Console.ReadKey();
                     Console.Clear();
                     break;
                 case 3:
                     Console.Clear();
                     library.HideBook();
                     Console.ReadKey();
                     Console.Clear();
                     break;
                 case 4:
                     Console.Clear();
                     library.DeleteFromHiddenBook();
                     Console.ReadKey();
                     Console.Clear();
                     break;
                 case 5:
                     Console.Clear();
                     library.FindTheBook();
                     Console.ReadKey();
                     Console.Clear();
                     break;
                 case 6:
                     Console.WriteLine("Пока!");
                     break;
                 default:
                     Console.Clear();
                     Console.WriteLine("Невірне значення");
                     Console.ReadKey();
                     Console.Clear();
                     break;
             }
         } while (useChoice != 6);
    }
}
