namespace LibraryProject.Core.Interfaces;

public interface ILibraryService
{
    void AddBook();

    void ShowAllBooks();

    void HideBook();

    void DeleteFromHiddenBook();

    void FindTheBook();

    void ShowAllAuthors();

    void AddAuthor();
}