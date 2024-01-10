using AdministracionMasVida.Entities;
using AdministracionMasVida.Models;

namespace AdministracionMasVida.Services.Interfaces
{
    public interface IEventosMvService
    {
        ResultApi RegistrarEvento(EventosMv Evento);
        ResultApi Get(int ID);
        ResultApi EliminarEvento(int Id);
        ResultApi ModificarEvento (EventosMv Evento);
        ResultApi AsignarLugar(AsiganarLugarDto dto);
        ResultApi AsignarGp(AsignarGpDto dto);
    }
}
