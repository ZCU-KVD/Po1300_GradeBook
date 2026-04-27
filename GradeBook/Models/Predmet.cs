using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradeBook.Models
{
	public class Predmet
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Název předmětu je povinný.")]
		public required string Nazev { get; set; }

		[Required(ErrorMessage = "Zkratka předmětu je povinná.")]
		[StringLength(5, ErrorMessage = "Zkratka nesmí být delší než 5 znaků.")]
		public required string Zkratka { get; set; }

		public int GarandId { get; set; }

		[Required(ErrorMessage = "Musíte vybrat garanta.")]
		[ForeignKey("GarandId")]
		[InverseProperty(nameof(Ucitel.Predmety))]
		public virtual Ucitel Garant { get; set; } = null!;
	}
}
