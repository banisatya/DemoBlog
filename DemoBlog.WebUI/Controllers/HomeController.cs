using System.Web.Mvc;

namespace DemoBlog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var blogProxy = new wcfBlogService.BlogServiceClient();
            var lst=blogProxy.GetAllBlogs(null);
            return View(lst);
        }
    }
}