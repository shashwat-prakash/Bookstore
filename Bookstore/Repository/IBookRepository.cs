using Bookstore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Repository
{
    public interface IBookRepository
    {
        Task<int> AddBook(BookModel book);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBook(int Id);
        Task<List<BookModel>> GetTopBooksAsync(int count);
        List<BookModel> SearchBook(string Title, string Author);
    }
}