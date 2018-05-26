using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreApp.WebApi.Models
{
    public class ResponseResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public string Status { get; set; }
        public string Code { get; set; }
    }
}