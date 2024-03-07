using Microsoft.AspNetCore.Mvc;
using MVC_Project1.Models;
using MVC_Project1.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC_Project1.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository; //inject repository data in a private readonly field
        }
        
        
        public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)// this bookModel take data from view and pass to reposetory method
        {
            int id = await _bookRepository.AddNewBook(bookModel);
            if (id > 0)
            {
                return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
            }
            return View();
        }

        public async Task<ViewResult>AllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }


        public async Task<ViewResult> OneBook(int id)
        {
            var data = await _bookRepository.GetBookByID(id);
            return View(data);
        }


        //public ViewResult AllBooks()
        //{
        //   var data= _bookRepository.GetAllBooks(); // inherit repository Method
        //    return View(data);
        //}

        //public ViewResult OneBook(int id)
        //{
        //    var data = _bookRepository.GetBookById(id);
        //    return View(data);
        //}

        public List<BookModel> FindBook(string title, string authorName)
        {
             var data=_bookRepository.searchBook(title.Trim(), authorName.Trim());
            return (data);
        }
       
       
       
        
        
        //
        //public string GetAllBooks()
        //{
        //    return "All books";
        //}
        //public string GetBook(int id)
        //{
        //    return $"book with id ={id}";
        //}

        //public string SearchBooks(string bookName,string authorName)
        //{
        //    return $"book with Name ={bookName}&Author={authorName}";
        //}
    }
}
