using AdministracionMasVida.Services.Interfaces;
using AdministracionMasVidaDbContext.DbContexts;

namespace AdministracionMasVida.Services
{

    public class EventosMvService:IEventosMvService
    {

        private readonly AdministracionMasVidaDbcontext dbContext;

        public EventosMvService(AdministracionMasVidaDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }


    }
}
