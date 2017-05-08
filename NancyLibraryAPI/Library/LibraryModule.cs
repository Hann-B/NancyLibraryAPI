using Nancy;
using Nancy.ModelBinding;
using NancyLibraryAPI.Models;
using NancyLibraryAPI.Persistent;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace NancyLibraryAPI
{
    public class LibraryModule : NancyModule
    {
        /*To Begin
          Create new Empty Web Application
          Install-Package
              Nancy
              Nancy.Hosting.Aspnet
              Nancy.Viewengines.Razor
              Nancy.Bootstrapper.StructurMap
           */

        //List of Books 
        public static List<Book> ListOfBooks()
        {
            var Books = new List<Book>()
            {
                new Book
                {
                    Id = new Guid(),
                    Title = "Sanibel Flats",
                    Author = "Randy Wayne White",
                    YearPublished = 1990,
                    Genre = "Mystery",
                    IsCheckedOut = false,
                },
                new Book
                {
                    Id = new Guid(),
                    Title = "Gone",
                    Author = "Randy Wayne White",
                    YearPublished = 2012,
                    Genre = "Mystery",
                    IsCheckedOut = false,
                },
                new Book
                {
                    Id = new Guid(),
                    Title = "Deep",
                    Author = "James Nestor",
                    YearPublished = 2014,
                    Genre = "Science",
                    IsCheckedOut = true,
                }
            };
            return Books;
        }

        //Nancy Modules = MVC Controller
        public LibraryModule()
        {
            //Get All Books in Library
            Get["/"] = x =>
            {
                return View["Index", ListOfBooks()];
            };

            //Create a Book
            Get["/new/"] = _ =>
                    {
                        var book = new Book();
                        return View["New", book];
                    };
            Post["/new/"] = x =>
                    {
                        var book = this.Bind<Book>();
                        if (book != null)
                        {
                            ListOfBooks().Add(book);
                            return Response
                            .AsRedirect("/");
                        }
                        return 500;
                    };

            //Update a Book
            Get["/edit/{id:guid}"] = _ =>
            {
                var id = new Guid(_.id);
                var book = ListOfBooks()
                .Where(x => x.Id == _.id).FirstOrDefault();
                if (book != null)
                {
                    return View["Edit", new Book()
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Author = book.Author,
                        YearPublished = book.YearPublished
                    }];
                }
                return 404;
            };
            Post["/edit"] = parameters =>
              {
                  Book book = this.Bind<Book>();
                  if (book != null)
                  {
                      ListOfBooks();
                      return Response.AsRedirect("/");
                  }
                  return 404;
              };

            //Delete a Book
            Get["/delete/{id:guid}"] = _ =>
            {
                var id = new Guid(_.id);
                if (ListOfBooks().Any(a => a.Id == id))
                {
                    ViewBag.BookId = id;
                    return View["delete"];
                }
                return 404;
            };
            Post["/deleteConfirmed"] = x =>
            {
                Book books = this.Bind<Book>();
                if (books != null)
                {
                    var book = ListOfBooks()
                    .Where(w => w.Id == books.Id)
                    .FirstOrDefault();
                    ListOfBooks().Remove(book);
                    return Response.AsRedirect("/");
                }
                return 404;
            };
        }

    }
}