using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Entity
{
    public partial class NotificationContext : DbContext
    {
        public NotificationContext() 
            : base("data source=DESKTOP-6DNTMS0\\SQLSERVER2012; initial catalog=NotificationDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {

        }

        public virtual DbSet<UserTimeDetails> UserTimeDetails { get; set; }
    }
}
