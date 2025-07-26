using AutoMapper;
using Repositories.EFCore;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookServices> _services;

        public ServiceManager(IRepositoryManager repositoryManager,ILoggerService logger,IMapper mapper)
        {
            _services= new Lazy<IBookServices>(()=>new BookManager(repositoryManager,logger,mapper));
        }

        public IBookServices BookServices => _services.Value;
    }
}
