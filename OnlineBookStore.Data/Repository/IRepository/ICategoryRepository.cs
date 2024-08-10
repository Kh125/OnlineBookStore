using OnlineBookStore.Models.Models;

namespace OnlineBookStore.Data.Repository.IRepository
{
    public interface ICategoryRepository: IRepository<Category>
    {
        void Update(Category category);
    }
}
