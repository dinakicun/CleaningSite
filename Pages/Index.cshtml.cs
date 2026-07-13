using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CleaningSite.Data;
using CleaningSite.Models;

namespace CleaningSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _db;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [BindProperty]
        public ContactRequest Request { get; set; } = new();


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.ContactRequests.Add(Request);
            _db.SaveChanges();

            TempData["Success"] = true;
            return RedirectToPage();
        }
    }
}
