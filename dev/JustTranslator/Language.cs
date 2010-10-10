using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustTranslator
{
    public class Language
    {
        public string InternalName
        {   get;  private set;   }

        public string InternationalName
        { get; private set; }

        public string TwoLetterName
        { get; private set; }

        public Language(string internationalName, string internalName, string twoLetterName)
        {
            this.InternalName = internalName;
            this.InternationalName = internationalName;
            this.TwoLetterName = twoLetterName;
        }

        //POSSIBLE LANGUAGES
        public static Language English
        { get { return new Language("English", "English", "en"); } }

        public static Language Polish
        { get { return new Language("Polish", "Polski", "pl"); } }
    }
}
