namespace Library;

public class Author
{
    public int Id { get; set; }
    
    private static int _uniqueId = 0;
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Biography { get; set; }

    public List<Book> BooksList = [];

    public Author (string name, string surname, string biography)
    {
        Name = name;
        Surname = surname;
        Biography = biography;
        Id = _uniqueId;
        _uniqueId++;
    }
}