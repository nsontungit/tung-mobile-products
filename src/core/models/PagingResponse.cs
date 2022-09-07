using System;
using System.Collections.Generic;
using System.Text;

namespace core.models
{
    public class PagingResponse<T> where T : class
    {
        public T[] Data { get; set; }
        public int TotalRows { get; set; }
        public int TotalPages { get; set; }
    }
}
