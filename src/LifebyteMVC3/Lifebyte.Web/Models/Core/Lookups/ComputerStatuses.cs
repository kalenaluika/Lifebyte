using System.Collections.Generic;
using System.Web.Mvc;

namespace Lifebyte.Web.Models.Core.Lookups
{
    public class ComputerStatuses
    {
        public static readonly IDictionary<string, string> ComputerStatusesDictionary = new Dictionary<string, string>
                                                                                            {
                                                                                                {"", ""},
                                                                                                {"Build", "Build"},
                                                                                                {"Delivered", "Delivered"},
                                                                                                {"Ready for Delivery", "Ready for Delivery"},
                                                                                                {"Repair", "Repair"},
                                                                                            };

        public static SelectList ComputerStatusesSelectList
        {
            get { return new SelectList(ComputerStatusesDictionary, "Value", "Key"); }
        }
    }
}