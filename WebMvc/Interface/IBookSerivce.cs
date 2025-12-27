using WebMvc.Models;

namespace WebMvc.Interface
{
    public interface IBookSerivce
    {
        public List<BookViewModel> GetAllBooks();

        public void addBooks(BookViewModel book);
    }
}
