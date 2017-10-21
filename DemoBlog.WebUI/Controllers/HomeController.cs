using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoBlog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //this will display the list of all blogs
        public ActionResult Index()
        {
            var blogProxy = new wcfBlogService.BlogServiceClient();
            var lst=blogProxy.GetAllBlogs(null);
            return View(lst);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}