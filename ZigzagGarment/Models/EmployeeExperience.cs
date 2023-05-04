
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ZigzagGarment.Models
{
    public class EmployeeExperience
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [Required]
        [DisplayName("Employee No")]
        public int EmpNo { get; set; }

        [DisplayName("Employee Name")]
        public string EmpName { get; set; }

        [DisplayName("Company Name")]
        [AllowNull]
        public string Company { get; set; }
        [AllowNull]
        [DisplayName("Job Role")]
        public string Position { get; set; }
        [AllowNull]
        [DisplayName("Job Start Year")]
        public int StartYear { get; set; }
        [AllowNull]
        [DisplayName("Job End Year")]
        public int EndYear { get; set; }
        [AllowNull]
        [DisplayName("Job Experience")]
        public int Experience { get; set; }

    }
}
