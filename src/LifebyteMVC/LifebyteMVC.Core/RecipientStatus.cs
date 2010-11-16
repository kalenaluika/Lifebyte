using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifebyteMVC.Core
{
    public class RecipientStatus
    {
        /// <summary>
        /// The ID of the recipient status
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The status of the recipient
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The description of the status
        /// </summary>
        public string Description { get; set; }
    }
}
