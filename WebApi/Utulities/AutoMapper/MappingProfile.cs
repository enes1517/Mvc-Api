using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WebApi.Utulities.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate, Book>();
            CreateMap<Book, BookDto>();
            CreateMap<BookDtoForInsertion, Book>();
        }
    }
}
