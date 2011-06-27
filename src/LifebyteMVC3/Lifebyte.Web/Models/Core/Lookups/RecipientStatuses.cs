using System.Collections.Generic;
using System.Web.Mvc;

namespace Lifebyte.Web.Models.Core.Lookups
{
    public class RecipientStatuses
    {
        public static readonly IDictionary<string, string> RecipientStatusesDictionary = new Dictionary<string, string>
                                                                                             {
                                                                                                 {"", ""},
                                                                                                 {"New", "New"},
                                                                                                 {"Needs Computer", "Needs Computer"},
                                                                                                 {"Needs Repair", "Needs Repair"},
                                                                                                 {"Completed", "Completed"},
                                                                                                 {"Scheduled", "Scheduled"},
                                                                                             };

        public static SelectList RecipientStatusesSelectList
        {
            get { return new SelectList(RecipientStatusesDictionary, "Value", "Key"); }
        }
    }
}