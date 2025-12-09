using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.DTOs.StudentDTOs
{
    public class AddStudentDTO
    {

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int ClassId { get; set; }
    }
}
