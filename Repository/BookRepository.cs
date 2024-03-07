using Microsoft.EntityFrameworkCore;
using MVC_Project1.Data;
using MVC_Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project1.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _bookStoreContext = null;
        public BookRepository(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }

        public async Task<int> AddNewBook(BookModel model)      // there is no need to assine task but because of id i wnat to return in the form of int
        {
            book bk = new book();                               // book class Born child bk that is look like BookModel & get the data
            
            bk.Author = model.Author;
            bk.CreatedOn = DateTime.UtcNow;
            bk.Description = model.Description;
            bk.Title = model.Title;
            bk.TotalPages = model.TotalPages;
            bk.UpdatedOn = DateTime.UtcNow;  
            
           await _bookStoreContext.MyBook.AddAsync(bk); // child give data to another chiled Mybook
           await _bookStoreContext.SaveChangesAsync();
           
            return bk.id;
        }

        public async Task<List<BookModel>>GetAllBooks()                      // Assining Task to the BookModel that get the data in the form of List
        {
            List<BookModel> obj = new List<BookModel>();                    //The book model combined with the list to create a child that looks exactly like it.  

            var allbooks = await _bookStoreContext.MyBook.ToListAsync();    // Entity Assining data to the variable
            if(allbooks?.Any()==true)                                       //value exist or not in allbooks variable
            {
                foreach(var x in allbooks) // value get into x but 
                {
                    BookModel bookModel = new BookModel();                    // This time the Book Model gave birth to a second child who is look like a entity.
                    
                    bookModel.Author = x.Author;                                  // This child take all data fromm entity 
                    bookModel.Category = x.Category;
                    bookModel.Description = x.Description;
                    bookModel.id = x.id;
                    bookModel.Language = x.Language;
                    bookModel.Title = x.Title;
                    bookModel.TotalPages = (int)x.TotalPages;
                    
                    obj.Add(bookModel);                                     //finaly Entity se data nikal kr BookModel ke ek bete ne liya or dusre ko diya 
                }
            }
            return obj;                                                    //dusra beta return aa gya Task List<BookModle> ke pass
        }

        public async Task<BookModel> GetBookByID(int id)
        {
           var x = await _bookStoreContext.MyBook.FindAsync(id);        // there is no need of for loop becaue we need single row only by id
            if (x != null) 
            {
                BookModel bookModel = new BookModel();                    // This time the Book Model gave birth to a only one child who is look like a entity.

                bookModel.Author = x.Author;                                  // This child take all data fromm entity 
                bookModel.Category = x.Category;
                bookModel.Description = x.Description;
                bookModel.id = x.id;
                bookModel.Language = x.Language;
                bookModel.Title = x.Title;
                bookModel.TotalPages = (int)x.TotalPages;

                return bookModel;
            }
            return null;
        }


        //public List<BookModel> GetAllBooks()
        //{
        //    return Datasource();
        //}
        //public BookModel GetBookById(int id)
        //{
        //   // return (BookModel)Datasource().Where(x=>x.id==id);
        //    return Datasource().Where(x => x.id == id).FirstOrDefault();
        //}
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
                new BookModel(){id=1, Title="MVC", Author="Tom", Description="Best Book for MVC", Category="Programing", Language="English", TotalPages=345, Rating="***", Opinion="It's Good"},
                new BookModel(){id=2, Title="C#", Author="Dic",Description="Best Book for C#",Category="Programing", Language="English", TotalPages=400,Rating="****", Opinion="It's Better"},
                new BookModel(){id=3, Title="VB", Author="Herry", Description="Best Book for VB",Category="Programing", Language="English", TotalPages=234,Rating="****", Opinion="It's Fine"},
                new BookModel(){id=4, Title="Java", Author="tom", Description="Best Book for Java",Category="Programing", Language="English", TotalPages=145,Rating="****", Opinion="It's Osm"},
                new BookModel(){id=5, Title="c++", Author="dic", Description="Best Book for C++",Category="Programing", Language="English", TotalPages=405,Rating="***", Opinion="It's marvelous"},
                 new BookModel(){id=4, Title="Java", Author="web", Description="Best Book for Java",Category="Programing", Language="English", TotalPages=543,Rating="*****", Opinion="It's Too Good"},
                new BookModel(){id=5, Title="c++", Author="Me", Description="Best Book for C++",Category="Programing", Language="English", TotalPages=345, Rating="***", Opinion="It's WoW"},
            };
        }
    }
}
