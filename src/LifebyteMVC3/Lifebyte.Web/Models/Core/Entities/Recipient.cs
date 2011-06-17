using System;
using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Core.Entities
{
    public class Recipient : ICoreEntity
    {
        public virtual Guid Id { get; set; }
    }
}