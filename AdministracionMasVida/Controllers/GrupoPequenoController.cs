using System;
using AdministracionMasVida.Models;
using AdministracionMasVidaDbContext.Entities;
using AdministracionMasVidaDbContext.Services;
using AdministracionMasVidaDbContext.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionMasVidaDbContext.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrupoPequenoController : Controller
	{
        private readonly IGrupoPequenoService _GrupoPequenoService;
        public GrupoPequenoController(IGrupoPequenoService GrupoPequenoService)
        {
            this._GrupoPequenoService = GrupoPequenoService;
        }

        [HttpPost]
        public ActionResult RegistrarGp(GrupoPequeno Gp)
        {
            var result = _GrupoPequenoService.RegistrarGp(Gp);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPost]
        [Route("AsignarLider")]
        public ActionResult AsignarLiderGp(AsignarLiderGpDto dto)
        {
            var result = _GrupoPequenoService.AsignarLiderGp(dto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete]

        public ActionResult RemoveLider(int IdLider)
        {
            var result = _GrupoPequenoService.RemoveLider(IdLider);
            return StatusCode(result.StatusCode, result);
        }
    }
}

