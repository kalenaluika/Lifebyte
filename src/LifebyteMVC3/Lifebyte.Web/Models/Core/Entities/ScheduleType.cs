using System.Collections.Generic;
using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Core.Entities
{
    public class ScheduleType : ICoreEntity
    {
        public ScheduleType()
        {
            Recipients = new List<Recipient>();
        }

        public virtual int Id { get; set; }

        /// <summary>
        /// The name of the schedule type.
        /// </summary>
        /// <example>Pick-up</example>
        public virtual string FullName { get; set; }

        /// <summary>
        /// A list of recipients with a given status.
        /// This is needed by the ORM to link to a recipient.
        /// </summary>
        public virtual IList<Recipient> Recipients { get; set; }
    }
}