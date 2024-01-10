using AdministracionMasVida.Entities;
using AdministracionMasVida.Models;
using Microsoft.EntityFrameworkCore;
using AdministracionMasVidaDbContext.DbContexts;
using AdministracionMasVidaDbContext.Services.Interfaces;
using AdministracionMasVida.Services.Interfaces;

namespace AdministracionMasVida.Services
{
    public class lugaresMvService :ILugaresMvService
    {
        private readonly AdministracionMasVidaDbcontext dbContext;

        public lugaresMvService(AdministracionMasVidaDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
         public ResultApi RegistrarLugar(LugaresMv Lugar)
        {
            ResultApi result = new ResultApi();
            dbContext.LugaresMv.Add(Lugar);
            dbContext.SaveChanges();
            result.IsError = false;
            result.Data = Lugar;
            result.Message = "Ok";
            result.StatusCode = 200;
            return result;
            
        }
        public ResultApi Get (int Id)
        {
            ResultApi result = new ResultApi();
            var Lugar = dbContext.LugaresMv
                .FirstOrDefault(x => x.Id == Id);
                if (Lugar == null) 
            {
                result.IsError = true;
                result.Data = Lugar;
                result.Message = $"No se encontro el lugar con el Id {Id}";
                result.StatusCode = 404;
            }
                result.IsError= false;
            result.Data = Lugar;
            result.Message="Ok";
            result.StatusCode = 200;    
            return result;
        }
        public ResultApi EliminarLugar(int Id) 
        {
            ResultApi result = new ResultApi();
            var Lugar = dbContext.LugaresMv
                .FirstOrDefault(x=>x.Id == Id);
           if(Lugar == null) 
            {
                result.IsError = true;
                result.Data = Lugar;
                result.Message = $"No se encontro lugar con el Id {Id}";
                result.StatusCode = 404;
                return result;
            }
            dbContext.Remove(Lugar);
            dbContext.SaveChanges();
            result.IsError = false;
            result.Data = Lugar;
            result.StatusCode=200;
            result.Message = "Ok";
            return result;
        }
        public ResultApi ModificarLugar(LugaresMv Lugar)
        {
            ResultApi result = new ResultApi();
            var lugar = dbContext.LugaresMv
                .FirstOrDefault(x=> x.Id == Lugar.Id);
            if(lugar == null) 
            {
                result.IsError = true;
                result.Data = Lugar;
                result.Message = $"No se encontro el lugar con el Id {lugar.Id}";
                result.StatusCode = 404;
                return result;
            }
            else
            {
                lugar.Descripcion = Lugar.Descripcion;
                lugar.Direccion = Lugar.Direccion;
                lugar.Precio= Lugar.Precio;
                dbContext.Update(lugar);
                dbContext.SaveChanges() ;
                result.IsError = false;
                result.Data = lugar;
                result.StatusCode=200;
                result.Message = "Ok";
                return result;
            }
        }
    }
}
