using System;
using AdministracionMasVida.Models;
using AdministracionMasVidaDbContext.DbContexts;
using AdministracionMasVidaDbContext.Entities;
using AdministracionMasVidaDbContext.Services.Interfaces;

namespace AdministracionMasVidaDbContext.Services
{
	public class GrupoPequenoService : IGrupoPequenoService
    {
		private readonly AdministracionMasVidaDbcontext dbContext;

		public GrupoPequenoService(AdministracionMasVidaDbcontext dbContext)
		{
			this.dbContext = dbContext;
		}

		public ResultApi RegistrarGp (GrupoPequeno Gp)
		{
			ResultApi result = new ResultApi();
			dbContext.GrupoPequeno.Add(Gp);
			dbContext.SaveChanges();
			result.Message = "Se creo exitosamente el Grupo pequno";
			result.Data = Gp;
			result.StatusCode = 200;
			return result;
		}
	}
}

