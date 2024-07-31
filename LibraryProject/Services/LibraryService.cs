using LibraryProject.Core.Interfaces;
using LibraryProject.Core.Models;

namespace LibraryProject.Services;

public class LibraryService : ILibraryService
{
    private readonly ILibraryRepository _libraryRepository;

    public LibraryService(ILibraryRepository libraryRepository)
    {
        _libraryRepository = libraryRepository;
    }

    public void AddBook()
    {
        NotEmptyInput("Введіть назву книги: ", out string bookTitle);
        NotEmptyInput("Введіть рік видачі книги ", out int bookYear);
        
        // Перевірка, чи є ця книга в нашій бібліотеці
        var findBook = Library.BooksList.FirstOrDefault(b =>
            b.Title.ToLower() == bookTitle.ToLower().Trim() 
            && b.Year == bookYear 
        );
        
        if (findBook == null)
        {
            NotEmptyInput("Введіть імʼя автора ", out string authorName);
            NotEmptyInput("Введіть прізвище автора ", out string authorSurname);
            
            var findAuthor = Library.AuthorsList.FirstOrDefault(a => a.Name == authorName && a.Surname == authorSurname);
            
            // Перевірка, чи є нас такий автор в списку бібліотеки
            if (findAuthor == null)
            {
                NotEmptyInput("Введіть коротку біографія автора ", out string authorBiography);
                Author author = new Author(authorName, authorSurname, authorBiography);
                Book book = new Book(bookTitle, bookYear, author.Id);
                author.BooksList.Add(book);
                Library.BooksList.Add(book);
                Library.AuthorsList.Add(author);
            }
            else
            {
                Book book = new Book(bookTitle, bookYear, findAuthor.Id);
                findAuthor.BooksList.Add(book);
                Library.BooksList.Add(book);
            }

            _libraryRepository.SaveData();
            Console.WriteLine($"Ви успішно добавили книгу - {bookTitle}!");   
        }
        else
        {
            Console.WriteLine("Дана книга вже наявна є в бібліотеці");
        }
    }
    
    public void ShowAllBooks()
    {
        if (Library.BooksList.Any(b => !b.IsHidden))
        {
            var booksList = Library.BooksList.Where(b => !b.IsHidden)
                .OrderBy(b => b.Title)
                .ThenBy(b => b.Year)
                .ThenBy(b => Library.AuthorsList.FirstOrDefault(a => a.Id == b.AuthorId)!.Name)
                .ThenBy(b => Library.AuthorsList.FirstOrDefault(a => a.Id == b.AuthorId)!.Surname)
                .ToList();
            
            foreach (var books in booksList)
            {
                Console.WriteLine($"Книга \"{books.Title}\", рік видачі {books.Year} - автор {Library.AuthorsList.FirstOrDefault(a => a.Id == books.AuthorId)!.Name} {Library.AuthorsList.FirstOrDefault(a => a.Id == books.AuthorId)!.Surname}");
            }   
        }
        else
        {
            Console.WriteLine("Бібліотека пуста...");
        }
    }
    
    public void HideBook()
    {
        if (Library.BooksList.Any(b => !b.IsHidden))
        {
            foreach (var books in Library.BooksList.Where(b => !b.IsHidden))
            {
                Console.WriteLine($"Книга {books.Title}, рік видачі {books.Year} - автор {Library.AuthorsList.FirstOrDefault(a => a.Id == books.AuthorId)!.Name} {Library.AuthorsList.FirstOrDefault(a => a.Id == books.AuthorId)!.Surname}");
            }
            
            NotEmptyInput("\nВведіть назву книги, яку ви хочете приховати: ", out string hiddenBook);
            var bookToHide = Library.BooksList.FirstOrDefault(b => b.Title.ToLower().Trim() == hiddenBook.ToLower().Trim());

            if (bookToHide != null)
            {
                if (!bookToHide.IsHidden)
                {
                    bookToHide.IsHidden = true;
                    _libraryRepository.SaveData();
                    
                    Console.WriteLine($"Ви успішно приховали книгу {bookToHide.Title}");
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
        else
        {
            Console.WriteLine("Бібліотека пуста...");
        }
    }
    
    public void DeleteFromHiddenBook()
    {
        var hiddenBooksList = Library.BooksList.Where(b => b.IsHidden).ToList();
        if (hiddenBooksList.Count != 0)
        {
            Console.WriteLine("Перелік прихованих книг");
            foreach (var books in hiddenBooksList)
            {
                Console.WriteLine($"Книга {books.Title}, рік видачі {books.Year} - автор {Library.AuthorsList.FirstOrDefault(a => a.Id == books.AuthorId)!.Name} {Library.AuthorsList.FirstOrDefault(a => a.Id == books.AuthorId)!.Surname}");
            }
            
            NotEmptyInput("\nВведіть назву книги, яку ви хочете видалити з прихованих: ", out string shownBook);
            var bookToHide = hiddenBooksList.FirstOrDefault(b => b.Title.ToLower() == shownBook.ToLower().Trim());

            if (bookToHide != null)
            {
                if (bookToHide.IsHidden)
                {
                    bookToHide.IsHidden = false;
                    _libraryRepository.SaveData();
                    Console.WriteLine($"Ви успішно видалили з прихованих книгу {bookToHide.Title}");   
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
        if (Library.BooksList.Any(b => !b.IsHidden))
        {
            NotEmptyInput("Введіть назву книгу, рік видачі, імʼя або фамілію автора: ", out string searchPhrase);
            var selectBooks = Library.BooksList.Where(b => 
                b.Title.ToLower().Contains(searchPhrase.ToLower().Trim()) || 
                b.Year.ToString().Contains(searchPhrase.ToLower().Trim())).ToList();
            
            if (selectBooks.Count != 0)
            {
                Console.WriteLine("Результат:");
                foreach (var book in selectBooks)
                {
                    Console.WriteLine($"Книга {book.Title}, рік видачі {book.Year} - автор {Library.AuthorsList.FirstOrDefault(a => a.Id == book.AuthorId)!.Name} {Library.AuthorsList.FirstOrDefault(a => a.Id == book.AuthorId)!.Surname}");
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
    
    public void ShowAllAuthors()
    {
        if (Library.AuthorsList.Count > 0)
        {
            var authorList = Library.AuthorsList.OrderBy(a => a.Name).ThenBy(a => a.Surname).ToList();
            
            foreach (var author in authorList)
            {
                Console.WriteLine($"Автор - {author.Name} {author.Surname}");
                Console.WriteLine($"Біографія - {author.Biography}");
                Console.Write("Книги: ");
                foreach (var book in author.BooksList)
                {
                    Console.Write(book.Title + ", ");
                }
                Console.WriteLine("\n");
            }   
        }
        else
        {
            Console.WriteLine("Список авторів пустий...");
        }
    }

    public void AddAuthor()
    {
        NotEmptyInput("Введіть імʼя автора: ", out string authorName);
        NotEmptyInput("Введіть фамілію автора: ", out string authorSurname);

        var findAuthor = Library.AuthorsList.FirstOrDefault(a => 
            a.Name.ToLower().Trim() == authorName.ToLower().Trim() 
            && a.Surname.ToLower().Trim() == authorSurname.ToLower().Trim());

        if (findAuthor == null)
        {
            NotEmptyInput("Введіть коротку біографію автора: ", out string authorBiography);
            
            Author author = new Author(authorName, authorSurname, authorBiography);
            Library.AuthorsList.Add(author);
            _libraryRepository.SaveData();
        }
        else
        {
            Console.WriteLine($"{findAuthor.Name} {findAuthor.Surname} вже наявний в списку авторів!");
        }
    }
    
    

    private static string NotEmptyInput(string prompt, out string input)
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

    private static int NotEmptyInput(string prompt, out int input)
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