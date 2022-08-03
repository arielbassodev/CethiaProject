using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetD.Data;
using ProjetD.Models;

namespace ProjetD.Pages.Personnelles
{
    public class EditModel : PageModel
    {
        private readonly ProjetD.Data.ApplicationDbContext _context;

        public EditModel(ProjetD.Data.ApplicationDbContext context)
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

            var personnel =  await _context.Personnel.FirstOrDefaultAsync(m => m.ID == id);
            if (personnel == null)
            {
                return NotFound();
            }
            Personnel = personnel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Personnel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonnelExists(Personnel.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PersonnelExists(int id)
        {
          return (_context.Personnel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
