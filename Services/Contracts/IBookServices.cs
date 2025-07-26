﻿using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBookServices
    {
         Task<(IEnumerable<BookDto>books,MetaData metaData)> GetAllBooksAsync(BookParameters bookParameters,bool trackChanges);
         Task<BookDto> CreateOneBookAsync(BookDtoForInsertion book);
         Task<BookDto> GetOneBookByIdAsync(int id,bool trackChanges);
       
         Task UpdateOneBookAsync(int id,BookDtoForUpdate bookDto,bool trackChanges);
         Task DeleteOneBookAsync(int id, bool trackChanges);
    }
}
