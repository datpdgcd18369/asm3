using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace asm1.Models
{
    public class CourseTrainee
    {
		[Key]
		[Column(Order =1)]

		public int TraineeID { get; set; }

		[Key]
		[Column(Order = 2)]
		public int CourseID { get; set; }

		public Course Course { get; set; }
		public Trainee Trainee { get; set; }
	}
}