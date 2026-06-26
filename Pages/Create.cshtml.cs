using ConnectDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConnectDatabase.Pages
{
    public class CreateModel : PageModel
    {
        private DataContext context;
        [BindProperty]
        public Supplier Supplier { get; set; }
        public CreateModel(DataContext ctx)
        {
            context = ctx;
        }

        public void OnGet()
        {
        }
        public async Task <IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                context.Suppliers.Add(Supplier);
                await context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else return Page();
        }
    }
}
