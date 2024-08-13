using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStore.Data.Repository.IRepository;
using OnlineBookStore.Data.ViewModel;
using OnlineBookStore.Models.Models;
using OnlineBookStore.Utils;

namespace OnlineBookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var books = _unitOfWork.BookRepository
                .GetAll()
                .ToList();

            if (books is null) return NotFound();

            return View(books);
        }

        public IActionResult Create()
        {
            List<Category> categoryList = _unitOfWork.CategoryRepository.GetAll().ToList();

            if (categoryList is null) return NotFound();

            BookCreateViewModel bookCreateViewModel = new BookCreateViewModel
            {
                book = new Book(),
                categories = categoryList
            };

            return View(bookCreateViewModel);
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if(book is not null)
            {
                book.Price = decimal.Parse(book.Price.ToString("0.00"));
                _unitOfWork.BookRepository.Add(book);
                _unitOfWork.Save();
                TempData["success"] = "The book has been added successfully.";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if(id == 0 || id is null)
            {
                return NotFound();
            }

            Book? book = _unitOfWork.BookRepository.Get(q => q.Id == id);

            if(book is null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (book is not null)
            {
                _unitOfWork.BookRepository.Update(book);
                _unitOfWork.Save();
                TempData["success"] = "The book has been updated successfully.";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id is null)
            {
                return NotFound();
            }

            Book book = _unitOfWork.BookRepository.Get(q => q.Id == id);

            if (book is null) return NotFound();

            _unitOfWork.BookRepository.Remove(book);
            _unitOfWork.Save();
            TempData["success"] = "The book has been deleted successfully.";

            return RedirectToAction("Index");
        }
    }
}
