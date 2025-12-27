using Microsoft.AspNetCore.Mvc;
using WebMvc.Filters;
using WebMvc.Interface;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class BooksController : BaseController
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
            // 設定 ViewBag 的 Title 屬性
            ViewBag.Title = "書本列表";
            ViewBag.Today = DateTime.Now;

            // 設定 ViewData 的 Description 屬性
            ViewData["Description"] = "這是書本列表頁面，展示所有書本的資訊。";

            // 設定 TempData 的 Message 屬性
            TempData["Today"] = DateTime.Now.ToString("yyyy-MM-dd");
            return View(books);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int id)
        {
            var books = _bookSerivce.GetAllBooks().ToList().FindAll(b => b.Id == id);
            ViewBag.Id = id;
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
            _bookSerivce.addBooks(book);
            TempData["Message"] = "新增書籍成功！";
            return  RedirectToAction("Index");
        }
        [HttpGet]
        [Route("books/update/{id}")]
        public IActionResult Update(int id)
        {
            var book = _bookSerivce.GetBook(id);
            if( book == null)
            {
                //ViewBag.ErrorMessage = $"找不到Id為{id}的書籍";
                return ShowNotFound("書籍",id,"/Books");
            }
            return View(book); 
        }
        [HttpPost]
        [Route("books/update/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id,BookViewModel book)
        {
            Console.WriteLine($"Id:{book.Id},Title{book.Title},Price:{book.Price}");
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            _bookSerivce.UpdateBook(book);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("books/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookSerivce.GetBook(id);
            if (book == null)
            {
                ViewBag.ErrorMessage = $"找不到Id為{id}的書籍";
                return View();
            }
            return View(book);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(BookViewModel book)
        {
            _bookSerivce.deleteBook(book.Id);
            return RedirectToAction(nameof(Index));
        }

    }

}
