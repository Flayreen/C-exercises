using System.Text.Json.Serialization;

namespace Library;

public class Author
{
    private static int _uniqueId = 0;
    
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Biography { get; set; }

    public List<Book> BooksList { get; set; } = new List<Book>();

    [JsonConstructor]
    public Author (string name, string surname, string biography)
    {
        Name = name;
        Surname = surname;
        Biography = biography;
        Id = _uniqueId++;
    }
}