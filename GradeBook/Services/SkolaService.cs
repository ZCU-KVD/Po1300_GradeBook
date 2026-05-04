using GradeBook.Data;
using Microsoft.EntityFrameworkCore;

namespace GradeBook.Services
{
	public class SkolaService(SkolaDbContext db)
	{
		public async Task InicializaceAsync()
		{
			await db.Database.MigrateAsync();

			if (!await db.Predmety.AnyAsync())
			{
				var ucitel = new Models.Ucitel { Jmeno = "Jan", Prijmeni = "Novak", Titul = "Ph.D." };
				var predmet = new Models.Predmet { Nazev = "Matematika", Zkratka = "MAT", Garant = ucitel };

				var ucitel2 = new Models.Ucitel { Jmeno = "Franta", Prijmeni = "Omáčka", Titul = "Mgr." };
				var predmet2 = new Models.Predmet { Nazev = "Informatika", Zkratka = "INF", Garant = ucitel2 };

				//db.Ucitele.Add(ucitel);
				db.Ucitele.AddRange(ucitel, ucitel2);
				db.Predmety.AddRange(predmet, predmet2);
				await db.SaveChangesAsync();
			}
		}
	}
}