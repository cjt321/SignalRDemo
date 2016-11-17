using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalRDemo.SignalR.StartupSignalR))]

namespace SignalRDemo.SignalR
{
    public class StartupSignalR
    {
        public void Configuration(IAppBuilder app)
        {
            #region Redis配置
            //添加redis
            RedisScaleoutConfiguration redisScaleoutConfiguration = new RedisScaleoutConfiguration("ceswebnew.redis.cache.chinacloudapi.cn", 6379, "XXXXXXXXXXXXXXXXXXXXXXXXXX/YKo=", "__redis_signalr");
            //连接DB，默认为0
            redisScaleoutConfiguration.Database = 3;
            //SignalR用Redis
            GlobalHost.DependencyResolver.UseRedis(redisScaleoutConfiguration);
            #endregion

            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            app.MapSignalR();//启动SignalR
        }
    }
}
