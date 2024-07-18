namespace Library;

public class Library
{
    private List<Book> BooksList { get; set; } = [];

    public Library()
    {
        BooksList.Add(new Book("Gavno", new Author("Oleg", "Vakarchuk")));
        BooksList.Add(new Book("Galina", new Author("Mikola", "Dobik")));
        BooksList.Add(new Book("Zalupa", new Author("Katya", "Koval")));
        BooksList.Add(new Book("Syka", new Author("Vadim", "Syrenko")));
    }
    public void AddBook()
    {
        string bookTitle = GetNotEmptyInput("Введіть назву книги: ");
        string authorName = GetNotEmptyInput("Введіть імʼя автора ");
        string authorSurname = GetNotEmptyInput("Введіть прізвище автора ");

        Author author = new Author(authorName, authorSurname);
        Book book = new Book(bookTitle, author);
        BooksList.Add(book);

        Console.WriteLine($"Ви успішно добавили книгу - {bookTitle}!");
    }

    public void ShowAllBooks()
    {
        if (BooksList.Count != 0)
        {
            var booksList = BooksList.Where(b => !b.isHidden)
                .OrderBy(b => b.Title)
                .ThenBy(b => b.Author.Name)
                .ThenBy(b => b.Author.Surname)
                .ToList();
            foreach (var books in booksList)
            {
                Console.WriteLine($"{books.Title} - автор {books.Author.Name} {books.Author.Surname}");
            }   
        }
        else
        {
            Console.WriteLine("Бібліотека пуста...");
        }
    }

    public void HideBook()
    {
        if (BooksList.Count != 0)
        {
            foreach (var books in BooksList.Where(b => !b.isHidden))
            {
                Console.WriteLine($"{books.Title} - автор {books.Author.Name} {books.Author.Surname}");
            }

            while (true)
            {
                string hiddenBook = GetNotEmptyInput("\nВведіть назву книги, яку ви хочете приховати: ");
                var bookToHide = BooksList.FirstOrDefault(b => b.Title.ToLower() == hiddenBook.ToLower().Trim());

                if (bookToHide != null)
                {
                    if (!bookToHide.isHidden)
                    {
                        bookToHide.isHidden = true;
                        Console.WriteLine($"Ви успішно приховали книгу {bookToHide.Title} - автор {bookToHide.Author.Name} {bookToHide.Author.Surname}.");
                        Console.WriteLine("Нажміть будь-яку кнопку, щоб продовжити");
                        Console.WriteLine("Enter - вийти до головного меню");
                        
                        var key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.Enter)
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Книга {bookToHide.Title} вже прихована");
                    }
                }
                else
                {
                    Console.WriteLine("Не знайдено книги за цією назвою");
                }   
            }
        }
        else
        {
            Console.WriteLine("Бібліотека пуста...");
        }
    }
    
    public void DeleteFromHiddenBook()
    {
        var hiddenBooksList = BooksList.Where(b => b.isHidden).ToList();
        if (hiddenBooksList.Count != 0)
        {
            Console.WriteLine("Перелік прихованих книг");
            foreach (var books in hiddenBooksList)
            {
                Console.WriteLine($"{books.Title} - автор {books.Author.Name} {books.Author.Surname}");
            }
            
            string shownBook = GetNotEmptyInput("\nВведіть назву книги, яку ви хочете видалити з прихованих: ");
            var bookToHide = hiddenBooksList.FirstOrDefault(b => b.Title.ToLower() == shownBook.ToLower().Trim());

            if (bookToHide != null)
            {
                if (bookToHide.isHidden)
                {
                    bookToHide.isHidden = false;
                    Console.WriteLine($"Ви успішно видалили з прихованих книгу {bookToHide.Title} - автор {bookToHide.Author.Name} {bookToHide.Author.Surname}");   
                }
                else
                {
                    Console.WriteLine($"Книга {bookToHide.Title} не прихована");
                }
            }
            else
            {
                Console.WriteLine("Не знайдено книги за цією назвою");
            }
        }
        else
        {
            Console.WriteLine("Немає прихованих книг...");
        }
    }

    public void FindTheBook()
    {
        if (BooksList.Count != 0)
        {
            string searchPhrase = GetNotEmptyInput("Введіть назву книгу, імʼя або фамілію автора: ").ToLower().Trim();
            var selectBooks = BooksList.Where(b => b.Title.ToLower().Contains(searchPhrase) 
                                                  || b.Author.Name.ToLower().Contains(searchPhrase) 
                                                  || b.Author.Surname.ToLower().Contains(searchPhrase)).ToList();
            if (selectBooks.Count != 0)
            {
                Console.WriteLine("Результат:");
                foreach (var book in selectBooks)
                {
                    Console.WriteLine($"Книга {book.Title} - автор {book.Author.Name} {book.Author.Surname}");
                }
            }
            else
            {
                Console.WriteLine("По вашому запиту нічого не знайдено!");
            }
        }
        else
        {
            Console.WriteLine("Бібліотека пуста, щоб щось шукати...");
        }
    }
    
    private static string GetNotEmptyInput(string prompt)
    {
        string? input = string.Empty;

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
    
   
}