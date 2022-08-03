using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetD.Data;
using ProjetD.Models;

namespace ProjetD.Pages.Taches
{
    public class DetailsModel : PageModel
    {
        private readonly ProjetD.Data.ApplicationDbContext _context;

        public DetailsModel(ProjetD.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Tache Tache { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tache == null)
            {
                return NotFound();
            }

            var tache = await _context.Tache.FirstOrDefaultAsync(m => m.ID == id);
            if (tache == null)
            {
                return NotFound();
            }
            else 
            {
                Tache = tache;
            }
            return Page();
        }
    }
}
