using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LinhDGT_Electronic.Startup))]
namespace LinhDGT_Electronic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
