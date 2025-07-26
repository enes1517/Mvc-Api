using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; }
        private int _PageSize;

        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value > maxPageSize ? maxPageSize:value ; }
        }
        public String? OrderBy { get; set; }
    }
}
