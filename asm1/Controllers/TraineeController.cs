using asm1.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asm1.Controllers
{
    public class TraineeController : Controller
    {
        private ApplicationDbContext context;
        public TraineeController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Trainee
        
        
            public ActionResult CourseTrainee()

            {
                var userId = User.Identity.GetUserId();

                var ListCourseCategory = context.Topics
                    .Where(c => c.TrainerId == userId)
                    .ToList();
                return View(ListCourseCategory);
            }
            
    }
}