using Library.Core.Models;

namespace Library.Core.Interfaces;

public interface ILibraryRepository
{
    void SaveData(Library library);
    Models.Library LoadData();
}