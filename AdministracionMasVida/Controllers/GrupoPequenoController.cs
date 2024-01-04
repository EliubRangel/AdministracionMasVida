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
        [Route("EliminarLider")]

        public ActionResult RemoveLider( int IdLider, int IdGp)
        {
            var result = _GrupoPequenoService.RemoveLider(IdLider, IdGp);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPost]
        [Route("AsignarMentor")]
        public ActionResult AsignarMentor(AsignarMentorDto dto)
        {
            var result = _GrupoPequenoService.AsignarMentor(dto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete]
        [Route("EliminarGp")]
        public ActionResult EliminarGp(int Id)
        {
            var result = _GrupoPequenoService.EliminarGp(Id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete]
        [Route("RemoveMentor")]
        public ActionResult DesAsignarMentor(int IdMentor, int IdGp)
        {
            var result = _GrupoPequenoService.DesAsignarMentor(IdMentor, IdGp);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPost]
        [Route("RegistrarMiembro")]
        public ActionResult RegistrarMiembro([FromQuery]int IdGp,[FromBody] AsignarMiembroDto dto)
        {
            var result = _GrupoPequenoService.RegistrarMiembro(IdGp, dto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpGet]
        [Route("ConsultarGp")]
        public ActionResult ConsultarGp()
        {
            var result =_GrupoPequenoService.ConsultarGp();
            return StatusCode(result.StatusCode, result);
        }

    }
}

