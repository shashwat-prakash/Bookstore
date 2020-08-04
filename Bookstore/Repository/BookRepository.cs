using Bookstore.Data;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddBook(BookModel book)
        {
            var newBook = new Books()
            {
                Author = book.Author,
                CreatedOn = DateTime.UtcNow,
                Description = book.Description,
                Title = book.Title,
                Language = book.Language,
                TotalPages = book.TotalPages.HasValue ? book.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks = await _context.Books.ToListAsync();
            if(allBooks?.Any() == true)
            {
                foreach (var book in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Description = book.Description,
                        Title = book.Title,
                        TotalPages = book.TotalPages,
                        Id = book.Id,
                        Category = book.Category,
                        Language = book.Language
                    });
                }
            }
            return books;
        }

        public async Task<BookModel> GetBook(int Id)
        {
            var bookDetails = await _context.Books.Where(book => book.Id == Id).FirstOrDefaultAsync();
            if(bookDetails != null)
            {
                var book = new BookModel()
                {
                    Author = bookDetails.Author,
                    Description = bookDetails.Description,
                    Title = bookDetails.Title,
                    TotalPages = bookDetails.TotalPages,
                    Id = bookDetails.Id,
                    Category = bookDetails.Category,
                    Language = bookDetails.Language
                };
                return book;
            }
            return null;
        }

        public List<BookModel> SearchBook(string Title, string Author)
        {
            //return DataSource().Where(x => x.Title.Contains(Title) || x.Author.Contains(Author)).ToList();
            return null;
        }

        /*private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=0001, Title="C#", Author="Microsoft",Description="This is the description for C# book", Category="Programming",Language="English", TotalPages=134},
                new BookModel(){Id=0002, Title="MVC", Author="Shashwat",Description="This is the description for MVC book",Category="Architech",Language="English", TotalPages=1200},
                new BookModel(){Id=0003, Title="ASP.NET Core", Author="Prakash",Description="This is the description for ASP.NET Core book", Category="Framework",Language="English", TotalPages=430},
                new BookModel(){Id=0004, Title="Java", Author="Nithish",Description="This is the description for Java book",Category="Programming",Language="English", TotalPages=310},
                new BookModel(){Id=0005, Title="ReactJS", Author="Kutub",Description="This is the description for ReactJs book",Category="UI Library",Language="English", TotalPages=280},
                new BookModel(){Id=0006, Title="NodeJS", Author="Harish",Description="This is the description for NodeJs book",Category="Framework",Language="English", TotalPages=683}
            };
        }*/
    }
}
