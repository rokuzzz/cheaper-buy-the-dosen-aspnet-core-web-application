using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Pages.Categories;

public class UpsertModel : PageModel
{
    private readonly ApplicationDbContext _db;
    [BindProperty]  //synchonizes form fields with values in code behind
    public Category objCategory { get; set; }


    public UpsertModel(ApplicationDbContext db)  //dependency injection
    {
        _db = db;
        objCategory = new Category();
    }

    public IActionResult OnGet(int? id)
    {
       
        //edit mode
        if (id != 0)
        {
            objCategory = _db.Categories.Find(id);
        }

        if (objCategory == null)
        {
            return NotFound();
        }

        //create new mode
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        //if this is a new Category
        if (objCategory.CategoryId == 0)
        {
            _db.Categories.Add(objCategory);
            TempData["success"] = "Category added Successfully";
        }
        //if category exists
        else
        {
            _db.Categories.Update(objCategory);
            TempData["success"] = "Category updated Successfully";
        }
        _db.SaveChanges();

        return RedirectToPage("./Index");
    }

}
