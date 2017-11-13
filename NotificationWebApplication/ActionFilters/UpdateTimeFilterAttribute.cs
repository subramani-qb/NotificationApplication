using Notification.ModelProviders;
using NotificationWebApplication.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotificationWebApplication.ActionFilters
{
    public class UpdateTimeFilterAttribute : ActionFilterAttribute
    {
        UserTimeDetailsModelProvider provider = new UserTimeDetailsModelProvider();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            provider.UpdateExisting(Guid.Parse(filterContext.HttpContext.Session["LoggedInUserId"].ToString()));

            //UserListHub userListHub = new UserListHub();
            //userListHub.UpdateUserList();
        }
    }
}