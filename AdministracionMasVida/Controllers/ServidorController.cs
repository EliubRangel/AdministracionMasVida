using System;
using AdministracionMasVidaDbContext.Entities;
using AdministracionMasVidaDbContext.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionMasVidaDbContext.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServidorController : Controller
    {
        private readonly IServidorService _servidorService;
        public ServidorController(IServidorService servidorService)
        {
            this._servidorService = servidorService;
        }
        [HttpPost]
        public ActionResult NewServidor (Servidor servidor )
        {
            var result = _servidorService.NewServidor(servidor);
            return StatusCode(result.StatusCode, result);
        }
        [HttpGet]
        public ActionResult ServidorId(int id) 
        {
            var result = _servidorService.ConsultarServidor(id);
            return StatusCode(result.StatusCode, result);
        }
      
        [HttpPut("actualizar")]
        public ActionResult ActualizarServidor(Servidor servidor)
        {
            var result = _servidorService.ActualizarServidor(servidor);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete("eliminar")]
        public ActionResult EliminarServidor(int Id)
        {
            var result = _servidorService.EliminarServidor(Id);
            return StatusCode(result.StatusCode, result);

        }
        [HttpGet("consulta")]
        public ActionResult ConsultarServidores()
        {
            var result = _servidorService.ConsultarServidores();
            return StatusCode(result.StatusCode, result);
        }




    }
}

