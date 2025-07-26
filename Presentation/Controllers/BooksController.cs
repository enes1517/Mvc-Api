using Entities.DataTransferObjects;
using Entities.Exeptions;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync([FromQuery]BookParameters bookParameters)
        {           
                var pagedResult = await _manager.BookServices.GetAllBooksAsync(bookParameters,false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.books);

        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBookAsync([FromRoute(Name = "id")] int id)
        {
           
                var books =await _manager.BookServices.GetOneBookByIdAsync(id, false);
               
                return Ok(books);
            

        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneBookAsync([FromBody] BookDtoForInsertion bookDto)
        {
            var book = await _manager.BookServices.CreateOneBookAsync(bookDto);
            return StatusCode(201, book);   //CreatedAtRoute()
        }


        [ServiceFilter(typeof (ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBookAsync([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
        {
            await _manager.BookServices.UpdateOneBookAsync(id, bookDto, true);
            return NoContent();//204
        }




        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneBookAsync([FromRoute(Name = "id")] int id)
        {
        
               await _manager.BookServices.DeleteOneBookAsync(id, false);
                return NoContent(); 
        }


    }
}
