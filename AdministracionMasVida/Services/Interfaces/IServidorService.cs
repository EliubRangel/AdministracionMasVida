using System;
using AdministracionMasVida.Models;
using AdministracionMasVidaDbContext.Entities;

namespace AdministracionMasVidaDbContext.Services.Interfaces
{
	public interface IServidorService
	{
		ResultApi NewServidor(Servidor servidor);
		ResultApi Get();
		ResultApi ActualizarServidor(Servidor servidor);
		ResultApi EliminarServidor(int Id);
	}
}

