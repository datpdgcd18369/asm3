using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asm1.Models
{
    public class Course
    {

        [Key]
        [Required]

        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter subject name")]
        public string Name { get; set; }
        public string Description { get; set; }

        public string TopicId { get; set; }
        public Topic Topic { get; set; }

       
        public virtual ICollection<CategoryCourse> CategoryCourses { get; set; }

        public virtual ICollection<CourseTrainee> CourseTrainees { get; set; }
    }
}
