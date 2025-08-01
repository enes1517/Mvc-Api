﻿using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public interface IRepositoryManager
    {
        IBookRepository Book { get; }
        Task SaveAsync();
    }
}
