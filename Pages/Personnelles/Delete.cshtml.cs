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
    public class DeleteModel : PageModel
    {
        private readonly ProjetD.Data.ApplicationDbContext _context;

        public DeleteModel(ProjetD.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Personnel Personnel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Personnel == null)
            {
                return NotFound();
            }

            var personnel = await _context.Personnel.FirstOrDefaultAsync(m => m.ID == id);

            if (personnel == null)
            {
                return NotFound();
            }
            else 
            {
                Personnel = personnel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Personnel == null)
            {
                return NotFound();
            }
            var personnel = await _context.Personnel.FindAsync(id);

            if (personnel != null)
            {
                Personnel = personnel;
                _context.Personnel.Remove(Personnel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
