using System;
using AdministracionMasVida.Models;
using AdministracionMasVidaDbContext.Entities;

namespace AdministracionMasVidaDbContext.Services.Interfaces
{
	public interface IGrupoPequenoService
	{
		ResultApi RegistrarGp(GrupoPequeno Gp);
		ResultApi AsignarLiderGp(AsignarLiderGpDto dto);
		ResultApi RemoveLider(int IdLider, int IdGp);
		ResultApi AsignarMentor(AsignarMentorDto dto);
		ResultApi EliminarGp(int Id);
		ResultApi DesAsignarMentor(int IdMentor, int IdGp);
		ResultApi RegistrarMiembro(int IdGp, AsignarMiembroDto dto);
		ResultApi ConsultarGp();


    }
}

