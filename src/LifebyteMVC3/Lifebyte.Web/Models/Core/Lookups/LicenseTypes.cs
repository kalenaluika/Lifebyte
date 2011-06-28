using System.Collections.Generic;
using System.Web.Mvc;

namespace Lifebyte.Web.Models.Core.Lookups
{
    public class LicenseTypes
    {
        public static readonly IDictionary<string, string> LicenseTypesDictionary = new Dictionary<string, string>
                                                                                        {
                                                                                            {"", ""},
                                                                                            {"Windows 2000", "Win2K"},
                                                                                            {"Windows XP", "XP"},
                                                                                            {"Windows 7", "Win7"},
                                                                                        };

        public static SelectList LicenseTypesSelectList
        {
            get { return new SelectList(LicenseTypesDictionary, "Value", "Key"); }
        }
    }
}