using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Data.Data;
using OnlineBookStore.Data.Repository.IRepository;
using OnlineBookStore.Models.Models;

namespace OnlineBookStore.Data.Repository
{
    public class BookRepository: Repository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public IEnumerable<Book> GetAll()
        {
            return _db.Books
                .Include(q => q.Category);
        }

        public void Update(Book book)
        {
            _db.Books.Update(book);
        }
    }
}
