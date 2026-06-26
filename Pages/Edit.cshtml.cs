using ConnectDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConnectDatabase.Pages
{
    public class EditModel : PageModel
    {
        private DataContext context;
        public EditModel(DataContext ctx)
        {
            context = ctx;  
        }
        [BindProperty]
        public Supplier supplier { get; set; }
        public async Task<IActionResult> OnGetAsync(long id)
        {
            supplier = await context.Suppliers.FindAsync(id);
            if (supplier == null)
                return NotFound();
            else
                return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            context.Attach(supplier).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
