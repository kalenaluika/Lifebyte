using System;
using System.Collections.Generic;
using Lifebyte.Web.Models.Core.Entities;

namespace Lifebyte.Web.Models.ViewModels
{
    public class DeliverComputerViewModel
    {
        public Computer Computer { get; set; }

        public IList<Recipient> RecipientsWhoNeedAComputer { get; set; }

        public Guid RecipientId { get; set; }
    }
}