using Microsoft.EntityFrameworkCore;

namespace GradeBook.Data
{
	public class SkolaDbContext : DbContext
	{
		public SkolaDbContext(DbContextOptions<SkolaDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Models.Ucitel>()
				.HasMany(z => z.Predmety)
				.WithOne(s => s.Garant)
				.HasForeignKey(z => z.GarandId)
				.OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<Models.Predmet>()
				.HasMany(z => z.Znamky)
				.WithOne(p => p.Predmet)
				.HasForeignKey(z => z.PredmetId)
				.OnDelete(DeleteBehavior.Cascade);
		}

		public DbSet<Models.Student> Studenti { get; set; } 
		public DbSet<Models.Ucitel> Ucitele { get; set; }
		public DbSet<Models.Predmet> Predmety { get; set; }
		public DbSet<Models.Znamka> Znamky { get; set; }
	}
}
