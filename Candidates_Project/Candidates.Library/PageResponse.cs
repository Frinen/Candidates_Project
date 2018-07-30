using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Library
{
    public class PageResponse<T>
    {
        public IEnumerable<T> List { get; set; }
        public int PageCount { get; set; }
        public int ItemCount { get; set; }
        //public string Message { get; set; }
    }
}
