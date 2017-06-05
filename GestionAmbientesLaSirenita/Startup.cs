using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionAmbientesLaSirenita.Startup))]
namespace GestionAmbientesLaSirenita
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
