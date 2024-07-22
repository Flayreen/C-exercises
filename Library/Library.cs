namespace Library;
public class Library : Helpers
{
    private const string PathToBooksFile = "db/books.txt";
    
    private const string PathToAuthorsFile = "db/authors.txt";
    
    private List<Book> BooksList { get; set; } = ReadFileBooks(PathToBooksFile) ?? [];
    
    private List<Author> AuthorsList { get; set; } = ReadFileAuthors(PathToAuthorsFile) ?? [];
    
    public void AddBook()
    {
        NotEmptyInput("Введіть назву книги: ", out string bookTitle);
        NotEmptyInput("Введіть рік видачі книги ", out int bookYear);
        
        // Перевірка, чи є ця книга в нашій бібліотеці
        var findBook = BooksList.FirstOrDefault(b =>
            b.Title.ToLower() == bookTitle.ToLower().Trim() 
            && b.Year == bookYear 
        );
        
        if (findBook == null)
        {
            NotEmptyInput("Введіть імʼя автора ", out string authorName);
            NotEmptyInput("Введіть прізвище автора ", out string authorSurname);
            
            var findAuthor = AuthorsList.FirstOrDefault(a => a.Name == authorName && a.Surname == authorSurname);
            
            // Перевірка, чи є нас такий автор в списку бібліотеки
            if (findAuthor == null)
            {
                NotEmptyInput("Введіть коротку біографія автора ", out string authorBiography);
                Author author = new Author(authorName, authorSurname, authorBiography);
                Book book = new Book(bookTitle, bookYear, author.Id);
                author.BooksList.Add(book);
                BooksList.Add(book);
                AuthorsList.Add(author);
            }
            else
            {
                Book book = new Book(bookTitle, bookYear, findAuthor.Id);
                findAuthor.BooksList.Add(book);
                BooksList.Add(book);
            }
            WriteFileAuthors(PathToAuthorsFile, AuthorsList);
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
        if (BooksList.Any(b => !b.IsHidden))
        {
            var booksList = BooksList.Where(b => !b.IsHidden)
                .OrderBy(b => b.Title)
                .ThenBy(b => b.Year)
                .ThenBy(b => AuthorsList.FirstOrDefault(a => a.Id == b.authorId)!.Name)
                .ThenBy(b => AuthorsList.FirstOrDefault(a => a.Id == b.authorId)!.Surname)
                .ToList();
            
            foreach (var books in booksList)
            {
                Console.WriteLine($"Книга \"{books.Title}\", рік видачі {books.Year} - автор {AuthorsList.FirstOrDefault(a => a.Id == books.authorId)!.Name} {AuthorsList.FirstOrDefault(a => a.Id == books.authorId)!.Surname}");
            }   
        }
        else
        {
            Console.WriteLine("Бібліотека пуста...");
        }
    }

    public void HideBook()
    {
        if (BooksList.Any(b => !b.IsHidden))
        {
            foreach (var books in BooksList.Where(b => !b.IsHidden))
            {
                Console.WriteLine($"Книга {books.Title}, рік видачі {books.Year} - автор {AuthorsList.FirstOrDefault(a => a.Id == books.authorId)!.Name} {AuthorsList.FirstOrDefault(a => a.Id == books.authorId)!.Surname}");
            }
            
            NotEmptyInput("\nВведіть назву книги, яку ви хочете приховати: ", out string hiddenBook);
            var bookToHide = BooksList.FirstOrDefault(b => b.Title.ToLower() == hiddenBook.ToLower().Trim());

            if (bookToHide != null)
            {
                if (!bookToHide.IsHidden)
                {
                    bookToHide.IsHidden = true;
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
        var hiddenBooksList = BooksList.Where(b => b.IsHidden).ToList();
        if (hiddenBooksList.Count != 0)
        {
            Console.WriteLine("Перелік прихованих книг");
            foreach (var books in hiddenBooksList)
            {
                Console.WriteLine($"Книга {books.Title}, рік видачі {books.Year} - автор {AuthorsList.FirstOrDefault(a => a.Id == books.authorId)!.Name} {AuthorsList.FirstOrDefault(a => a.Id == books.authorId)!.Surname}");
            }
            
            NotEmptyInput("\nВведіть назву книги, яку ви хочете видалити з прихованих: ", out string shownBook);
            var bookToHide = hiddenBooksList.FirstOrDefault(b => b.Title.ToLower() == shownBook.ToLower().Trim());

            if (bookToHide != null)
            {
                if (bookToHide.IsHidden)
                {
                    bookToHide.IsHidden = false;
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
        if (BooksList.Any(b => !b.IsHidden))
        {
            NotEmptyInput("Введіть назву книгу, рік видачі, імʼя або фамілію автора: ", out string searchPhrase);
            var selectBooks = BooksList.Where(b => 
                b.Title.ToLower().Contains(searchPhrase.ToLower().Trim()) || 
                b.Year.ToString().Contains(searchPhrase.ToLower().Trim())).ToList();
            
            if (selectBooks.Count != 0)
            {
                Console.WriteLine("Результат:");
                foreach (var book in selectBooks)
                {
                    Console.WriteLine($"Книга {book.Title}, рік видачі {book.Year} - автор {AuthorsList.FirstOrDefault(a => a.Id == book.authorId)!.Name} {AuthorsList.FirstOrDefault(a => a.Id == book.authorId)!.Surname}");
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
        if (AuthorsList.Count > 0)
        {
            var authorList = AuthorsList.OrderBy(a => a.Name).ThenBy(a => a.Surname).ToList();
            
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
}