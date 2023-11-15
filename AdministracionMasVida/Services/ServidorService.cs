using System;
using AdministracionMasVida.Models;
using AdministracionMasVidaDbContext.DbContexts;
using AdministracionMasVidaDbContext.Entities;
using AdministracionMasVidaDbContext.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdministracionMasVidaDbContext.Services
{
	public class ServidorService : IServidorService
	{
        private readonly AdministracionMasVidaDbcontext dbContext;

        public ServidorService(AdministracionMasVidaDbcontext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public ResultApi NewServidor(Servidor servidor)
        {
            ResultApi result = new ResultApi();
            dbContext.Servidor.Add(servidor);
            dbContext.SaveChanges();
            result.Message = "Se agrego correctamente el servidor";
            result.Data = servidor;
            result.StatusCode = 200;
            return result;
        }

        public ResultApi Get()
        {
            ResultApi result = new ResultApi();
            var Servidor = dbContext.Servidor.ToList();
            result.Data = Servidor;
            result.Message = "Ok";
            result.StatusCode = 200;
            return result;
        }
    }
}

