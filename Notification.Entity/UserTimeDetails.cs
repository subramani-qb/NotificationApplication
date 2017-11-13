using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Entity
{
    [Table("User_Time_Details")]
    public class UserTimeDetails
    {
        [Key]
        [Column("user_id", TypeName = "UNIQUEIDENTIFIER")]
        public Guid UserId { get; set; }

        [Column("name",TypeName = "NVARCHAR")]
        public string Name { get; set; }

        [Column("last_active_time", TypeName = "DATETIME")]
        public DateTime LastActiveTime { get; set; }

        [Column("logged_in_time", TypeName ="DATETIME")]
        public DateTime LoggedInTime { get; set; }
    }
}
