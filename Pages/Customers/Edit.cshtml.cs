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
    public class EditModel : PageModel
    {
        private readonly CustomerDbContext _context;

        public EditModel(CustomerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _context.Customers.FindAsync(id);

            if (Customer is null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Customer {Customer.Id} not found!");
            }

            return RedirectToPage("./Index");
        }
    }
}
