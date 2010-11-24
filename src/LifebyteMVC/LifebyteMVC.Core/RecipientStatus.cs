using System.Collections.Generic;

namespace LifebyteMVC.Core
{
    public class RecipientStatus
    {
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
        /// This is needed by the ORM to link to a recipeint.
        /// </summary>
        public virtual IList<Recipient> Recipients { get; set; }

        public RecipientStatus()
        {
            Recipients = new List<Recipient>();
        }
    }
}
