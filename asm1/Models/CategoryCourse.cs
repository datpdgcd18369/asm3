using Gremlin.Net.Process.Traversal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace asm1.Models
{
    public class CategoryCourse
    {
		[Key]
		[Column(Order=1)]
		
		public int CourseId { get; set; }

		[Key]
		[Column(Order = 2)]
		public int CategoryId { get; set; }

		public Course Course { get; set; }
		public Category Category { get; set; }
	}

}