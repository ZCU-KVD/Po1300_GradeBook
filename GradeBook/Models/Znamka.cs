using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradeBook.Models
{
	public class Znamka
	{
		[Key]
		public int Id { get; set; }

		[Range(1, 5, ErrorMessage = "Známka musí být mezi 1 a 5.")]
		public int Hodnota { get; set; }

		public DateTime Datum { get; set; } = DateTime.Today;

		public int StudentId { get; set; }
		public int PredmetId { get; set; }

		[Required]
		[ForeignKey(nameof(StudentId))]
		public virtual Student Student { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(PredmetId))]
		public virtual Predmet Predmet { get; set; } = null!;
	}
}
