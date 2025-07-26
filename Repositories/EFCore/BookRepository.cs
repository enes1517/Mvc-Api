using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneBook(Book book) => Create(book);
       

        public void DeleteOneBook(Book book) =>Delete(book);
       

        public async Task< PageList<Book>>GetAllBooksAsync(BookParameters  bookParameters, bool TrackChanges)
        {
            var books = await FindAll(TrackChanges).
                FilterBooks(bookParameters.MaxPrice, bookParameters.MinPrice).
                Search(bookParameters.SearchTerm)
                .Sort(bookParameters.OrderBy).
                ToListAsync();

            return PageList<Book>.ToPagedList(books,
                bookParameters.PageNumber,
                bookParameters.PageSize);

        }


        public async Task<Book> GetOneBookByIdAsync(int id, bool TrackChanges) => 
            await FindByCondition(b => b.Id.Equals(id), TrackChanges).SingleOrDefaultAsync();
        
        public void UpdateOneBook(Book book) =>Update(book);
        
    }
}
