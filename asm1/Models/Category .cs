using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asm1.Models
{
    public class Category
    {

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please input class start date")]
        public string Descriptions { get; set; }

        public virtual ICollection<CategoryCourse> CategoryCourses{get; set;}
    }
}
  

   
  