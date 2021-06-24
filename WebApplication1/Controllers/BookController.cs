using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListBook()
        {
            BookManagerContext context = new BookManagerContext();
            var listBook = context.Books.ToList();
            return View(listBook);
        }

        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerContext ctx = new BookManagerContext();
            Book book = ctx.Books.SingleOrDefault(p => p.ID == id);
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult CreateBook()
        {
            return View();
        }
        [Authorize]
        [HttpPost, ActionName("CreateBook")]
        public ActionResult CreateBook([Bind(Include = "ID, Title, Description, Author, Images, Price")] Book b)
        {
            BookManagerContext ctx = new BookManagerContext();
            if (ModelState.IsValid)
            {
                ctx.Books.AddOrUpdate(b);
                ctx.SaveChanges();
            }
            return RedirectToAction("ListBook");
        }

        /*public ActionResult EditBook(int id, Book b)
        {
            BookManagerContext ctx = new BookManagerContext();
            List<Book> listbook = ctx.Books.ToList();
            return View(listbook.FirstOrDefault());
        }
        [Authorize]
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook([Bind(Include = "ID, Title, Description, Author, Images, Price")] Book book)
        {
            BookManagerContext ctx = new BookManagerContext();
            List<Book> listBook = ctx.Books.ToList();
            if (ModelState.IsValid)
            {
                ctx.Books.AddOrUpdate(book);
                ctx.SaveChanges();
                return RedirectToAction("ListBook");
            }
            return RedirectToAction("ListBook", listBook);
        }*/

        public ActionResult EditBook(int? id)
        {
            BookManagerContext context = new BookManagerContext();
            List<Book> listBook = context.Books.ToList();
            Book book = context.Books.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Authorize]
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook([Bind(Include = "ID, Title, Description,Author, Images, Price")] Book book)
        {
            BookManagerContext context = new BookManagerContext();
            List<Book> listBook = context.Books.ToList();
            if (ModelState.IsValid)
            {
                context.Books.AddOrUpdate(book);
                context.SaveChanges();
                return RedirectToAction("ListBook");
            }
            return View(book);
        }

        public ActionResult Delete(int? id)
        {
            BookManagerContext context = new BookManagerContext();
            List<Book> listBook = context.Books.ToList();
            Book book = context.Books.Find(id);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            BookManagerContext context = new BookManagerContext();
            List<Book> listBook = context.Books.ToList();
            Book book = context.Books.Find(id);
            context.Books.Remove(book);
            context.SaveChanges();
            return RedirectToAction("ListBook");
        }
    }
}