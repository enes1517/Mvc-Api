using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exeptions
{
    public abstract class BadRequestExeption:Exception
    {
        protected BadRequestExeption(string Message):base(Message)
        {
            
        }
    }
}
