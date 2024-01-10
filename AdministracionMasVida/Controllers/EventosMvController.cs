using System.Diagnostics.Eventing.Reader;
using AdministracionMasVida.Entities;
using AdministracionMasVida.Models;
using AdministracionMasVida.Services;
using AdministracionMasVida.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionMasVida.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventosMvController : Controller
    {
        private readonly IEventosMvService _IEventosMvService;
        public EventosMvController(IEventosMvService EventosMvService)
        {
            this._IEventosMvService = EventosMvService;
        }
        [HttpPost]
        [Route("RegistrarEvento")]
        public ActionResult RegistrarEvento(EventosMv Evento)
        {
            var result = _IEventosMvService.RegistrarEvento(Evento);
            return StatusCode(result.StatusCode, result);
        }
        [HttpGet("ConsultarEvento")]
        public ActionResult Get(int ID)
        {
            var result = _IEventosMvService.Get(ID);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete("EliminarEvento")]
        public ActionResult EliminarEvento(int Id)
        {
            var result = _IEventosMvService.EliminarEvento(Id);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut("ModificaEvento")]
        public ActionResult ModificarEvento(EventosMv Evento)
        {
            var result = _IEventosMvService.ModificarEvento(Evento);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut("AsignarLugar")]
        public ActionResult AsignarLugar(AsiganarLugarDto dto) 
        {
            var result = _IEventosMvService.AsignarLugar(dto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut("AsignarGp")]
        public ActionResult AsignarGp(AsignarGpDto dto) 
        {
            var result = _IEventosMvService.AsignarGp(dto);
            return StatusCode(result.StatusCode, result);
        }
    }
}
