namespace GradeBook.Models
{
	public class Student : Osoba
	{
		public DateTime DatumNarozeni { get; set; }

		public virtual List<Znamka> Znamky { get; set; } = new();
	}
}
