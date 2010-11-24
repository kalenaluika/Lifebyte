using System.Collections.Generic;

namespace LifebyteMVC.Core
{
    public class ComputerStatus
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// A short word or phrase that describes the status of a computer.
        /// </summary>
        /// <example>Ready for Delivery</example>
        public virtual string Status { get; set; }

        /// <summary>
        /// A longer description of the status.
        /// </summary>
        /// <example>The computer is ready for delivery.</example>
        public virtual string Description { get; set; }

        /// <summary>
        /// A list of inventory items with a given status. 
        /// This is needed by the ORM to link to a computer.
        /// </summary>
        public virtual IList<Computer> Computers { get; set; }

        public ComputerStatus()
        {
            Computers = new List<Computer>();
        }
    }
}
