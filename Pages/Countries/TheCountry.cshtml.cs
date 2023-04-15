using razor_countries.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razor_countries.Pages.Countries
{
    public class TheCountryModel : PageModel
    {
        private readonly AppDbContext context;

        [BindProperty]
        public Country Country { get; set; }

        public TheCountryModel(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult OnGet(Guid id)
        {
            Country = context.Countries.FirstOrDefault(c => c.Id == id);
            return Page();
        }
    }
}
