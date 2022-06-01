using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimicAPI.Helpers
{
    public class Paginator
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int ItemsTotal { get; set; }
        public int PagesTotal { get; set; }
        public Paginator(int pNumber, int pSize, int iTotal, int pTotal) 
        {
            PageNumber = pNumber;
            PageSize = pSize;
            ItemsTotal = iTotal;
            PagesTotal = pTotal;
        }
    }
}
