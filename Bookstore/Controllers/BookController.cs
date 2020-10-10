using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Bookstore.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(IBookRepository book, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = book;
            _webHostEnvironment = webHostEnvironment;
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
            if(ModelState.IsValid)
            {
                if(bookModel.CoverPhoto != null)
                {
                    string folder = "Books/cover/";
                    folder += Guid.NewGuid().ToString()+"_"+bookModel.CoverPhoto.FileName;
                    bookModel.CoverImageUrl = "/"+folder;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await bookModel.CoverPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }

                if (bookModel.BookPdf != null)
                {
                    string folder = "Books/pdf/";
                    folder += Guid.NewGuid().ToString() + "_" + bookModel.BookPdf.FileName;
                    bookModel.BookPdfUrl = "/" + folder;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await bookModel.BookPdf.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
                var id = await _bookRepository.AddBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { isSuccess = true, bookId = id });
                }
            }
            /*ViewBag.isSuccess = isSuccess;
            ViewBag.BookId = bookId;*/
            /*ModelState.AddModelError("", "Error from Book Controller");*/
            return View();
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        [Route("book-details/{id:int:min(1)}")]
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
