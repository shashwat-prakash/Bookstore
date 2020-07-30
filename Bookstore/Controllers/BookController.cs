using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController()
        {
            _bookRepository = new BookRepository();
        }

        public ViewResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddBook(BookModel bookModel)
        {
            return View();
        }
        public ViewResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }

        public ViewResult GetBook(int id)
        {
            var data = _bookRepository.GetBook(id);
            return View(data);
        }

        //http://localhost:5000/book/searchbook?bookname=MVC&authorname=Shashwat_Prakash
        public ViewResult SearchBook(string BookName, string AuthorName)
        {
            var data = _bookRepository.SearchBook(BookName, AuthorName);
            return View();
        }
    }
}
