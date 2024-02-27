using Microsoft.AspNetCore.Mvc;
using MVC_Project1.Models;
using MVC_Project1.Repository;
using System.Collections.Generic;

namespace MVC_Project1.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository bookRepository = null;
        public BookController()
        {
            bookRepository = new BookRepository();
        }
                
        public ViewResult AllBooks()
        {
           var data= bookRepository.GetAllBooks();
            return View(data);
        }

        public ViewResult OneBook(int id)
        {
            var data = bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> FindBook(string title, string authorName)
        {
            return bookRepository.searchBook(title.Trim(), authorName.Trim());
        }

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
