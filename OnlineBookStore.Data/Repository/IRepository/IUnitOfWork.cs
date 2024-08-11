namespace OnlineBookStore.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }

        IUserRepository UserRepository { get; }

        IBookRepository BookRepository { get; }

        void Save();
    }
}