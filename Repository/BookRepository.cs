using MVC_Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project1.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return Datasource();
        }
        public BookModel GetBookById(int id)
        {
           // return (BookModel)Datasource().Where(x=>x.id==id);
            return Datasource().Where(x => x.id == id).FirstOrDefault();
        }
        public List<BookModel> searchBook(string title, string authorName)
        {
            //return Datasource().Where(x=>x.Title==title && x.Author==authorName).ToList();
           // return Datasource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorName)).ToList();
            return Datasource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();

        }
        private List<BookModel> Datasource()
        {
            return new List<BookModel>()
            {
                new BookModel(){id=1, Title="MVC", Author="Tom", Description="Best Book for MVC", Category="Programing", Language="English", TotalPages=345},
                new BookModel(){id=2, Title="C#", Author="Dic",Description="Best Book for C#",Category="Programing", Language="English", TotalPages=400},
                new BookModel(){id=3, Title="VB", Author="Herry", Description="Best Book for VB",Category="Programing", Language="English", TotalPages=234},
                new BookModel(){id=4, Title="Java", Author="tom", Description="Best Book for Java",Category="Programing", Language="English", TotalPages=145},
                new BookModel(){id=5, Title="c++", Author="dic", Description="Best Book for C++",Category="Programing", Language="English", TotalPages=405},
                 new BookModel(){id=4, Title="Java", Author="web", Description="Best Book for Java",Category="Programing", Language="English", TotalPages=543},
                new BookModel(){id=5, Title="c++", Author="Me", Description="Best Book for C++",Category="Programing", Language="English", TotalPages=345},
            };
        }
    }
}
