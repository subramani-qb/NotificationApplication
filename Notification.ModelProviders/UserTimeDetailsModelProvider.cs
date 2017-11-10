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

                return userTimeDetailsList.Select(x => this.PopulateModel(x));
            }
            
        }

        private UserTimeDetailsModel PopulateModel(UserTimeDetails userTimeDetails)
        {
            return new UserTimeDetailsModel()
            {
                LastActiveTime = userTimeDetails.LastActiveTime,
                Name = userTimeDetails.Name,
                UserId = userTimeDetails.UserId
            };
        }

        public void Write(UserTimeDetailsModel userTimeDetailsModel)
        {
            using(var context = new NotificationContext())
            {
                UserTimeDetails userTimeDetails = new UserTimeDetails()
                {
                    Name = userTimeDetailsModel.Name,
                    LastActiveTime = DateTime.Now,
                    UserId = Guid.NewGuid()
                };

                context.UserTimeDetails.Add(userTimeDetails);
                context.SaveChanges();
            }
        }

        public void UpdateExisting(UserTimeDetailsModel userTimeDetailsModel)
        {
            using (var context = new NotificationContext())
            {
                UserTimeDetails userTimeDetails = context.UserTimeDetails.Where(x => x.UserId == userTimeDetailsModel.UserId).SingleOrDefault();

                if (userTimeDetails == null)
                    return;

                userTimeDetails.LastActiveTime = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}