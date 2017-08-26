using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ganhua.DesignPattern.AppService.Responses
{
    public class ProductListResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IList<ProductViewModel> Products { get; set; }
    }
}