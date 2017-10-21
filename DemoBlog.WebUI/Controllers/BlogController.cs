using DemoBlog.DataAccess.EntityModel;
using DemoBlog.DataAccess.ViewModel;
using System;
using System.Web.Mvc;

namespace DemoBlog.WebUI.Controllers
{
    public class BlogController : Controller
    {
        wcfBlogService.BlogServiceClient blogProxy;
        public BlogController()
        {
            blogProxy = new wcfBlogService.BlogServiceClient();
        }

        #region Blog

        [AllowAnonymous]
        public ActionResult View(int id)
        {
            var model = blogProxy.GetBlog(id);
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog model)
        {
            if(ModelState.IsValid)
            {
                bool IsSubjectValid = blogProxy.IsValidSubject(model.Subject);

                if (IsSubjectValid)
                {
                    model.UserID = Int32.Parse(Session["UserID"].ToString());
                    var dbResult = blogProxy.CreateBlog(model);
                    if (dbResult.IsSuccess)
                        return RedirectToAction("Index", "Home");
                    else
                        return View(model);
                }
                else
                    ModelState.AddModelError("Subject", "*The blog subject already exist. Please try with another subject");
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult DeleteBlog(int BlogID)
        {
            dbActionResult dbResult = blogProxy.DeleteBlog(BlogID);
            if (dbResult.IsSuccess)
                return RedirectToAction("Index", "Home");
            else
            {
                ModelState.AddModelError("", "Not able to delete blog");
                return RedirectToAction("View", "Blog", new { id = BlogID });
            }
        }

        #endregion

        #region Comment

        [AllowAnonymous]
        public ActionResult CommentList(int BlogID)
        {
            var lst = blogProxy.CommentListAll(BlogID);
            return PartialView(lst);
        } 
  
        [AllowAnonymous]
        public ActionResult CommentCreate(int BlogID)
        {
            var model = new CommentViewModel();
            model.BlogID = BlogID;
            TempData["ReturnURL"] = Request.Url.AbsoluteUri;
            if(Session["UserID"]!=null){
                model.UserID = Int32.Parse(Session["UserID"].ToString());
            }
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult CommentCreate(CommentViewModel inputModel)
        {
            if (inputModel.UserID == 0 && String.IsNullOrWhiteSpace(inputModel.UserName))
                ModelState.AddModelError("UserName", "*User Name is required");
            if (ModelState.IsValid)
            {
                var dbResult = blogProxy.CommentCreate(inputModel);

                if (dbResult.IsSuccess)
                {
                    if (dbResult.IsSuccess)
                        return RedirectToAction("View", new { id = inputModel.BlogID });
                    else
                        return View(inputModel);
                }
                else
                    return View(inputModel);
            }
            return View(inputModel);
        }

        #endregion

    }
}