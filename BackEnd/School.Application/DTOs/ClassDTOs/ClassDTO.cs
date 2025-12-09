using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.DTOs.ClassDTOs
{
    public class ClassDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string TeacherName { get; set; } = default!;
        
    }
}
