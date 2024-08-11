using OnlineBookStore.Models.Models;

namespace OnlineBookStore.Data.ViewModel
{
    public class BookCreateViewModel
    {
        public Book book { get; set; }
        public List<Category> categories{ get; set; }
    }
}
