using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRDemo.SignalR
{

    public static class Notifier
    {
        private static readonly IHubContext Context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();

        public static void ServerSend2ClientMethod(string connectionId, string message)
        {
            //注册后端与前端的方法serverSend2Client。connectionId是判断发送给哪个前端
            Context.Clients.Client(connectionId).serverSend2Client(message);
        }

    }


    [HubName("myHub")]
    public class MyHub : Hub
    {

        //客户端发送信息到服务器
        public void Send(string message)
        {
        }


        //当连接hub实例时被调用
        public override Task OnConnected()
        {
            string connId = Context.ConnectionId;
            return base.OnConnected();
        }

        //当失去连接或链接超时时被调用
        public override Task OnDisconnected(bool stopCalled)
        {
            //stopCalled=true时，客户端关闭连接
            //stopCalled=false时，出现链接超时
           return base.OnDisconnected(stopCalled);
        }

        //重新连接时被调用
        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }


    }
}