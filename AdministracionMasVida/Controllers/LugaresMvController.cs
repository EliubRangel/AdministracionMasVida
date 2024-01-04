using AdministracionMasVida.Entities;
using AdministracionMasVida.Models;
using AdministracionMasVidaDbContext.Services;
using AdministracionMasVida.Services.Interfaces;
using AdministracionMasVidaDbContext.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionMasVida.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LugaresMvController : Controller
    {
        private readonly ILugaresMvService _ILugaresMvService;
        public LugaresMvController(ILugaresMvService LugaresMvService)
        {
            this._ILugaresMvService = LugaresMvService;
        }


        [HttpPost]
        [Route("RegistrarLugar")]
        public ActionResult RegistrarLugar(LugaresMv Lugares)
        {
            var result = _ILugaresMvService.RegistrarLugar(Lugares);
            return StatusCode(result.StatusCode, result);
        }
        [HttpGet("consultar")]
        public ActionResult Get (int Id)
        {
            var result =_ILugaresMvService.Get(Id);
            return StatusCode(result.StatusCode, result);
        }


    }
}
