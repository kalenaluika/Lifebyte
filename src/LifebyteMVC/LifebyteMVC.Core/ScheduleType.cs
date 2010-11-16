using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifebyteMVC.Core
{
    public class ScheduleType
    {
        
        public virtual int ID { get; set; }

        /// <summary>
        /// This is either pickup or delivery
        /// </summary>
        public virtual string FullName { get; set; } 
    }
}
