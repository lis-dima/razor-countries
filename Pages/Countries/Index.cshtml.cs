using razor_countries.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace razor_countries.Pages.Countries
{
    public class IndexModel : PageModel
    {
        private AppDbContext context;

        public List<Country> countries;
        public IndexModel(AppDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            countries = context.Countries.ToList();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var contact = await context.Countries.FindAsync(id);

            if (contact != null)
            {
                context.Countries.Remove(contact);
                await context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

    }
}
