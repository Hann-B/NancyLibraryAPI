using NancyLibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyLibraryAPI.Persistent
{
    interface ILibraryRepository
    {
        Book Get(int id);

        IEnumerable<Book> GetAll();

        Book Add(Book book);

        void Delete(int id);

        bool Update(Book book);
    }
}
