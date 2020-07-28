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
                new BookModel(){Id=0001, Title="C#", Author="Microsoft",Description="This is the description for C# book", Category="Programming",Language="English", TotalPages=134},
                new BookModel(){Id=0002, Title="MVC", Author="Shashwat",Description="This is the description for MVC book",Category="Architech",Language="English", TotalPages=1200},
                new BookModel(){Id=0003, Title="ASP.NET Core", Author="Prakash",Description="This is the description for ASP.NET Core book", Category="Framework",Language="English", TotalPages=430},
                new BookModel(){Id=0004, Title="Java", Author="Nithish",Description="This is the description for Java book",Category="Programming",Language="English", TotalPages=310},
                new BookModel(){Id=0005, Title="ReactJS", Author="Kutub",Description="This is the description for ReactJs book",Category="UI Library",Language="English", TotalPages=280},
                new BookModel(){Id=0006, Title="NodeJS", Author="Harish",Description="This is the description for NodeJs book",Category="Framework",Language="English", TotalPages=683}
            };
        }
    }
}
