using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _Context;
        private readonly Lazy<IBookRepository> _BookRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _Context = context;
            _BookRepository = new Lazy<IBookRepository>(() => new BookRepository(_Context));
        }

        public IBookRepository Book => _BookRepository.Value;

        public async Task SaveAsync()
        {
          await  _Context.SaveChangesAsync();
        }
    }
}
