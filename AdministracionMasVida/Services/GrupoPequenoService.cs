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

		public ResultApi RegistrarGp(GrupoPequeno Gp)
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
			if (Lider == null)
			{
				result.Message = $"No se encontro el servidor con el Id {dto.IdLider}";
				result.IsError = true;
				result.StatusCode = 404;
				return result;
			}
			var Gp = dbContext.GrupoPequeno
				.Include(x => x.Lideres)
				.FirstOrDefault(x => x.Id == dto.IdGrupoPequeno);

			if (Gp == null)
			{
				result.Message = $"No se encontro grupo pequeno con el Id {dto.IdGrupoPequeno}";
				result.IsError = true;
				result.StatusCode = 404;
				return result;
			}
			if (Gp.Lideres.Count < 2)
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
			if (Lider == null)
			{
				result.Message = $"No se encontro lider con el Id {IdLider}";
				result.IsError = true;
				result.StatusCode = 404;
				return result;
			}
			var Gp = dbContext.GrupoPequeno
				.Include(x => x.Lideres)
				.FirstOrDefault(x => x.Id == IdGp);
			if (Gp == null)
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
		public ResultApi AsignarMentor(AsignarMentorDto dto)
		{
			ResultApi result = new ResultApi();
			var Mentor = dbContext.Servidor
				.Include(x => x.MentorGrupos)
				.FirstOrDefault(x => x.Id == dto.IdMentor);
			if (Mentor == null)
			{
				result.Message = $"No se encontro el mentor con el Id {dto.IdMentor}";
				result.IsError = true;
				result.StatusCode = 404;
				return result;
			}
			var Gp = dbContext.GrupoPequeno
				.Include(x => x.Mentor)
				.FirstOrDefault(x => x.Id == dto.IdGp);
			if (Gp == null)
			{
				result.Message = $"No se encontro grupo pequeno con el Id {dto.IdGp}";
				result.IsError = true;
				result.StatusCode = 404;
				return result;
			}


			if (Mentor.MentorGrupos.Any(x => x.HoraInicio == Gp.HoraInicio && x.Dia == Gp.Dia))
			{
				result.Message = $"El mentor {dto.IdMentor} no esta disponible";
				result.IsError = true;
				result.StatusCode = 404;
				return result;
			}
			if(Gp.Mentor!=null)
			{
				result.Message = $"No se puede asignar mentor por que este grupo ya tiene";
				result.IsError = true;
				result.StatusCode = 404;
				return result;
			}
			if (Mentor.MentorGrupos.Count < 6)
			{
				Mentor.MentorGrupos.Add(Gp);
				dbContext.SaveChanges();
			}

			result.Message = $" Se asigno el mentor {dto.IdMentor} al grupo {dto.IdGp}";
			result.IsError = false;
			result.StatusCode = 200;
			return result;
		}

		public ResultApi EliminarGp(int Id)
		{
			ResultApi result = new ResultApi();
			var Gp = dbContext.GrupoPequeno
				.FirstOrDefault(x => x.Id == Id);
			if (Gp == null)
			{
				result.Message = $"No se encontro gp con el id {Id}";
				result.IsError = true;
				result.StatusCode = 404;
				return result;
			}
			dbContext.Remove(Gp);
			dbContext.SaveChanges();
			result.Message = $"Se elimino gp con el id {Id}";
			result.IsError = false;
			result.StatusCode = 200;
			return result;

		}
		public ResultApi DesAsignarMentor(int IdMentor , int IdGp)
		{
			ResultApi result = new ResultApi();
			var Mentor = dbContext.Servidor
				.FirstOrDefault(x => x.Id == IdMentor);
            if (Mentor == null)
            {
                result.Message = $"No se encontro mentor con el Id {IdMentor}";
                result.IsError = true;
                result.StatusCode = 404;
                return result;
            }
			var Gp = dbContext.GrupoPequeno
				.Include(x=> x.Mentor)
				.FirstOrDefault(x => x.Id == IdGp);
			if(Gp==null)
			{
				result.Message = $"No se encontro grupo con el id {IdGp}";
				result.IsError = true;
				result.StatusCode = 404;
				return result;
			}
			if (Gp.Mentor.Id!= IdMentor)
			{
				result.Message = $"El servidor {IdMentor} no es el mentor de este grupo";
				result.IsError = true;
				result.StatusCode = 404;
				return result;
			}
			else
			{
				Gp.Mentor = null;
				dbContext.SaveChanges();
			}
			result.Message = $"Se quito mentor {IdMentor} exitosamente";
			result.IsError = false;
			result.StatusCode = 200;
			return result;
        }
	}
}

