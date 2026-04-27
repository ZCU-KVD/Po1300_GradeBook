using System.ComponentModel.DataAnnotations;

namespace GradeBook.Models
{
	public class Ucitel : Osoba
	{
		[Required(ErrorMessage = "Titul je povinný.")]
		[StringLength(10, ErrorMessage = "Titul nesmí být delší než 10 znaků.")]
		public required string Titul { get; set; }

		public override string CeleJmeno => $"{Titul} {base.CeleJmeno}".Trim();

		public virtual List<Predmet> Predmety { get; set; } = new();
	}
}
