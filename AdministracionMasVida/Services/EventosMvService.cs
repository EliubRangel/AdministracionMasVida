using System.Security.Cryptography.X509Certificates;
using AdministracionMasVida.Entities;
using AdministracionMasVida.Models;
using AdministracionMasVida.Services.Interfaces;
using AdministracionMasVidaDbContext.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionMasVida.Services
{

    public class EventosMvService:IEventosMvService
    {

        private readonly AdministracionMasVidaDbcontext dbContext;

        public EventosMvService(AdministracionMasVidaDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ResultApi RegistrarEvento(EventosMv Evento)
        {

            ResultApi result = new ResultApi();
            dbContext.EventosMv.Add(Evento);
            dbContext.SaveChanges();
            result.IsError = false;
            result.Data = Evento;
            result.Message = "Ok";
            result.StatusCode = 200;
            return result;

        }
        public ResultApi Get(int ID)
        {
            ResultApi result = new ResultApi();
            var Evento = dbContext.EventosMv
                .FirstOrDefault(x=>x.Id== ID);
            if (Evento == null) 
            {
                result.IsError = true;
                result.Message=$"No se encontro evento con el Id {ID}";
                result.Data = Evento;
                result.StatusCode = 404;
                return result;
            }
            result.IsError= false;
            result.Data = Evento;
            result.Message = "Ok";
            result.StatusCode=200;
            return result;
        }
        public ResultApi EliminarEvento(int Id)
        {
            ResultApi result = new ResultApi();
            var Evento = dbContext.EventosMv
                .FirstOrDefault (x=>x.Id== Id); 
            if(Evento == null) 
            {
            result.IsError = true;
                result.Message=$"No se encontro evento cone el Id {Id}";
                result.Data = Evento;
                result.StatusCode = 404;
                return result;
            }
            dbContext.Remove(Evento);
            dbContext.SaveChanges();
            result.IsError = false;
            result.Data = Evento;
            result.Message = "Ok";
            result.StatusCode=200;
            return result;
        }
        public ResultApi ModificarEvento (EventosMv Evento) 
        {
            ResultApi result = new ResultApi();
            var evento = dbContext.EventosMv
                .FirstOrDefault(x=>x.Id== Evento.Id);
            if(evento == null) 
            {
                result.IsError = true;
                result.Message=$"No se encontro evento con el Id {Evento.Id}";
                result.Data = evento;
                result.StatusCode = 404;
                return result;
            }
            else
            {
                Evento.Nombre = evento.Nombre;
                Evento.Descripcion = evento.Descripcion;
                Evento.Lugar = evento.Lugar;
                dbContext.Update(evento);
                dbContext.SaveChanges();
                result.IsError = false;
                result.Data = evento;
                result.Message = "ok";
                result.StatusCode=200;
                return result;
            }
            
        }
        public ResultApi AsignarLugar (AsiganarLugarDto dto)
        {
            ResultApi result = new ResultApi ();
            var Lugar = dbContext.LugaresMv
                .Include(x => x.Evento)
                .FirstOrDefault(x => x.Id == dto.IdLugar);
            if (Lugar == null) 
            {
                result.IsError = true;
                result.Message = $"No se encontro lugar con el id {dto.IdLugar}";
                result.StatusCode = 404;
                return result;
            }
            var Evento= dbContext.EventosMv
                .Include(x => x.Lugar)
                .FirstOrDefault(x=>x.Id == dto.IdEvento);
            if (Evento == null)
            {
                result.IsError = true;
                result.Message = $"No se encontro evento con el Id {dto.IdEvento}";
                result.StatusCode = 404;
                return result;
            }
            if(Lugar.Evento.Any(x=> x.Fecha == Evento.Fecha ))
            {
                result.IsError= true;
                result.Message = "El lugar ya esta reservado para esa fecha";
                result.StatusCode = 404;
                return result;
            }
            dbContext.Update(Lugar);
            dbContext.SaveChanges();
            result.IsError = false;
            result.Message = "ok";
            result.StatusCode= 200;
            return result;

    
        }
        public ResultApi AsignarGp (AsignarGpDto dto)
        {
          ResultApi result = new ResultApi();
            var Gp = dbContext.GrupoPequeno
                .Include(x=> x.eventosMv)
                .FirstOrDefault(x=> x.Id == dto.IdGp);
            if(Gp == null) 
            {
                result.IsError = true;
                result.StatusCode = 404;
                result.Data = Gp;
                result.Message =$"No se encontro grupo con el Id{dto.IdGp}";
                return result;
            }
            var Evento = dbContext.EventosMv
                .Include(x=> x.Gp)
                .FirstOrDefault(x => x.Id == dto.IdEvento);
            if(Evento == null) 
            {
                result.IsError = true;
                result.Data = Evento;
                result.StatusCode = 404;
                result.Message = $"No se encontro evento con el Id {dto.IdEvento}";
                return result;
            }
            if(Gp.eventosMv.Any(x=> x.Gp == Evento.Gp)) 
            {
                result.IsError = true;
                result.Message = "Este evento ya cuenta con grupo";
                result.Data= Evento;
                result.StatusCode = 404;
                return result;
            }
            dbContext.Update(Gp);
            dbContext.SaveChanges();
            result.IsError = false;
            result.Message = "ok";
            result.StatusCode = 200;
            return result;
        }
    }
}
