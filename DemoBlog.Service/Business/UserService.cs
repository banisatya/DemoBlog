using DemoBlog.DataAccess;
using DemoBlog.DataAccess.EntityModel;
using DemoBlog.DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DemoBlog.Service
{
    public class UserService : IUserService
    {
        DemoContext db = null;
        public UserService()
        {
            //string connectionString = @"data source=BLUENEPTUNE\SQLEXPRESS2014;initial catalog=BlogDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            //db = new DemoContext(connectionString);
            db = new DemoContext();
        }

        public dbActionResult CreateUser(RegisterViewModel UserModel)
        {
            dbActionResult dbResult = new dbActionResult();
            dbResult.IsSuccess = false;
            try
            {
                bool IsFirstUser = db.BlogUser.Count() == 0;
                var model = new BlogUser();
                model.UserName = UserModel.UserName;
                model.Password = UserModel.Password;
                model.UserTypeID = IsFirstUser ? 1 : 2;
                model.CreatedOn = DateTime.Now;
                db.BlogUser.Add(model);
                db.SaveChanges();
                dbResult.IsSuccess = true;
                dbResult.RecordID = model.UserID;
            }
            catch (Exception ex)
            {
            }
            return dbResult;
        }

        public UserValidationViewModel IsValidUser(LoginViewModel UserModel)
        {
            var model = new UserValidationViewModel();
            model.IsValidUser = false;
            //using (var db = new DemoContext(connectionString))
            //{
            try
            {
                var User = db.BlogUser.SingleOrDefault(x => x.UserName == UserModel.UserName && x.Password == UserModel.Password);
                if (User != null)
                {
                    model.IsValidUser = true;
                    model.UserID = User.UserID;
                    model.UserName = UserModel.UserName;
                    model.IsAdminUser = User.UserTypeID == 1;
                }
            }
            catch (Exception ex)
            {
            }
            //}
            return model;
        }

        public List<UserList> UserListSelectAll()
        {
            var lst = (from u in db.BlogUser
                       select new UserList
                       {
                           UserID = u.UserID,
                           UserName = u.UserName,
                           CreatedOn = u.CreatedOn,
                           UserTypeID = u.UserTypeID
                       }).AsEnumerable().Select(x => new UserList
                    {
                        UserID = x.UserID,
                        UserName = x.UserName,
                        CreatedOn = x.CreatedOn,
                        UserTypeID = x.UserTypeID,
                        UserType = x.UserTypeID == Utility.UserType.AdminUser ? "Admin" : "Standard",
                        CreatedOnStr = x.CreatedOn != null ? x.CreatedOn.Value.ToShortDateString() : String.Empty
                    }).ToList();
            return lst;
        }

        public dbActionResult DeleteUser(int UserID)
        {
            dbActionResult dbResult = new dbActionResult();
            dbResult.IsSuccess = false;
            try
            {
                var model = db.BlogUser.SingleOrDefault(x => x.UserID == UserID);
                if (model != null)
                {
                    db.Entry<BlogUser>(model).State = EntityState.Deleted;
                    db.SaveChanges();
                    dbResult.IsSuccess = true;
                }
            }
            catch (Exception)
            {
            }
            return dbResult;
        }

        public dbActionResult CreateAdminUser(int UserID)
        {
            dbActionResult dbResult = new dbActionResult();
            dbResult.IsSuccess = false;
            try
            {
                var model = db.BlogUser.SingleOrDefault(x => x.UserID == UserID);
                if (model != null)
                {
                    model.UserTypeID = 1;
                    db.Entry<BlogUser>(model).State = EntityState.Modified;
                    db.SaveChanges();
                    dbResult.IsSuccess = true;
                }
            }
            catch (Exception)
            {
            }
            return dbResult;
        }

        public bool IsUserNameExists(string UserName)
        {
            return db.BlogUser.Count(x => x.UserName == UserName) > 0;
        }
    }
}