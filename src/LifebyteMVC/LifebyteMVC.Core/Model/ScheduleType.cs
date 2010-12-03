using System.Collections.Generic;
using LifebyteMVC.Core.Interfaces;

namespace LifebyteMVC.Core.Model
{
    public class ScheduleType : ICoreEntity
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// The name of the schedule type.
        /// </summary>
        /// <example>Pick-up</example>
        public virtual string FullName { get; set; }

        /// <summary>
        /// A list of recipients with a given status.
        /// This is needed by the ORM to link to a recipeint.
        /// </summary>
        public virtual IList<Recipient> Recipients { get; set; }

        public ScheduleType()
        {
            Recipients = new List<Recipient>();
        }
    }
}
