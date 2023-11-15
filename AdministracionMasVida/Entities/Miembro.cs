using System;
namespace AdministracionMasVidaDbContext.Entities
{
	public class Miembro
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Telefono { get; set; }
		public string Correo { get; set; }
		public ICollection<GrupoPequeno> grupoPequenos { get; set; }


		public Miembro()
		{
			this.grupoPequenos = new List<GrupoPequeno>();
		}
	}
}

