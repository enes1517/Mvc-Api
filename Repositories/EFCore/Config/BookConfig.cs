using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(new Book { Id = 1, Tittle = "Hacivat ve Karagöz", Price = 75 },
            new Book { Id = 2, Tittle = "Mesnevi", Price = 175 },
            new Book { Id = 3, Tittle = "Nutuk", Price = 375 }



            );
        }
    }
}
