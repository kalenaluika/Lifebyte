using System.Collections.Generic;
using System.Web.Mvc;

namespace Lifebyte.Web.Models.Core.Lookups
{
    public class ComputerStatuses
    {
        public static readonly IDictionary<string, string> ComputerStatusesDictionary = new Dictionary<string, string>
                                                                                            {
                                                                                                {"", ""},
                                                                                                {"1", "Build"},
                                                                                                {"2", "Ready for Delivery"},
                                                                                                {"3", "Repair"},
                                                                                                {"4", "Delivered"},
                                                                                            };

        public static SelectList ComputerStatusesSelectList
        {
            get { return new SelectList(ComputerStatusesDictionary, "Key", "Value"); }
        }
    }
}