
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public record BookDto()
    {
        public int Id { get; init; }
        public string Tittle { get; init; }
        public decimal Price { get; init; }
    }
   
}
