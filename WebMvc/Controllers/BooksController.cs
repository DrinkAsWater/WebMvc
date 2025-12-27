using Microsoft.AspNetCore.Mvc;
using WebMvc.Interface;
using WebMvc.Models;

namespace WebMvc.Controllers
{
 
    public class BooksController : Controller
    {
        private readonly IBookSerivce _bookSerivce;
        public BooksController(IBookSerivce bookSerivce) {
            _bookSerivce = bookSerivce;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //var bookService = new BookService();
            var books = _bookSerivce.GetAllBooks();
            ViewBag.CurrentTime = DateTime.Now;
            return View(books);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookViewModel book)
        {
            if (!ModelState.IsValid)
            {
              

            return View(book);
            }
            TempData["Message"] = "新增書籍成功！";
            return  RedirectToAction("Index");
        }
    }

}
