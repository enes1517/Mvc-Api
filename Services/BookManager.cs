using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exeptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.EFCore;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Services
{
    public class BookManager : IBookServices
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }



        public async Task<BookDto> CreateOneBookAsync(BookDtoForInsertion bookDto)
        {
            var entity=_mapper.Map<Book>(bookDto);
        

            _manager.Book.CreateOneBook(entity);
            await  _manager.SaveAsync();
            return _mapper.Map<BookDto>(entity);
        }

        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
            var entity = await GetOneBookByIdAndCheckExists(id, trackChanges);
            _manager.Book.DeleteOneBook(entity);
           await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<BookDto> books, MetaData metaData)> GetAllBooksAsync(BookParameters bookParameters,bool trackChanges)
        {
            if (!bookParameters.ValidPriceRange)
                throw new PriceOutOfRangeBadRequestExeption();

            
           var booksWithMetaData= await _manager.Book.GetAllBooksAsync(bookParameters,trackChanges);
           var booksDto= _mapper.Map<IEnumerable<BookDto>>(booksWithMetaData);
           return (booksDto,booksWithMetaData.MetaData);
        }

        public async Task<BookDto> GetOneBookByIdAsync(int id, bool trackChanges)
        {
           var book= await GetOneBookByIdAndCheckExists(id,trackChanges); 
            
            return _mapper.Map<BookDto>(book);
        }

        public async Task UpdateOneBookAsync(int id, BookDtoForUpdate bookDto, bool trackChanges)
        {
            //check entity

            var entity = await GetOneBookByIdAndCheckExists(id, trackChanges);


            //entity.Tittle = book.Tittle;
            //entity.Price = book.Price;
            //  AutoMapper
            entity=_mapper.Map<Book>(bookDto);

            _manager.Book.Update(entity);
           await _manager.SaveAsync();

        }
        private async Task<Book> GetOneBookByIdAndCheckExists(int id, bool trackChanges)
        {
            var entity = await _manager.Book.GetOneBookByIdAsync(id, trackChanges);

            if (entity is null)
                throw new BookNotFoundException(id);
            
            return entity;
        }
      
    }
}
