using Ganhua.DesignPattern.AppService.Requests;
using Ganhua.DesignPattern.AppService.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ganhua.DesignPattern.AppService.Controllers
{
    public class ProductController : Controller
    {
        public JsonResult Index(int id)
        {
            return Json(new ProductListResponse());
        }
        // GET: Product
        public JsonResult GetAllProductsFor(int jsonRequest)
        {
            
            return Json(new ProductListResponse());
        }
    }
}