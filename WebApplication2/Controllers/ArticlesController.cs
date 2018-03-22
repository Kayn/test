using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using Microsoft.AspNet.Identity;
using WebApplication2.Models.DBModels;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class ArticlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Articles
        public ActionResult Index()
        {
            return View(db.Articles.ToList());
        }

        // GET: Articles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Share(Guid articleId)
        {
            if (articleId == null)
            {
                return HttpNotFound();
            }
            var uid =  User.Identity.GetUserId();
            var articlesCount = db.SharedArticles.Where(w => w.UserID == uid).Count();

            if (articlesCount > 2) return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Maxium 3 Articles can be shared.");

            var duplicate = db.SharedArticles.Where(w => w.UserID == uid && w.ArticleID == articleId).FirstOrDefault();

            if (duplicate != null)
            {
                return Content("Articles/SharedArticle/" + duplicate.ID);
            }

            var sharedArticle = new SharedArticle();
            sharedArticle.ID = Guid.NewGuid();
            sharedArticle.UserID = User.Identity.GetUserId();
            sharedArticle.ArticleID = articleId;
            db.SharedArticles.Add(sharedArticle);
            db.SaveChanges();

            return Content("Articles/SharedArticle/"+sharedArticle.ID);
        }

        [AllowAnonymous]
        // GET: SharedArticles/Details/5
        public ActionResult SharedArticle(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SharedArticle sharedArticle = db.SharedArticles.Include(s => s.Article).Where(w => w.ID == id).FirstOrDefault();
            if (sharedArticle == null || sharedArticle.Article == null)
            {
                return HttpNotFound();
            }

            return View("Details", sharedArticle.Article);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
