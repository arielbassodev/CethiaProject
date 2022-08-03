using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetD.Data;
using ProjetD.Models;

namespace ProjetD.Pages.Personnelles
{
    public class IndexModel : PageModel
    {
        private readonly ProjetD.Data.ApplicationDbContext _context;

        public IndexModel(ProjetD.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Personnel> Personnel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Personnel != null)
            {
                Personnel = await _context.Personnel.ToListAsync();
            }
        }
    }
}
