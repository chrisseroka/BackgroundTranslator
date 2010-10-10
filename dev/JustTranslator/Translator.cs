using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Google.API.Translate;

namespace JustTranslator
{
    public class Translator
    {
        private TranslateClient transClient;

        public Translator()
        {
            this.transClient = new TranslateClient("www.google.com");
            //Initialize translator
            this.WarmUp();
        }

        /// <summary>
        /// Warms up connections to avoid that first translation would be processed longer
        /// </summary>
        private void WarmUp()
        {
            this.transClient.Translate("main", Language.English.TwoLetterName, Language.Polish.TwoLetterName);
        }

        /// <summary>
        /// Translates text from one language to another
        /// </summary>
        /// <param name="txt">Source text</param>
        /// <param name="ciSource">Source language</param>
        /// <param name="ciDst">Destination language</param>
        /// <returns>Raw string containing translation result</returns>
        public string Translate(string txt, Language ciSource, Language ciDst)
        {
            string result;

            result = this.transClient.Translate(txt, ciSource.TwoLetterName, ciDst.TwoLetterName);

            return result;
        }
    }
}
