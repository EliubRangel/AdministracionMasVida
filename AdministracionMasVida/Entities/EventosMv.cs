namespace AdministracionMasVida.Entities
{
    public class EventosMv
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime fecha { get; set; }
        public string Hora { get; set; }
        public string Lugar { get; set; }
        public string Grupo { get; set; }
        public ICollection <LugaresMv> Lugares {get; set;}
    }
}
