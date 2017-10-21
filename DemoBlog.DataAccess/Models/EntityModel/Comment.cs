using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoBlog.DataAccess.EntityModel
{
    public class Comment
    {
        [ScaffoldColumn(false)]
        [Key]
        public int CommentID { get; set; }

        [DisplayName("Blog")]
        public int BlogID { get; set; }

        [DisplayName("User Name")]
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [DisplayName("Comment")]
        [Required]
        public string CommentText { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
