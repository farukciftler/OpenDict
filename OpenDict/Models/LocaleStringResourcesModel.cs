﻿
namespace OpenDict.Models
{
    public class LocaleStringResourcesModel
    {
        public int Id { get; set; }
        public string LocaleString { get; set; }
        public int LanguageId { get; set; }
        public string Text { get; set; }

    }
}
