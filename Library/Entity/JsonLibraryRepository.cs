using System.Text.Json;
using Library.Core.Interfaces;
using Library.Core.Models;

namespace Library.Entity;

public class JsonLibraryRepository : ILibraryRepository
{
    private const string PathToDatabase = "db/database.json";
    
    public void SaveData(Library library)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        };

        var json = JsonSerializer.Serialize(library, options);
        File.WriteAllText(PathToDatabase, json);
    }
    
    public Core.Models.Library LoadData()
    {
        if (!File.Exists(PathToDatabase))
        {
            return new Core.Models.Library();
        }

        var jsonString = File.ReadAllText(PathToDatabase);

        if (string.IsNullOrWhiteSpace(jsonString))
        {
            return new Core.Models.Library();
        }

        var libraryData = JsonSerializer.Deserialize<LibraryData>(jsonString);

        if (libraryData != null)
        {
            BooksList = libraryData.Books ?? [];
            AuthorsList = libraryData.Authors ?? [];
            
            foreach (var author in AuthorsList)
            {
                author.BooksList = BooksList.FindAll(b => b.AuthorId == author.Id);
            }
        }
    }
    //
    // private class LibraryData
    // {
    //     public List<Book>? Books { get; set; }
    //     public List<Author>? Authors { get; set; }
    // }
}