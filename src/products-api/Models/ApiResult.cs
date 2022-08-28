using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace products_api.Models
{
    public class ApiResult
    {
        public object Data { get; set; }
        public string Message { get; set; }
    }
    public static class ApiResultCreator
    {
        public static ApiResult Create(object data, string message = null)
        {
            return new ApiResult
            {
                Data = data,
                Message = message
            };
        }
    }
}
