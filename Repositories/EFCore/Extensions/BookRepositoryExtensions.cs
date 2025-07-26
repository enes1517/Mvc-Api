using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
namespace Repositories.EFCore.Extensions
{
    public static class BookRepositoryExtensions
    {
        public static IQueryable<Book> FilterBooks(this IQueryable<Book> books,
            uint maxPrice, uint minPrice) =>

        books.Where(book => book.Price >= minPrice && book.Price <= maxPrice);
       

        public static IQueryable<Book> Search(this IQueryable<Book> books,string SearchTerm)
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
                return books;
            var lowerCaseTerm=SearchTerm.Trim().ToLower();
            return books.Where(b => b.Tittle.ToLower().Contains(lowerCaseTerm));
        }
        public static IQueryable<Book> Sort(this IQueryable<Book> books, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                 return books.OrderBy(b=>b.Id);

           var orderQuery=OrderQueryBuilder.CreateOrderQuery<Book>(orderByQueryString);

            if (orderQuery is null)
                return books.OrderBy(b=>b.Id);

            return books.OrderBy(orderQuery);                   
        }

    }
   
}
