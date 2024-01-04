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
		public GrupoPequeno? grupoPequenos { get; set; }


		
	}
}

