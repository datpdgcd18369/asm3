using asm1.Models;
using asm1.ViewModel;
using Gremlin.Net.Process.Traversal;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace asm1.Controllers
{
    public class TrainerStaffController : Controller
    {
        private ApplicationDbContext context;
        public TrainerStaffController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Products
        [HttpGet]
        
        public ActionResult Index(string searchString)
        {
             var list = context.Categorys.Where(x => x.Name.Contains("searchString") || searchString == null).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult CreateCategorys()
        {
            
            return View();
            
        }

        
        [HttpPost]
        public ActionResult CreateCategoryss(Category category)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateCategorys");
            }
            context.Categorys.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var productInDb = context.Categorys.SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
            {
                return HttpNotFound();
            }

            context.Categorys.Remove(productInDb);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var productInDb = context.Categorys.SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
            {
                return HttpNotFound();
            }

            return View(productInDb);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            var productInDb = context.Categorys.SingleOrDefault(p => p.Id == category.Id);

            if (productInDb == null)
            {
                return HttpNotFound();
            }

            productInDb.Name = category.Name;
            productInDb.Descriptions = category.Descriptions;



            context.SaveChanges();

            return RedirectToAction("Index");
        }
        //----------------------------------------------------------------
        //----------------------------------------------------------------
        //----------------------------------------------------------------
        [HttpGet]
        public ActionResult CourseIndex(string searchString)
        {
            var list = context.Courses.Include(x => x.Topic)
                .Where(x => x.Name.Contains("searchString") || searchString == null)
                .ToList();
            return View(list);
        }
        [HttpGet]

        public ActionResult CreateCourse()
        {
            var viewModel = new CourseTopicViewModel();
            viewModel.Topics = context.Topics.ToList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateCourse");
            }
            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("CourseIndex");
        }


        public ActionResult DeleteCourse(int id)
        {
            var CourseInDb = context.Courses.SingleOrDefault(p => p.Id == id);

            if (CourseInDb == null)
            {
                return HttpNotFound();
            }

            context.Courses.Remove(CourseInDb);
            context.SaveChanges();
            return RedirectToAction("CourseIndex");
        }

        [HttpGet]

        public ActionResult EditCourse(int id)
        {
            var CourseInDb = context.Courses.SingleOrDefault(p => p.Id == id);

            if (CourseInDb == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CourseTopicViewModel();
            viewModel.Course = CourseInDb;

            viewModel.Topics = context.Topics.ToList();

            return View(viewModel);
        }

        [HttpPost]

        public ActionResult EditCourse(Course course)
        {
            var CourseInDb = context.Courses.SingleOrDefault(p => p.Id == course.Id);

            if (CourseInDb == null)
            {
                return HttpNotFound();
            }

            CourseInDb.Name = course.Name;
            CourseInDb.Description = course.Description;
            CourseInDb.Topic = course.Topic;
            context.SaveChanges();
            return RedirectToAction("CourseIndex");
        }

        //----------------------------------------------------------------
        //----------------------------------------------------------------
        //----------------------------------------------------------------
        [HttpGet]
        public ActionResult CourseCategory()

        {
            var ListCourseCategory = context.CategoryCourses.Include(x => x.Course).Include(x=>x.Category).ToList();
            return View(ListCourseCategory);
                            
        }
        [HttpGet]
        public ActionResult CreateCourseCategory()
        {
            ViewBag.Course = context.Courses;
            ViewBag.Category = new SelectList(context.Categorys, "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult CreateCourseCategory(int categoryId, int [] courseID)
        {
            foreach (int CatId in courseID)
            {
                CategoryCourse categoryCourse = new CategoryCourse();
                categoryCourse.CourseId = CatId;
                categoryCourse.CategoryId = categoryId;
                context.CategoryCourses.Add(categoryCourse);
                context.SaveChanges();

            }
            return RedirectToAction("CourseCategory");
        }
       
        public ActionResult DeleteCourseCategory(int id)
        {
            var categoryCourse = context.CategoryCourses.SingleOrDefault(
                p => p.CategoryId == id );

            if (categoryCourse == null)
            {
                return HttpNotFound();
            }

            context.CategoryCourses.Remove(categoryCourse);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //----------------------------------------------------------------
        //----------------------------------------------------------------
        //----------------------------------------------------------------
        [HttpGet]
        public ActionResult CourseTrainee()

        {
            var ListCourseCategory = context.CourseTrainees.Include(x => x.Course).Include(x => x.Trainee)
                .ToList();
            return View(ListCourseCategory);

        }
        [HttpGet]
        public ActionResult CreateCourseTrainee()
        {
            ViewBag.trainee = context.Trainees;
            ViewBag.Course1 = new SelectList(context.Courses, "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult CreateCourseTrainee(int courseID, int[] traineeId)
        {
            foreach (int CatId in traineeId)
            {
                CourseTrainee courseTrainee = new CourseTrainee();
                courseTrainee.CourseID = courseID;
                courseTrainee.TraineeID = CatId;
                context.CourseTrainees.Add(courseTrainee);
                context.SaveChanges();

            }
            return RedirectToAction("CourseTrainee");
        }
        
        public ActionResult DeleteCourseTraineey(int id)
        {
            var courseTrainee = context.CourseTrainees.SingleOrDefault(p => p.CourseID == id);

            if (courseTrainee == null)
            {
                return HttpNotFound();
            }

            context.CourseTrainees.Remove(courseTrainee);
            context.SaveChanges();
            return RedirectToAction("CourseTrainee");
        }
        //----------------------------------------------------------------
        //----------------------------------------------------------------
        //----------------------------------------------------------------
        [HttpGet]
        public ActionResult TopicIndex()
        {
            var list = context.Topics.Include(x =>x.Trainer)           
                .ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult TopicTrainerview()
        {
            var userId = User.Identity.GetUserId();
            var list = context.Topics.Include(x => x.Trainer)
                .Where(x =>x. Trainer.UserId == userId)
                .ToList();
            return View(list);
        }
        [HttpGet]

        public ActionResult CreateTopic()
        {
            var viewModel = new TopicTrainer();
            viewModel.Trainers = context.Trainers.Where(x => x.RoleName.Contains("Trainer")).ToList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateTopic(Topic topic)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateTopic");
            }
            context.Topics.Add(topic);
            context.SaveChanges();
            return RedirectToAction("TopicIndex");
        }


        public ActionResult DeleteTopic(int id)
        {
            var TopitInDb = context.Topics.SingleOrDefault(p => p.Id == id);

            if (TopitInDb == null)
            {
                return HttpNotFound();
            }

            context.Topics.Remove(TopitInDb);
            context.SaveChanges();
            return RedirectToAction("TopicIndex");
        }

        [HttpGet]

        public ActionResult EditTopic(int id)
        {
            var TopitInDb = context.Topics.SingleOrDefault(p => p.Id == id);

            if (TopitInDb == null)
            {
                return HttpNotFound();
            }

            var topics = new TopicTrainer();
            topics.Topic = TopitInDb;

            topics.Trainers = context.Trainers
                
                .ToList();

            return View(topics);
        }

        [HttpPost]

        public ActionResult EditTopic(Topic topic)
        {
            var TopitInDb = context.Topics.SingleOrDefault(p => p.Id == topic.Id);

            if (TopitInDb == null)
            {
                return HttpNotFound();
            }

            TopitInDb.Name = topic.Name;
            TopitInDb.Description = topic.Description;
            TopitInDb.Trainer = topic.Trainer;
            context.SaveChanges();
            return RedirectToAction("TopicIndex");
        }
    }
}