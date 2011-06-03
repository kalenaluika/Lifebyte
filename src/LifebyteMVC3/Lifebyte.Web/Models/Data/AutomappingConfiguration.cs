using System;
using FluentNHibernate.Automapping;

namespace Lifebyte.Web.Models.Data
{
    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        /// <summary>
        /// Everything in the LifebyteMVC.Models.Core.Entites should map
        /// to the database.
        /// </summary>
        /// <param name="type">The type to check if it is mapped or not.</param>
        /// <returns>True if the given type is mapped to the database.</returns>
        public override bool ShouldMap(Type type)
        {
            return type.Namespace == "Lifebyte.Web.Models.Core.Entities";
        }
    }
}