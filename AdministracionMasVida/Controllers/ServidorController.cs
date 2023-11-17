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
        public ActionResult Get ()
        {
            var result = _servidorService.Get();
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut]
        public ActionResult ActualizarServidor(Servidor servidor)
        {
            var result = _servidorService.ActualizarServidor(servidor);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete]
        public ActionResult EliminarServidor(int Id)
        {
            var result = _servidorService.EliminarServidor(Id);
            return StatusCode(result.StatusCode, result);

        }


       
        
	}
}

