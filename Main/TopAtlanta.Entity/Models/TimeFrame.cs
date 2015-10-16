using System;
using System.Collections.Generic;

namespace TopAtlanta.Entities.Models
{
    public partial class TimeFrame
    {
        public TimeFrame()
        {
            this.Accounts = new List<Account>();
        }

        public int TimeFrameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public System.DateTimeOffset CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTimeOffset> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
