using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoBlog.DataAccess.ViewModel
{
    public class BlogList
    {
        public int BlogID { get; set; }
        public string Subject { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedByName { get; set; }
        public string BlogText { get; set; }
        public string CreatedOnStr { get; set; }
    }

    public class CommentList
    {
        public int CommentID { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
        public DateTime? CreatedOn { get; set; }
    }

    public class UserList
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedOnStr { get; set; }
        public string UserType { get; set; }
        public int UserTypeID { get; set; }
        public bool IsMakeAdmin { get; set; }
        public bool IsDelete { get; set; }
    }
}