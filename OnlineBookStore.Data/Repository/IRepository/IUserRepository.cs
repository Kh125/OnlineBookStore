using OnlineBookStore.Models.Models;

namespace OnlineBookStore.Data.Repository.IRepository
{
    public interface IUserRepository: IRepository<User>
    {
        void Update(User user);
    }
}
