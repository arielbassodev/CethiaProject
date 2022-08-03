using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetD.Models;

namespace ProjetD.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProjetD.Models.Personnel>? Personnel { get; set; }
        public DbSet<ProjetD.Models.Tache>? Tache { get; set; }
    }
}