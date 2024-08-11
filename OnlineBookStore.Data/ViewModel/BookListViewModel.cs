using OnlineBookStore.Models.Models;

namespace OnlineBookStore.Data.ViewModel
{
    public class BookListViewModel
    {
        public List<Book> Books { get; set; }

        public List<Category> Categories { get; set; }
    }
}
