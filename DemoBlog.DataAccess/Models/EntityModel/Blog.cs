using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoBlog.DataAccess.EntityModel
{
    public class Blog
    {
        [ScaffoldColumn(false)]
        [Key]
        public int BlogID { get; set; }

        [DisplayName("User")]
        public int UserID { get; set; }

        [DisplayName("Subject")]
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be maximum 50 characters long.")]
        public string Subject { get; set; }

        [DisplayName("Blog")]
        [Required]
        [MinLength(500)]
        public string BlogText { get; set; }

        [DisplayName("Created On")]
        public DateTime? CreatedOn { get; set; }
    }
}
