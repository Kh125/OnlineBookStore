using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookStore_Temp.Data;
using OnlineBookStore_Temp.Models;

namespace OnlineBookStore_Temp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.FirstOrDefault(q => q.Id == id);
                _db.Categories.Remove(Category);
                _db.SaveChanges();
                TempData["success"] = "The category has been deleted successfully.";

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
