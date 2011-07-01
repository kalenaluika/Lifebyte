using System.Collections.Generic;
using System.Web.Mvc;

namespace Lifebyte.Web.Models.Core.Lookups
{
    public class RecipientStatuses
    {
        public static readonly IDictionary<string, string> RecipientStatusesDictionary = new Dictionary<string, string>
                                                                                             {
                                                                                                 {"", ""},
                                                                                                 {"1", "New"},
                                                                                                 {"2", "Needs Computer"},
                                                                                                 {"3", "Needs Repair"},
                                                                                                 {"4", "Scheduled"},
                                                                                                 {"5", "Completed"},
                                                                                             };

        public static SelectList RecipientStatusesSelectList
        {
            get { return new SelectList(RecipientStatusesDictionary, "Key", "Value"); }
        }
    }
}