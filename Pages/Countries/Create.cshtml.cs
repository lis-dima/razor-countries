using razor_countries.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace razor_countries.Pages.Countries
{
    public class CreateModel : PageModel
    {
        private AppDbContext context;

        [BindProperty]
        public Country? Country { get; set; } = new Country("");

        public CreateModel(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Country != null) context.Add(Country);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
