using System.Collections.Generic;
using System.Web.Mvc;

namespace Lifebyte.Web.Models.Core.Lookups
{
    /// <summary>
    /// http://stackoverflow.com/questions/289048/asp-net-mvc-us-state-drop-down-list/4651491#4651491
    /// </summary>
    public class UnitedStatesStates
    {
        public static readonly IDictionary<string, string> StateDictionary = new Dictionary<string, string>
                                                                                 {
                                                                                     {"",""},
                                                                                     {"AL", "Alabama"},
                                                                                     {"AK", "Alaska"},
                                                                                     {"AS", "American Samoa"},
                                                                                     {"AZ", "Arizona"},
                                                                                     {"AR", "Arkansas"},
                                                                                     {"CA", "California"},
                                                                                     {"CO", "Colorado"},
                                                                                     {"CT", "Connecticut"},
                                                                                     {"DE", "Delaware"},
                                                                                     {"DC", "District of Columbia"},
                                                                                     {"FL", "Florida"},
                                                                                     {"GA", "Georgia"},
                                                                                     {"GU", "Guam"},
                                                                                     {"HI", "Hawaii"},
                                                                                     {"ID", "Idaho"},
                                                                                     {"IL", "Illinois"},
                                                                                     {"IN", "Indiana"},
                                                                                     {"IA", "Iowa"},
                                                                                     {"KS", "Kansas"},
                                                                                     {"KY", "Kentucky"},
                                                                                     {"LA", "Louisiana"},
                                                                                     {"ME", "Maine"},
                                                                                     {"MH", "Marshall Islands"},
                                                                                     {"MD", "Maryland"},
                                                                                     {"MA", "Massachusetts"},
                                                                                     {"MI", "Michigan"},
                                                                                     {"MN", "Minnesota"},
                                                                                     {"MS", "Mississippi"},
                                                                                     {"MO", "Missouri"},
                                                                                     {"MT", "Montana"},
                                                                                     {"NE", "Nebraska"},
                                                                                     {"NV", "Nevada"},
                                                                                     {"NH", "New Hampshire"},
                                                                                     {"NJ", "New Jersey"},
                                                                                     {"NM", "New Mexico"},
                                                                                     {"NY", "New York"},
                                                                                     {"NC", "North Carolina"},
                                                                                     {"ND", "North Dakota"},
                                                                                     {"MP", "Northern Mariana Islands"},
                                                                                     {"OH", "Ohio"},
                                                                                     {"OK", "Oklahoma"},
                                                                                     {"OR", "Oregon"},
                                                                                     {"PW", "Palau"},
                                                                                     {"PA", "Pennsylvania"},
                                                                                     {"PR", "Puerto Rico"},
                                                                                     {"RI", "Rhode Island"},
                                                                                     {"SC", "South Carolina"},
                                                                                     {"SD", "South Dakota"},
                                                                                     {"TN", "Tennessee"},
                                                                                     {"TX", "Texas"},
                                                                                     {"UT", "Utah"},
                                                                                     {"VT", "Vermont"},
                                                                                     {"VI", "Virgin Islands"},
                                                                                     {"VA", "Virginia"},
                                                                                     {"WA", "Washington"},
                                                                                     {"WV", "West Virginia"},
                                                                                     {"WI", "Wisconsin"},
                                                                                     {"WY", "Wyoming"},
                                                                                 };

        public static SelectList StateSelectList
        {
            get { return new SelectList(StateDictionary, "Key", "Value"); }
        }
    }
}