using DemoBlog.DataAccess.EntityModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoBlog.DataAccess.ViewModel
{
    public class dbActionResult
    {
        public int RecordID { get; set; }
        public bool IsSuccess { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class CommentViewModel
    {
        public int BlogID { get; set; }

        [DisplayName("Name")]
        public string UserName { get; set; }

        [DisplayName("Comment")]
        [Required]
        public string CommentText { get; set; }

        public int UserID { get; set; }
    }

    public class BlogViewModel
    {
        public Blog Blog { get; set; }
        public bool IsAdminUser { get; set; }
        public int UserTypeID { get; set; }
    }
}