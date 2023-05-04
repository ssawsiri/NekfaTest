using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace ZigzagGarment.Models
{
    [Index(nameof(EmpNo), IsUnique = true)]
    public class Employee
    {
        [Key] 
        public int Id { get; set; }

        [Required]       
        [DisplayName("Employee No")]
        
        public int EmpNo { get; set; }

        [Required]
        [DisplayName("Employee Name")]
        public string EmpName { get; set; }

        [Required]
        [DisplayName("Department")]
        public string Department { get; set; }

        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        public DateTime BirthOfDate { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }

        [Required]
        [DisplayName("NIC No")]
        public string NICNo { get; set; }

       
        [DisplayName("Mobile No")]
        public int MobileNo { get; set; }

    }

   
}
