using System.Text.Json;
using LibraryProject.Core.Interfaces;
using LibraryProject.Core.Models;

namespace LibraryProject.Entity;

public class LibraryRepository : ILibraryRepository
{
    private const string PathToDatabase = "db/database.json";
    
    public void SaveData()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        };

        var libraryData = new LibraryData
        {
            Books = Library.BooksList,
            Authors = Library.AuthorsList
        };

        File.WriteAllText(PathToDatabase, JsonSerializer.Serialize(libraryData, options));
    }

    public void LoadData()
    {
        if (!File.Exists(PathToDatabase))
        {
            return;
        }

        var jsonString = File.ReadAllText(PathToDatabase);

        if (string.IsNullOrWhiteSpace(jsonString))
        {
            return;
        }

        var libraryData = JsonSerializer.Deserialize<LibraryData>(jsonString);

        if (libraryData != null)
        {
            Library.BooksList = libraryData.Books ?? [];
            Library.AuthorsList = libraryData.Authors ?? [];

            foreach (var author in Library.AuthorsList)
            {
                author.BooksList = Library.BooksList.FindAll(b => b.AuthorId == author.Id);
            }
        }
    }
}