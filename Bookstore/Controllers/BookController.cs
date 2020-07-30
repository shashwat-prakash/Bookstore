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
        public BookController(BookRepository book)
        {
            _bookRepository = book;
        }

        public ViewResult AddBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookModel)
        {
            var id = await _bookRepository.AddBook(bookModel);
            if(id > 0)
            {
                return RedirectToAction(nameof(AddBook), new {isSuccess = true, bookId =id });
            }
            return View();
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBook(id);
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
