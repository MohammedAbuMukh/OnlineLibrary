using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private LibraryContext context;
        public BooksController(LibraryContext ctx)
        { 
            context = ctx;
        }
        public IActionResult Index()
        {
            var books = context.Books.Include(b=>b.Section).OrderBy(b=>b.Name).ToList();
            return View(books);
        }

        public IActionResult Search(string searchKey)
        {
            var books = context.Books.Where(b => b.Name.Contains(searchKey)).Include(b => b.Section).OrderBy(b => b.Name).ToList();
            return View("Index", books);

        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Sections = context.Sections.OrderBy(c => c.Name).ToList();
            return View();

        }

        [HttpPost]
        public IActionResult Add(Books st)
        {
            context.Books.Add(st);
            context.SaveChanges();
            return RedirectToAction("Index", "Books");

        }

        public IActionResult Delete(int id)
        {
            Books s = context.Books.Where(s => s.BookId == id).FirstOrDefault();
            context.Remove(s);
            context.SaveChanges();

            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("uid") == null)
                return View();

            return View("Welcome");



        }

        [HttpPost]
        public IActionResult Login(int stid, string stpass)
        {
            User b = context.Users.Where(b => b.Id == stid && b.Password == stpass).FirstOrDefault();

            if (b != null)
            {
                HttpContext.Session.SetInt32("uid", stid);
                return View("Welcome");
            }
            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            return View();

        }

        public IActionResult SDetails()
        {
            if (HttpContext.Session.GetInt32("uid") == null)
                return RedirectToAction("Login");

            else
            {
                int? BookID = HttpContext.Session.GetInt32("uid");
                Books b = context.Books.Find(BookID);
                return View(b);
            }
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            if (HttpContext.Session.GetInt32("uid") == null)
                return RedirectToAction("Login");
            return View();

        }

        [HttpPost]

        public IActionResult ChangePassword(string newPass)
        {
            if (HttpContext.Session.GetInt32("uid") == null)
                return RedirectToAction("Login");

            int? sid = HttpContext.Session.GetInt32("uid");
            User b = context.Users.Find(sid);
            b.Password = newPass;
            context.Users.Update(b);
            context.SaveChanges();


            return View("Welcome");

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");


        }




    }
}
