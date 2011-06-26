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
                                                                                     {"Alabama", "AL"},
                                                                                     {"Alaska", "AK"},
                                                                                     {"American Samoa", "AS"},
                                                                                     {"Arizona", "AZ"},
                                                                                     {"Arkansas", "AR"},
                                                                                     {"California", "CA"},
                                                                                     {"Colorado", "CO"},
                                                                                     {"Connecticut", "CT"},
                                                                                     {"Delaware", "DE"},
                                                                                     {"District of Columbia", "DC"},
                                                                                     {"Florida", "FL"},
                                                                                     {"Georgia", "GA"},
                                                                                     {"Guam", "GU"},
                                                                                     {"Hawaii", "HI"},
                                                                                     {"Idaho", "ID"},
                                                                                     {"Illinois", "IL"},
                                                                                     {"Indiana", "IN"},
                                                                                     {"Iowa", "IA"},
                                                                                     {"Kansas", "KS"},
                                                                                     {"Kentucky", "KY"},
                                                                                     {"Louisiana", "LA"},
                                                                                     {"Maine", "ME"},
                                                                                     {"Marshall Islands", "MH"},
                                                                                     {"Maryland", "MD"},
                                                                                     {"Massachusetts", "MA"},
                                                                                     {"Michigan", "MI"},
                                                                                     {"Minnesota", "MN"},
                                                                                     {"Mississippi", "MS"},
                                                                                     {"Missouri", "MO"},
                                                                                     {"Montana", "MT"},
                                                                                     {"Nebraska", "NE"},
                                                                                     {"Nevada", "NV"},
                                                                                     {"New Hampshire", "NH"},
                                                                                     {"New Jersey", "NJ"},
                                                                                     {"New Mexico", "NM"},
                                                                                     {"New York", "NY"},
                                                                                     {"North Carolina", "NC"},
                                                                                     {"North Dakota", "ND"},
                                                                                     {"Northern Mariana Islands", "MP"},
                                                                                     {"Ohio", "OH"},
                                                                                     {"Oklahoma", "OK"},
                                                                                     {"Oregon", "OR"},
                                                                                     {"Palau", "PW"},
                                                                                     {"Pennsylvania", "PA"},
                                                                                     {"Puerto Rico", "PR"},
                                                                                     {"Rhode Island", "RI"},
                                                                                     {"South Carolina", "SC"},
                                                                                     {"South Dakota", "SD"},
                                                                                     {"Tennessee", "TN"},
                                                                                     {"Texas", "TX"},
                                                                                     {"Utah", "UT"},
                                                                                     {"Vermont", "VT"},
                                                                                     {"Virgin Islands", "VI"},
                                                                                     {"Virginia", "VA"},
                                                                                     {"Washington", "WA"},
                                                                                     {"West Virginia", "WV"},
                                                                                     {"Wisconsin", "WI"},
                                                                                     {"Wyoming", "WY"}
                                                                                 };

        public static SelectList StateSelectList
        {
            get { return new SelectList(StateDictionary, "Value", "Key"); }
        }
    }
}