using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrrLab02.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public string Index()
        {
            return "product/index is displayed";
        }
        public string Browse()
        {
            return "Browse Displayed";
        }
        public string Details()
        {
           return  "Details displayed for Id=105";
        }
        public string Location()
        {
            return "Location displayed for zip=44124";
        }
       
    
    
    
    }
}