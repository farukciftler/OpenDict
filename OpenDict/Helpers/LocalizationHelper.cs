using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using OpenDict.Data;

namespace OpenDict.Helpers
{
    public class LocalizationHelper
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;

        public LocalizationHelper(Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string T(string localeString)
        {
            var localeStringResource = 
                _context
                .LocaleStringResources
                .Where(q => q.LocaleString == localeString && q.LanguageId == Convert.ToInt32(_configuration["Language:LanguageId"]))
                .FirstOrDefault();
            return localeStringResource.Text;
        }
    }
}
