using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRMVC3Test
{
    public class AuthenticationHubPipelineModule : HubPipelineModule
    {
        protected override bool OnBeforeIncoming(IHubIncomingInvokerContext context)
        {
            var id = HttpContext.Current.User.Identity.IsAuthenticated
                ? "fred"
                : string.Empty;

            context.Hub.Groups.Add(context.Hub.Context.ConnectionId, id);

            return base.OnBeforeIncoming(context);
        }
    }
}