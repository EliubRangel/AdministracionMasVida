using System;
using AdministracionMasVida.Models;
using AdministracionMasVidaDbContext.DbContexts;
using AdministracionMasVidaDbContext.Entities;
using AdministracionMasVidaDbContext.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
			var Gp = dbContext.GrupoPequeno
				.Include(x=>x.Lideres)
				.FirstOrDefault(x => x.Id == dto.IdGrupoPequeno);

			if (Gp==null)
			{
				result.Message = $"No se encontro grupo pequeno con el Id {dto.IdGrupoPequeno}";
				result.IsError = true;
				result.StatusCode = 404;
				return result;
			}
			if(Gp.Lideres.Count < 2)
			{
				Gp.Lideres.Add(Lider);
				dbContext.SaveChanges();
			}
			else
			{
				result.Message = $"El lider con el ID {dto.IdLider} ya cuenta con mas de 2 grupos";
				result.IsError = true;
				result.StatusCode = 400;
				return result;
			}

			result.Message = $"Se asigno correctamente el lider {dto.IdLider} al grupo {dto.IdGrupoPequeno}";
			result.StatusCode = 200;
			return result;
		}
		public ResultApi RemoveLider(int IdLider, int IdGp)
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
			var Gp = dbContext.GrupoPequeno
				.Include(x=>x.Lideres)
				.FirstOrDefault(x => x.Id == IdGp);
			if(Gp==null)
			{
				result.Message = $"No se encontro grupo pequeno con el Id {IdGp}";
				result.IsError = true;
				result.StatusCode = 404;
				return result;
			}

			if (!Gp.Lideres.Any(x => IdLider == x.Id))
			{
                result.Message = $"El servidor {IdLider} no es lider del grupo {IdGp}";
                result.IsError = true;
                result.StatusCode = 400;
                return result;
            }
			else
			{
                Gp.Lideres.Remove(Lider);
                dbContext.SaveChanges();
            }

			result.Message = "ok";
            result.Message = $"Se quito lider {IdLider} del grupo pequeño ";
            result.IsError = false;
            result.StatusCode = 200;
            return result;





        }
	}
}

