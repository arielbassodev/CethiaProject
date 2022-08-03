using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetD.Data;
using ProjetD.Models;

namespace ProjetD.Pages.Personnelles
{
    public class CreateModel : PageModel
    {
        private readonly ProjetD.Data.ApplicationDbContext _context;

        public CreateModel(ProjetD.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Personnel Personnel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Personnel == null || Personnel == null)
            {
                return Page();
            }

            _context.Personnel.Add(Personnel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index1");
        }
    }
}
