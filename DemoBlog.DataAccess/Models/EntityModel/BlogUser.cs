using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoBlog.DataAccess.EntityModel
{
    public class BlogUser
    {
        [ScaffoldColumn(false)]
        [Key]
        public int UserID { get; set; }

        public int UserTypeID { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Created On")]
        public DateTime? CreatedOn { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }

        [DisplayName("Modified On")]
        public DateTime? ModifiedOn { get; set; }
    }
}
