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
    }
}
