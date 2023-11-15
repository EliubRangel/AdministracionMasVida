using System;
using System.ComponentModel.DataAnnotations;

namespace AdministracionMasVidaDbContext.Entities
{
	public class GrupoPequeno
	{
		[Key]
		public int Id { get; set; }
		public string NombreGrupo { get; set; }
		public ICollection<Servidor> Lideres { get; set; }
		public string Direccion { get; set; }
		public string Dia { get; set; }
		public string HoraInico { get; set; }
		public string HoraFin { get; set; }
		public string Descripcion { get; set; }
		public ICollection<Miembro> Miembro { get; set; }
		public Servidor Mentor { get; set; }


		public GrupoPequeno()
		{
			this.Miembro = new List<Miembro>();
		}
			
	}
}

