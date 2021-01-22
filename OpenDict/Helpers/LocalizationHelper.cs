using System;
using Microsoft.Extensions.Configuration;
using OpenDict.Data;
using Microsoft.AspNetCore.Http;
using OpenDict.Models;
namespace OpenDict.Helpers
{
    public class LocalizationHelper
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;
        private readonly HttpHelper _httpHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LocalizationHelper(Context context, IConfiguration configuration, HttpHelper httpHelper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpHelper = httpHelper;
            _httpContextAccessor = httpContextAccessor;
        }

        public string T(string localeString)
        {
            var url =   "/api/localestringresources/locale/" + $"?localeString={localeString}&languageId={_configuration["Language:LanguageId"]}";
            var localeStringResource = _httpHelper.GetApiEndpoint<LocaleStringResourcesModel>(url);
            if(localeStringResource.Text != null)
            {
                return localeStringResource.Text;
            }else
            {
                return "";
            }
            
        }
    }
}
