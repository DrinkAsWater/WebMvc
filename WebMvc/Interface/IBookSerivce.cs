using WebMvc.Models;

namespace WebMvc.Interface
{
    public interface IBookSerivce
    {
        public List<BookViewModel> GetAllBooks();

         void addBooks(BookViewModel book);

        BookViewModel GetBook(int id);

        void UpdateBook(BookViewModel book);

        void deleteBook(int id);
    }
}
