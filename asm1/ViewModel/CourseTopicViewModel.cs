using asm1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asm1.ViewModel
{
    public class CourseTopicViewModel
    {
        public Course Course { get; set; }

        public IEnumerable<Topic> Topics { get; set; }

    }
}