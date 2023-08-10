using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]  //synchonizes form fields with values in code behind
        public Category objCategory { get; set; }


        public DeleteModel(ApplicationDbContext db)  //dependency injection
        {
            _db = db;
            objCategory = new Category();
        }

        public IActionResult OnGet(int? id)
        {
           
            
            if (id != 0)
            {
                objCategory = _db.Categories.Find(id);
            }

            if (objCategory == null)
            {
                return NotFound();
            }

            
            return Page();
        }

        public IActionResult OnPost()
        {
         
                _db.Categories.Remove(objCategory);
                TempData["success"] = "Category deleted Successfully";
            
                _db.SaveChanges();

            return RedirectToPage("./Index");
        }


    }
}
