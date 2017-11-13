using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Models
{
    public class UserTimeDetailsModel
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }
        
        public DateTime LastActiveTime { get; set; }

        public DateTime LoggedInTime { get; set; }
    }
}
