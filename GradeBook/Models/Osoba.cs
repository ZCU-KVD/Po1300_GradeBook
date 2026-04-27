using System.ComponentModel.DataAnnotations;

namespace GradeBook.Models
{
	public abstract class Osoba
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Jméno je povinné.")]
		public required string Jmeno { get; set; }

		[Required(ErrorMessage = "Příjmení je povinné.")]
		public required string Prijmeni { get; set; }

		public virtual string CeleJmeno => $"{Jmeno} {Prijmeni}";

	}
}
