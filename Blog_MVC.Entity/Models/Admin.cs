using System.ComponentModel.DataAnnotations;

namespace Blog_MVC.Entity.Models
{
    public class Admin : Base
    {
        public int AdminID { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string NameSurname { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
