using AdministracionMasVida.Models;
using AdministracionMasVidaDbContext.Entities;

namespace AdministracionMasVida.Entities
{
    public class EventosMv
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public GrupoPequeno? Gp { get; set; }
        public LugaresMv? Lugar {get; set;}
    }
}
