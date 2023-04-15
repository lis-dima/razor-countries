using razor_countries.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace razor_countries.Pages.Countries
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext context;

        [BindProperty]
        public Country Country { get; set; }

        public EditModel(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Country = await context.Countries.FirstOrDefaultAsync(m => m.Id == id);

            if (Country == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Country != null)
            {
                context.Attach(Country).State = EntityState.Modified;

                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(Country.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CountryExists(Guid id)
        {
            return context.Countries.Any(e => e.Id == id);
        }
    }
}
