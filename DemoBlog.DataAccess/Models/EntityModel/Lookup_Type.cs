using System.ComponentModel.DataAnnotations;

namespace DemoBlog.DataAccess.EntityModel
{
    public class Lookup_UserType
    {
        [Key]
        [ScaffoldColumn(false)]
        public int TypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }
    }
}
