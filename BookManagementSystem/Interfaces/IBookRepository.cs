using BookManagementSystem.Models;

namespace BookManagementSystem.Interfaces
{
    public interface IBookRepository
    {
        void Save(Book book);
    }
}
