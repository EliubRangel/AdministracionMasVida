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
			result.Message = "Se creo exitosamente el Grupo pequeno";
			result.Data = Gp;
			result.StatusCode = 200;
			return result;
		}
		public ResultApi AsignarLiderGp(AsignarLiderGpDto dto)
		{
			ResultApi result = new ResultApi();
			var Lider = dbContext.Servidor.FirstOrDefault(x => x.Id == dto.IdLider);
			if(Lider==null)
			{
				result.Message = $"No se encontro el servidor con el Id {dto.IdLider}";
				result.IsError = true;
				result.StatusCode = 404;
				return result;
			}
			var Gp = dbContext.GrupoPequeno.FirstOrDefault(x => x.Id == dto.IdGrupoPequeno);
			if(Gp==null)
			{
				result.Message = $"No se encontro grupo pequeno con el Id {dto.IdGrupoPequeno}";
				result.IsError = true;
				result.StatusCode = 404;
				return result;
			}
			result.Message = $"Se asigno correctamente el lider {dto.IdLider} al grupo {dto.IdGrupoPequeno}";
			result.StatusCode = 200;
			return result;
		}
		public ResultApi RemoveLider(int IdLider)
		{
			ResultApi result = new ResultApi();
			var Lider = dbContext.Servidor.FirstOrDefault(x => x.Id == IdLider);
			if(Lider== null)
			{
				result.Message = $"No se encontro lider con el Id {IdLider}";
				result.IsError = true;
				result.StatusCode = 404;
				return result;
			}
			dbContext.Remove(Lider);
			dbContext.SaveChanges();
			result.Message = $"Se quito lider con el Id {Lider.Id} correctamente";
			result.Data = Lider;
			result.StatusCode = 200;
			return result;

		}
	}
}

