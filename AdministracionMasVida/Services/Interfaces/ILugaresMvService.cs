using AdministracionMasVida.Entities;
using AdministracionMasVida.Models;

namespace AdministracionMasVida.Services.Interfaces
{
    public interface ILugaresMvService
    {
        ResultApi RegistrarLugar(LugaresMv Lugar);
        ResultApi Get(int Id);
    }
}
