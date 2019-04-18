using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darksky.Model
{
    public class Language
    {
        public string DisplayName { get; set; }
        public string Code { get; set; }

        public Language(string displayName, string languageCode)
        {
            DisplayName = displayName;
            Code = languageCode;
        }
    }
}
