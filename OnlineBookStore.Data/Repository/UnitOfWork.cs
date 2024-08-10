using OnlineBookStore.Data.Data;
using OnlineBookStore.Data.Repository.IRepository;
using OnlineBookStore.Models.Models;

namespace OnlineBookStore.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository CategoryRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
        }
        
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
