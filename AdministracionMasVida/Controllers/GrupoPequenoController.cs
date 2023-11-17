using System;
using AdministracionMasVidaDbContext.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionMasVidaDbContext.Controllers
{
	public class GrupoPequenoController : Controller
	{
        private readonly IGrupoPequenoService _GrupoPequenoService;
        public GrupoPequenoController(IGrupoPequenoService GrupoPequenoService)
        {
            this._GrupoPequenoService = GrupoPequenoService;
        }
    }
}

