using WebMvc.Interface;

namespace WebMvc.Models
{
    public class BookService : IBookSerivce
    {
        private List<BookViewModel> _books;

        public BookService()
        {
            _books = new List<BookViewModel>
            {
                new BookViewModel { Id = 1, Title = "Chatgpt", Price = 100 },
                new BookViewModel { Id = 2, Title = "OpenAi", Price = 200 },
                new BookViewModel { Id = 3, Title = "Claude", Price = 300 }
            };

        }
        public List<BookViewModel> GetAllBooks() => _books;

        public void addBooks(BookViewModel book)
        {
            book.Id = _books.Max(b => b.Id)+1;
            _books.Add(book);
        }

        public BookViewModel GetBook(int id) => _books.FirstOrDefault(b => b.Id == id);

        public void UpdateBook(BookViewModel book)
        {
            var SourceBooks=_books.FirstOrDefault(b => b.Id == book.Id);
            if (book != null)
            {
                SourceBooks.Title = book.Title; 
                SourceBooks.Price = book.Price;

            }
            
                
        }

        public void deleteBook(int id)
        {
            _books.RemoveAll(b => b.Id == id);
        }
    }

//    public class BookService2 : IBookSerivce
//    {
//        private List<BookViewModel> _books;

//        public BookService2()
//        {
//            _books = new List<BookViewModel>
//            {
//                new BookViewModel { Id = 1, Title = "Chatgpt2", Price = 1000 },
//                new BookViewModel { Id = 2, Title = "OpenAi2", Price = 2000 },
//                new BookViewModel { Id = 3, Title = "Claude2", Price = 3000 }
//            };

//        }
//        public List<BookViewModel> GetAllBooks() => _books;

//        public void addBooks(BookViewModel book)
//        {
//            _books.Add(book);
//        }
//    }
}
