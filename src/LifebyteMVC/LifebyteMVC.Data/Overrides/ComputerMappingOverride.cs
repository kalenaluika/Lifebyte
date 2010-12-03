using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using LifebyteMVC.Core.Model;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Automapping;
using NHibernate.Mapping;

namespace LifebyteMVC.Data.Overrides
{
    public class ComputerMappingOverride : IAutoMappingOverride<Computer>
    {
        public void Override(AutoMapping<Computer> mapping)
        {
            mapping.Map(c => c.LBNumber).Length(7);
            mapping.Map(c => c.ManifestHtml).Length(4001); // anything over 4000 is nvarchar(max)
            mapping.Map(c => c.Notes).Length(2000);
        }
    }
}
