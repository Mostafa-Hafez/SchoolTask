using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.DTOs.CourseDTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [RegularExpression("")]
        public string Description { get; set; }

    }
}
