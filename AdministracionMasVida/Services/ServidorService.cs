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

        public ResultApi ActualizarServidor(Servidor servidor)
        {
            ResultApi result = new ResultApi();
            var servi = dbContext.Servidor.FirstOrDefault(x => x.Id == servidor.Id);
            if (servi == null)
            {
                result.Message = $"No se encontro el servidor con el Id {servidor.Id}";
                result.IsError = true;
                result.StatusCode = 404;
                return result;
            }
            else
            {
                servi.Nombre = servidor.Nombre;
                servi.Apellido = servidor.Apellido;
                servi.Direccion = servidor.Direccion;
                servi.Correo = servidor.Correo;
                servi.Telefono = servidor.Telefono;
                servi.LiderGrupo = servidor.LiderGrupo;
                servi.MentorGrupos = servidor.MentorGrupos;

                dbContext.Update(servi);
                dbContext.SaveChanges();
                result.Data = servi;
                result.Message = $"Se modifico correctamente el servidor con el id {servi.Id}";
                result.StatusCode = 200;
                return result;

            }
            
        }
        public ResultApi EliminarServidor(int Id)
        {
            ResultApi result = new ResultApi();
            var servidor = dbContext.Servidor.FirstOrDefault(x => x.Id == Id);
            if (Id== null)
            {
                result.Message = $"No se encontro sservidor con el Id {servidor.Id}";
                result.IsError = true;
                result.StatusCode= 404;
                return result;
            }
            dbContext.Remove(servidor);
            dbContext.SaveChanges();
            result.Message = $"Se elimino el servidor con el id {servidor.Id}";
            result.StatusCode = 200;
            result.Data = servidor;
            return result;
        }
    }
}

