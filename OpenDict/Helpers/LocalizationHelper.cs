using System;
using Microsoft.Extensions.Configuration;
using OpenDict.Data;
using Microsoft.AspNetCore.Http;
using OpenDict.Models;
namespace OpenDict.Helpers
{
    public class LocalizationHelper
    {
        private readonly IConfiguration _configuration;
        private readonly HttpHelper _httpHelper;
        public LocalizationHelper( IConfiguration configuration, HttpHelper httpHelper)
        {
            _configuration = configuration;
            _httpHelper = httpHelper;
        }

        public string T(string localeString)
        {
            var url =   "/api/localestringresources/locale/" + $"?localeString={localeString}&languageId={_configuration["Language:LanguageId"]}";
            var localeStringResource = _httpHelper.GetApiEndpoint<LocaleStringResourcesModel>(url);
            if(localeStringResource == null)
            {
                url = "/api/localestringresources/locale/" + $"?localeString={localeString}&languageId=1";
                localeStringResource = _httpHelper.GetApiEndpoint<LocaleStringResourcesModel>(url);
                return localeStringResource.LocaleString;
            }
            else
            {
                return localeStringResource.Text;
            }
            
        }
    }
}
