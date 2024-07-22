namespace Library;

public class Book
{
    public int Id { get; set; }

    public int authorId;
    
    private static int _uniqueId = 0;
    
    public string Title { get; set; }
    
    public int Year { get; set; }

    public bool IsHidden { get; set; } = false;

    public Book(string title, int year, int authorId)
    {
        Title = title;
        Year = year;
        this.authorId = authorId;
        Id = _uniqueId;
        _uniqueId++;
    }
}