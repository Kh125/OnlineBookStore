using OnlineBookStore.Data.Data;
using OnlineBookStore.Data.Repository.IRepository;

namespace OnlineBookStore.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository CategoryRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public IBookRepository BookRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
            UserRepository = new UserRepository(_db);
            BookRepository = new BookRepository(_db);
        }
        
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
