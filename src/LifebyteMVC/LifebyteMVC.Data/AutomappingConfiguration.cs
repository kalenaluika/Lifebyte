using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping;
using LifebyteMVC.Core;

namespace LifebyteMVC.Data
{
    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        private List<Type> components;

        public AutomappingConfiguration()
        {
            components = new List<Type>
            {
                typeof(ComputerStatus),
                typeof(LicenseType),
                typeof(RecipientStatus),
                typeof(ScheduleType)
            };
        }

        public override bool ShouldMap(Type type)
        {
            return type.Namespace == "LifebyteMVC.Core";
        }

        public override bool IsComponent(Type type)
        {
            return false; //components.Contains(type);
        }
    }
}
