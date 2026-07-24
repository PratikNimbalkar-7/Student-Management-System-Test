using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementDATA.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Range(1, 100)]
        public int Age { get; set; }

        [Required]
        public string Course { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
