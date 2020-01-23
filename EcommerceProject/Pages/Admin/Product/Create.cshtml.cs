using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EcommerceProject.Models;

namespace EcommerceProject.Pages.Admin.Product
{
    public class CreateModel : PageModel
    {
        private readonly EcommerceProject.Models.TestEcommerceContext _context;

        public CreateModel(TestEcommerceContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TypeId"] = new SelectList(_context.Type, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Models.Product Product { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}