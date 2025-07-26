using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBookRepository:IRepositoryBase<Book>
    {
       Task<PageList<Book>> GetAllBooksAsync(BookParameters bookParameters,bool TrackChanges);
       Task<Book> GetOneBookByIdAsync(int id,bool TrackChanges);
    
        void CreateOneBook(Book book);
        void UpdateOneBook(Book book);
        void DeleteOneBook(Book book);
    
    }
}
