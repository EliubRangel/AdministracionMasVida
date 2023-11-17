using System;
using AdministracionMasVida.Models;
using AdministracionMasVidaDbContext.Entities;

namespace AdministracionMasVidaDbContext.Services.Interfaces
{
	public interface IGrupoPequenoService
	{
		ResultApi RegistrarGp(GrupoPequeno Gp);

    }
}

