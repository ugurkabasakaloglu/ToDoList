using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IAUToDoList.Startup))]
namespace IAUToDoList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
