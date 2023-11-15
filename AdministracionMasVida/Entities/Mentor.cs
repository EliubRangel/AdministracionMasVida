using System;
using System.ComponentModel.DataAnnotations;

namespace AdministracionMasVidaDbContext.Entities
{
	public class Mentor
	{
		[Key]
		public int Id { get; set; }
		public string Nombre { get; set; }
		public ICollection<GrupoPequeno> grupoPequenos { get; set; }

		public Mentor()
		{
			this.grupoPequenos = new List<GrupoPequeno>();
		}
	}
}

