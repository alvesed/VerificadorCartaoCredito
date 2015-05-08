using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VerificadorCartaoCredito.Startup))]
namespace VerificadorCartaoCredito
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
