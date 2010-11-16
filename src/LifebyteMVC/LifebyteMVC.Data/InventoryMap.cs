using FluentNHibernate.Mapping;
using LifebyteMVC.Core;

namespace LifebyteMVC.Data
{
    public class InventoryMap : ClassMap<Inventory>
    {
        public InventoryMap()
        {
            Id(i => i.ID);
            Map(x => x.BelarcHtml);
            Map(x => x.BelarcURL);
            Map(x => x.Recipient);
        }        
    }
}
