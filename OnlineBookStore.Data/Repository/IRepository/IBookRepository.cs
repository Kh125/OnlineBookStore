using OnlineBookStore.Models.Models;

namespace OnlineBookStore.Data.Repository.IRepository
{
    public interface IBookRepository: IRepository<Book>
    {
        IEnumerable<Book> GetAll();
        void Update(Book book);
    }
}
