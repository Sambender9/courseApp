using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourseApp.Web.Startup))]
namespace CourseApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
