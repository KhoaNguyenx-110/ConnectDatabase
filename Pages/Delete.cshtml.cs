using ConnectDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConnectDatabase.Pages
{
    public class DeleteModel : PageModel
    {
        private DataContext context;
        public DeleteModel(DataContext ctx)
        {
            context = ctx;
        }
        [BindProperty(SupportsGet = true)]
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
            if (supplier == null || supplier.SupplierId == 0)
            {
                return NotFound();
            }
            var supplierToDelete = await context.Suppliers.FindAsync(supplier.SupplierId);
            if (supplierToDelete == null)
            {
                return NotFound();
            }
            context.Suppliers.Remove(supplierToDelete);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
