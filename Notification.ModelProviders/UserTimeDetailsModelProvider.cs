using Notification.Entity;
using Notification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.ModelProviders
{
    public class UserTimeDetailsModelProvider
    {
        public UserTimeDetailsModelProvider()
        {

        }

        public IEnumerable<UserTimeDetailsModel> ReadAll()
        {
            using(var context = new NotificationContext())
            {
                IEnumerable<UserTimeDetails> userTimeDetailsList = context.UserTimeDetails;

                return userTimeDetailsList.Select(x => this.PopulateModel(x)).ToList();
            }
            
        }

        private UserTimeDetailsModel PopulateModel(UserTimeDetails userTimeDetails)
        {
            return new UserTimeDetailsModel()
            {
                LastActiveTime = userTimeDetails.LastActiveTime,
                Name = userTimeDetails.Name,
                UserId = userTimeDetails.UserId,
                LoggedInTime = userTimeDetails.LoggedInTime
            };
        }

        public void Write(UserTimeDetailsModel userTimeDetailsModel)
        {
            using(var context = new NotificationContext())
            {
                UserTimeDetails userTimeDetails = context.UserTimeDetails.Where(x => x.UserId == userTimeDetailsModel.UserId).SingleOrDefault();
                UserTimeDetails newUserTimeDetails = new UserTimeDetails();

                if (userTimeDetails == null)
                    context.UserTimeDetails.Add(newUserTimeDetails);

                this.UpdateEntity(userTimeDetails ?? newUserTimeDetails, userTimeDetailsModel);
                context.SaveChanges();
            }
        }

        private void UpdateEntity(UserTimeDetails userTimeDetails, UserTimeDetailsModel userTimeDetailsModel)
        {
            userTimeDetails.UserId = userTimeDetailsModel.UserId;
            userTimeDetails.Name = userTimeDetailsModel.Name;
            userTimeDetails.LastActiveTime = userTimeDetailsModel.LastActiveTime.Year < DateTime.Now.Year ? DateTime.Now : userTimeDetailsModel.LastActiveTime;
            userTimeDetails.LoggedInTime = userTimeDetailsModel.LoggedInTime.Year < DateTime.Now.Year ? DateTime.Now : userTimeDetailsModel.LoggedInTime;
        }

        public void UpdateExisting(Guid UserId)
        {
            using (var context = new NotificationContext())
            {
                UserTimeDetails userTimeDetails = context.UserTimeDetails.Where(x => x.UserId == UserId).SingleOrDefault();

                if (userTimeDetails == null)
                    return;

                userTimeDetails.LastActiveTime = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}