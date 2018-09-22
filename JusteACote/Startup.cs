using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JusteACote.Startup))]
namespace JusteACote
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
