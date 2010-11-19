using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifebyteMVC.Core
{
    public class ScheduleType
    {
        
        public virtual int Id { get; set; }

        /// <summary>
        /// This is either pickup or delivery
        /// </summary>
        public virtual string FullName { get; set; } 

        /// <summary>
        /// A list of recipients with a given status.
        /// </summary>
        public virtual IList<Recipient> Recipients { get; set; }

        public ScheduleType()
        {
            Recipients = new List<Recipient>();
        }
    }
}
