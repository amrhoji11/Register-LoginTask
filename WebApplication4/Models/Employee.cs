using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [DataType("varchar")]
        [MaxLength(50)]
        [Display(Name = "Emp Name")]
        public string Name { get; set; }
        [DataType("varchar")]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        [MaxLength(50)]

        public string Password { get; set; }


    }
}
