﻿
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public abstract record BookDtoForManipulation
    {
        [Required(ErrorMessage ="Title is required field ")]
        [MinLength(2,ErrorMessage ="Title must consist of at least 2 characters")]
        [MaxLength(50,ErrorMessage ="Title must consist of at maximum 2 characters")]
        public string Tittle { get; init; }

        [Required(ErrorMessage = "Price is required field ")]
        [Range(10,1000)]
        public decimal Price { get; init; }
    }
   
}
