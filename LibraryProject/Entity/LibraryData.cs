using LibraryProject.Core.Models;

namespace LibraryProject.Entity;

public class LibraryData
{
    public List<Book>? Books { get; set; }
    public List<Author>? Authors { get; set; }
}