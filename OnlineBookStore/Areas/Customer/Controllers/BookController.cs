using Microsoft.AspNetCore.Mvc;
using OnlineBookStore.Data.Repository.IRepository;
using OnlineBookStore.Models.Models;

namespace OnlineBookStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Book> books = _unitOfWork.BookRepository.GetAll().ToList();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
