using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ChatBot.Startup))]

namespace ChatBot
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 如需如何設定應用程式的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkID=316888
            var config =
                            //app.MapSignalR();
                            app.Map("/SignalR", map =>
                            {
                                map.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
                                var hubConfiguration = new HubConfiguration
                                {
                                    EnableJSONP = true,
                                    EnableDetailedErrors = true
                                };
                                map.RunSignalR(hubConfiguration);
                            });
        }
    }
}
