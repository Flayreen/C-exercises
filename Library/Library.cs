namespace Library;
public class Library : Helpers
{
    private const string PathToBooksFile = "/Users/olegvakarcuk/RiderProjects/C-exercises/Library/books.json";
    private List<Book> BooksList { get; set; } = ReadFileBooks(PathToBooksFile) ?? [];
    
    public void AddBook()
    {
        NotEmptyInput("Введіть назву книги: ", out string bookTitle);
        NotEmptyInput("Введіть рік видачі книги ", out int bookYear);
        NotEmptyInput("Введіть імʼя автора ", out string authorName);
        NotEmptyInput("Введіть прізвище автора ", out string authorSurname);

        var findBook = BooksList.FirstOrDefault(b =>
            b.Title.ToLower() == bookTitle.ToLower().Trim() 
            && b.Year == bookYear 
            && b.Author.Name.ToLower() == authorName.ToLower().Trim() 
            && b.Author.Surname.ToLower() == authorSurname.ToLower().Trim()
        );

        if (findBook == null)
        {
            Author author = new Author(authorName, authorSurname);
            Book book = new Book(bookTitle, bookYear, author);
            BooksList.Add(book);
            WriteFileBooks(PathToBooksFile, BooksList);
            
            Console.WriteLine($"Ви успішно добавили книгу - {bookTitle}!");   
        }
        else
        {
            Console.WriteLine("Дана книга вже наявна є в бібліотеці");
        }
    }

    public void ShowAllBooks()
    {
        if (BooksList.Count != 0)
        {
            WriteFileBooks(PathToBooksFile, BooksList);
            var booksList = BooksList.Where(b => !b.isHidden)
                .OrderBy(b => b.Title)
                .ThenBy(b => b.Year)
                .ThenBy(b => b.Author.Name)
                .ThenBy(b => b.Author.Surname)
                .ToList();
            
            foreach (var books in booksList)
            {
                Console.WriteLine($"Книга {books.Title}, рік видачі {books.Year} - автор {books.Author.Name} {books.Author.Surname}");
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
                Console.WriteLine($"Книга {books.Title}, рік видачі {books.Year} - автор {books.Author.Name} {books.Author.Surname}");
            }
            
            NotEmptyInput("\nВведіть назву книги, яку ви хочете приховати: ", out string hiddenBook);
            var bookToHide = BooksList.FirstOrDefault(b => b.Title.ToLower() == hiddenBook.ToLower().Trim());

            if (bookToHide != null)
            {
                if (!bookToHide.isHidden)
                {
                    bookToHide.isHidden = true;
                    WriteFileBooks(PathToBooksFile, BooksList);
                    
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
        var hiddenBooksList = BooksList.Where(b => b.isHidden).ToList();
        if (hiddenBooksList.Count != 0)
        {
            Console.WriteLine("Перелік прихованих книг");
            foreach (var books in hiddenBooksList)
            {
                Console.WriteLine($"Книга {books.Title}, рік видачі {books.Year} - автор {books.Author.Name} {books.Author.Surname}");
            }
            
            NotEmptyInput("\nВведіть назву книги, яку ви хочете видалити з прихованих: ", out string shownBook);
            var bookToHide = hiddenBooksList.FirstOrDefault(b => b.Title.ToLower() == shownBook.ToLower().Trim());

            if (bookToHide != null)
            {
                if (bookToHide.isHidden)
                {
                    bookToHide.isHidden = false;
                    WriteFileBooks(PathToBooksFile, BooksList);
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
        if (BooksList.Count != 0)
        {
            NotEmptyInput("Введіть назву книгу, імʼя або фамілію автора: ", out string searchPhrase).ToLower().Trim();
            var selectBooks = BooksList.Where(b => b.Title.ToLower().Contains(searchPhrase) 
                                                   || b.Year.ToString().Contains(searchPhrase) 
                                                   || b.Author.Name.ToLower().Contains(searchPhrase) 
                                                   || b.Author.Surname.ToLower().Contains(searchPhrase)).ToList();
            
            if (selectBooks.Count != 0)
            {
                Console.WriteLine("Результат:");
                foreach (var book in selectBooks)
                {
                    Console.WriteLine($"Книга {book.Title}, рік видачі {book.Year} - автор {book.Author.Name} {book.Author.Surname}");
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
}