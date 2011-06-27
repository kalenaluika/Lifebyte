using System.Collections.Generic;
using System.Web.Mvc;

namespace Lifebyte.Web.Models.Core.Lookups
{
    public class ScheduleTypes
    {
        public static readonly IDictionary<string, string> ScheduleTypesDictionary = new Dictionary<string, string>
                                                                                         {
                                                                                             {"", ""},
                                                                                             {"Delivery", "Delivery"},
                                                                                             {"Pick-Up", "Pick-Up"},
                                                                                         };

        public static SelectList ScheduleTypesSelectList
        {
            get { return new SelectList(ScheduleTypesDictionary, "Value", "Key"); }
        }
    }
}