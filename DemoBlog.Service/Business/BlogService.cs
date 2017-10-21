using DemoBlog.DataAccess;
using DemoBlog.DataAccess.EntityModel;
using DemoBlog.DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DemoBlog.Service
{
    public class BlogService : IBlogService
    {
        DemoContext db;
        public BlogService()
        {
            string connectionString = @"data source=BLUENEPTUNE\SQLEXPRESS2014;initial catalog=BlogDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            //db = new DemoContext(connectionString);
            db = new DemoContext();
        }

        #region Blog
        
        public dbActionResult CreateBlog(Blog model)
        {
            dbActionResult dbResult = new dbActionResult();
            dbResult.IsSuccess = false;
            try
            {
                //using (DemoContext db = new DemoContext(connectionString))
                //{
                model.CreatedOn = DateTime.Now;
                db.Blog.Add(model);
                db.SaveChanges();
                dbResult.IsSuccess = true;
                //}
            }
            catch (Exception ex)
            {
            }
            return dbResult;
        }

        public bool IsValidSubject(string Subject)
        {
            bool IsValid = false;
            //using (DemoContext db = new DemoContext(connectionString))
            //{
            IsValid = db.Blog.Count(x => x.Subject == Subject) == 0;
            //}
            return IsValid;
        }

        public List<BlogList> GetAllBlogs(int? UserID)
        {
            var lst = (from b in db.Blog
                       join u in db.BlogUser on b.UserID equals u.UserID into cu
                       from u in cu.DefaultIfEmpty()
                       where UserID == null ? true : b.UserID == UserID
                       orderby b.CreatedOn descending
                       select new BlogList
                       {
                           BlogID = b.BlogID,
                           Subject = b.Subject,
                           CreatedByName = u.UserName,
                           CreatedOn = b.CreatedOn,
                           BlogText = b.BlogText,
                       }).AsEnumerable().Select(m => new BlogList
                           {
                               BlogID = m.BlogID,
                               Subject = m.Subject,
                               CreatedByName = m.CreatedByName,
                               CreatedOn = m.CreatedOn,
                               BlogText = m.BlogText.Substring(0, 400),
                               CreatedOnStr=m.CreatedOn.Value.ToString("MMMM dd, yyyy")
                           }).ToList();
            return lst;
        }

        public BlogViewModel GetBlog(int BlogID)
        {
            var model = (from b in db.Blog
                       join u in db.BlogUser on b.UserID equals u.UserID into cu
                       from u in cu.DefaultIfEmpty()
                         where b.BlogID == BlogID
                       select new BlogViewModel
                       {
                           Blog = b,
                           UserTypeID = u.UserTypeID
                       }).AsEnumerable().Select(x => new BlogViewModel
                    {
                        Blog = x.Blog,
                        IsAdminUser = x.UserTypeID == (int)Utility.UserType.AdminUser
                    }).FirstOrDefault();
            return model;
        }

        public dbActionResult DeleteBlog(int BlogID)
        {
            dbActionResult dbResult = new dbActionResult();
            dbResult.IsSuccess = false;
            try
            {
                var model = db.Blog.SingleOrDefault(x => x.BlogID == BlogID);
                db.Entry<Blog>(model).State = EntityState.Deleted;
                db.SaveChanges();
                dbResult.IsSuccess = true;
            }
            catch (Exception)
            {
            }
            return dbResult;
        }

        #endregion

        #region Comment

        public List<CommentList> CommentListAll(int BlogID)
        {
            var lst = (from c in db.Comment
                       where c.BlogID == BlogID
                       select new CommentList
                       {
                           CommentID = c.CommentID,
                           Comment = c.CommentText,
                           CreatedOn = c.CreatedOn,
                           UserName = c.UserName
                       }).ToList();
            return lst;
        }

        public dbActionResult CommentCreate(CommentViewModel model)
        {
            dbActionResult dbResult = new dbActionResult();
            dbResult.IsSuccess = false;
            try
            {
                var CommentModel = new Comment();
                CommentModel.BlogID = model.BlogID;
                CommentModel.CommentText = model.CommentText;
                if (String.IsNullOrWhiteSpace(model.UserName))
                {
                    CommentModel.UserName = db.BlogUser.SingleOrDefault(x => x.UserID == model.UserID).UserName;
                }
                else
                    CommentModel.UserName = model.UserName;
                CommentModel.CreatedOn = DateTime.Now;
                db.Comment.Add(CommentModel);
                db.SaveChanges();
                dbResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
            }
            return dbResult;
        }

        #endregion
    }
}