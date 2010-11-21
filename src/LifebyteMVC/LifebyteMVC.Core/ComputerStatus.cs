using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifebyteMVC.Core
{
    public class ComputerStatus
    {
        /// <summary>
        /// The ID of the computer status.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// The status of the computer.
        /// </summary>
        public virtual string Status { get; set; }

        /// <summary>
        /// The description of the status.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// A list of inventory items with a given status.
        /// </summary>
        public virtual IList<Computer> Computers { get; set; }

        public ComputerStatus()
        {
            Computers = new List<Computer>();
        }
    }
}
