using System.Collections.Generic;
using System.Web.Mvc;

namespace Lifebyte.Web.Models.Core.Lookups
{
    public class LicenseTypes
    {
        public static readonly IDictionary<string, string> LicenseTypesDictionary = new Dictionary<string, string>
                                                                                        {
                                                                                            {"", ""},
                                                                                            {"Win2K", "Windows 2000"},
                                                                                            {"XP", "Windows XP"},
                                                                                            {"Win7", "Windows 7"},
                                                                                        };

        public static SelectList LicenseTypesSelectList
        {
            get { return new SelectList(LicenseTypesDictionary, "Key", "Value"); }
        }
    }
}