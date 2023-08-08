using CBTD.Data;
using CBTD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Pages.Categories
{
    public class IndexModel : PageModel
    {
		private readonly ApplicationDbContext _db;  //local instance of the database service

		public List<Category> objCategoryList;  //our UI front end will support looping through and displaying Categories retrieved from the database and stored in a List

		public IndexModel(ApplicationDbContext db)  //dependency injection of the database service
		{
			_db = db;
			objCategoryList = new List<Category>();
		}
		public IActionResult OnGet()
        {
			//There are five major sets of IActionResult Types the can be returned
			//1. Server Status Code Results
			//2. Server Status Code and Object Results
			//3. Redirect (to another webpage) Results
			//4. File Results
			//5. Content Results (like another Razor Web Page)
			objCategoryList = _db.Categories.ToList();
			return Page();	  //render Page

		}
	}
}
