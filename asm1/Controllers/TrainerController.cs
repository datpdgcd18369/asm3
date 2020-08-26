using asm1.Models;
using asm1.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asm1.Controllers
{
    public class TrainerController : Controller
    {
        private ApplicationDbContext context;
        public TrainerController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Traine
        [HttpGet]
        public ActionResult Index()
        {
            var list = context.Trainers.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new AccountTraner();
            viewModel.Users = context.Users.Where(x => x.RoleName.Contains("Trainer")).ToList();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            context.Trainers.Add(trainer);
            context.SaveChanges();
            return RedirectToAction("Topic");
        }


        public ActionResult Delete(int id)
        {
            var TopitInDb = context.Trainers.SingleOrDefault(p => p.Id == id);

            if (TopitInDb == null)
            {
                return HttpNotFound();
            }

            context.Trainers.Remove(TopitInDb);
            context.SaveChanges();
            return RedirectToAction("Topic");
        }

        [HttpGet]

        public ActionResult EditTopic(int id)
        {
            var TopitInDb = context.Trainers.SingleOrDefault(p => p.Id == id);

            if (TopitInDb == null)
            {
                return HttpNotFound();
            }

            var topics = new AccountTraner();
            topics.Trainer = TopitInDb;

            topics.Users = context.Users

                .ToList();

            return View(topics);
        }

        [HttpPost]

        public ActionResult EditTopic(Trainer trainer)
        {
            var TopitInDb = context.Trainers.SingleOrDefault(p => p.Id == trainer.Id);

            if (TopitInDb == null)
            {
                return HttpNotFound();
            }

            TopitInDb.Name = trainer.Name;
            TopitInDb.Phone = trainer.Phone;
            TopitInDb.Workplace = trainer.Phone;
           
            TopitInDb.UserId = trainer.UserId;
            context.SaveChanges();
            return RedirectToAction("TopicIndex");
        }

        // GET: Traine
        [HttpGet]
        public ActionResult IndexTrainer()
        {
            var userId = User.Identity.GetUserId();
            var list = context.Trainers
                .Where(c => c.UserId == userId)              
                .ToList();
            return View(list);
        }

    }
}