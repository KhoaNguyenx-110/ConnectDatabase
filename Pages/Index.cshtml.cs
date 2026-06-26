using ConnectDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConnectDatabase.Pages
{
    public class IndexModel : PageModel
    {
        private DataContext context;
        public IList<Supplier> SuppliersList { get; set; }
        public Supplier Supplier { get; set; }  
        public IndexModel(DataContext ctx)
        {
            context = ctx;
        }
        public async Task OnGetAsync()
        {
            SuppliersList = await context.Suppliers.ToListAsync();
        }
        public async Task OnGetAsync2(long id = 1)
        {
            Supplier = await context.Suppliers.FindAsync(id);
        }
    }
}
