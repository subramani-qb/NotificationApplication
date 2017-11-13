using Notification.ModelProviders;
using Notification.Models;
using NotificationWebApplication.Hubs;
using NotificationWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotificationWebApplication.Controllers
{
    public class ActiveUsersController : Controller
    {
        UserTimeDetailsModelProvider modelProvider = new UserTimeDetailsModelProvider();

        // GET: ActiveUsers
        public ActionResult UserList()
        {            
            IEnumerable<UserTimeDetailsModel> userDetailsList = modelProvider.ReadAll();
            IEnumerable<UserTimeDetailsModel> activeList = userDetailsList.Where(x => (DateTime.Now - x.LastActiveTime).Minutes < 1 && (x.LastActiveTime - x.LoggedInTime).Minutes < 10);
            IEnumerable<UserTimeDetailsModel> inActiveList = userDetailsList.Except(activeList);
            var usersList = new Tuple<IEnumerable<UserTimeDetailsModel>, IEnumerable<UserTimeDetailsModel>>(activeList, inActiveList);

            return View(usersList);
        }

        public ActionResult AddUser(LoginViewModel loginViewModel)
        {
            if (loginViewModel.Email != null)
            {
                UserTimeDetailsModel userTimeDetailsModel = new UserTimeDetailsModel()
                {
                    Name = loginViewModel.Email,
                    UserId = Guid.Parse(Session["LoggedInUserId"].ToString())
                };
                modelProvider.Write(userTimeDetailsModel);
            }

            //UserListHub userListHub = new UserListHub();
            //userListHub.UpdateUserList();

            return RedirectToAction("UserList");
        }
    }
}