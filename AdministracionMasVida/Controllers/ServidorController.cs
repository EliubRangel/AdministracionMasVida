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

       
        
	}
}

