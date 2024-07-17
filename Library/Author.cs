namespace Library;

public class Author (string name, string surname)
{
    public string Name { get; set; } = name;
    public string Surname { get; set; } = surname;

    public List<Book> BooksList = [];
}