using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormsIQD.Models
{
    public class FormModel
    {
        public FormModel()
        {
            
        }

        [Key]
        public int id { get; set; }

        [Required]
        public int EmployeeCode { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public int CourseCode { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public DateTime CourseStart { get; set; }

        [Required]
        public DateTime CourseEnd { get; set; }

        [Required]
        public int Radio1 { get; set; }

        [Required]
        public string Answer1 { get; set; }

        [Required]
        public bool WillRecommend { get; set; }
    }
}
