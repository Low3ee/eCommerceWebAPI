using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace eCommerceWebAPI.Model
{
    public class UserData
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string fname { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string lname { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string email { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string username { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string password { get; set; } = "";
    }
}
