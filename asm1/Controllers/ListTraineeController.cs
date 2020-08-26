using asm1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asm1.Controllers
{
    public class ListTraineeController : Controller
    {
        private ApplicationDbContext context;
        public ListTraineeController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Products
        [HttpGet]
        [AllowAnonymous]

        public ActionResult ListTrainee(string searchString)

        {
            var lisi =context.Users.Where(x => x.FullName.Contains("searchString") || searchString == null).ToList();
            return View();

        }
		[HttpGet]
		public ActionResult Edit(string id)
		{
			var productInDb = context.Users.SingleOrDefault(p => p.Id == id);

			if (productInDb == null)
			{
				return HttpNotFound();
			}

			return View(productInDb);
		}

		[HttpPost]
		public ActionResult Edit(ApplicationUser id)
		{
			var productInDb = context.Users.SingleOrDefault(p => p.Id == id.Id);

			if (productInDb == null)
			{
				return HttpNotFound();
			}

			productInDb.FullName = id.FullName;
			productInDb.Age = id.Age;
		


			context.SaveChanges();

			return RedirectToAction("ListTrainee");
		}
		public ActionResult Delete(String id)
		{
			var productInDb = context.Users.SingleOrDefault(p => p.Id == id);

			if (productInDb == null)
			{
				return HttpNotFound();
			}

			context.Users.Remove(productInDb);
			context.SaveChanges();
			return RedirectToAction("ListClass");
		}



	}
}