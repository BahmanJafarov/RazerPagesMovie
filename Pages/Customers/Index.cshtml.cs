using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazerPagesMovie.Data;
using RazerPagesMovie.Models;

namespace RazerPagesMovie.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly CustomerDbContext _context;

        public IndexModel(CustomerDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get; set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var contact = await _context.Customers.FindAsync(id);

            if (contact is not null)
            {
                _context.Customers.Remove(contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
