using System.Text.Json.Serialization;

namespace Library.Core.Models;

public class Book
{
    private static int _uniqueId = 0;
    
    public int Id { get; set; }
    
    public int AuthorId { get; set; }
    
    public string Title { get; set; }
    
    public int Year { get; set; }

    public bool IsHidden { get; set; } = false;

    public Book() { }
    
    [JsonConstructor]
    public Book(string title, int year, int authorId)
    {
        Title = title;
        Year = year;
        AuthorId = authorId;
        Id = _uniqueId++;
    }
}