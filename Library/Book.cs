namespace Library;

public class Book
{
    public int Id { get; set; }
    
    private static int _uniqueId = 0;
    
    public string Title { get; set; }
    
    public int Year { get; set; }

    public Author Author { get; set; }
    
    public int AuthorId { get; set; }

    public bool isHidden { get; set; } = false;

    public Book(string title, int year, Author author)
    {
        Title = title;
        Year = year;
        Author = author;
        Id = _uniqueId;
        _uniqueId++;
    }
}