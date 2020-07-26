using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBook(int Id)
        {
            return DataSource().Where(a => a.Id == Id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string Title, string Author)
        {
            return DataSource().Where(x => x.Title.Contains(Title) || x.Author.Contains(Author)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=0001, Title="C#", Author="Microsoft"},
                new BookModel(){Id=0002, Title="MVC", Author="Shashwat"},
                new BookModel(){Id=0003, Title="ASP.NET Core", Author="Prakash"},
                new BookModel(){Id=0004, Title="Java", Author="Nithish"},
                new BookModel(){Id=0005, Title="ReactJS", Author="Kutub"},
                new BookModel(){Id=0006, Title="NodeJS", Author="Harish"}
            };
        }
    }
}
