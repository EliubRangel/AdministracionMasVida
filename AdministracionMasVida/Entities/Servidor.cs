using System;
namespace AdministracionMasVidaDbContext.Entities
{
	public class Servidor
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public string Correo { get; set; }
		public GrupoPequeno? LiderGrupo { get; set; }
		public ICollection<GrupoPequeno>? MentorGrupos { get; set; }
	}
}

