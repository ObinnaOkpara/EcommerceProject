using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EcommerceProject.Models;

namespace EcommerceProject
{
    public class IndexModel : PageModel
    {
        private readonly EcommerceProject.Models.TestEcommerceContext _context;

        public IndexModel()
        {
            _context = new TestEcommerceContext();
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Product
                .Include(p => p.Type).ToListAsync();
        }
    }
}
