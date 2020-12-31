using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenDict.Data;

namespace OpenDict.Helpers
{
    public class LocalizationHelper
    {
        private readonly Context _context;
        public LocalizationHelper(Context context)
        {
            _context = context;
        }

        public string T(string localeString)
        {
            var localeStringResource = _context.LocaleStringResources.Where(q => q.LocaleString == localeString).FirstOrDefault();
            return localeStringResource.Text;
        }
    }
}
