using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetD.Data;
using ProjetD.Models;

namespace ProjetD.Pages.Taches
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
        public Tache Tache { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Tache == null || Tache == null)
            {
                return Page();
            }

            _context.Tache.Add(Tache);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
