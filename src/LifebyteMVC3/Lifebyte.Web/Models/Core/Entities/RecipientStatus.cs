using System.Collections.Generic;
using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Core.Entities
{
    public class RecipientStatus : ICoreEntity
    {
        public RecipientStatus()
        {
            Recipients = new List<Recipient>();
        }

        public virtual int Id { get; set; }

        /// <summary>
        /// The status of the recipient.
        /// </summary>
        /// <example>Needs Computer</example>
        public virtual string Status { get; set; }

        /// <summary>
        /// The description of the status.
        /// </summary>
        /// <example>The recipient needs a computer.</example>
        public virtual string Description { get; set; }

        /// <summary>
        /// A list of recipients with a given status.
        /// This is needed by the ORM to link to a recipient.
        /// </summary>
        public virtual IList<Recipient> Recipients { get; set; }
    }
}