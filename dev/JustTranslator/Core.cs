using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using JustTranslator.Views;
using NHotKey;

namespace JustTranslator
{
    public class Core: System.Windows.Forms.ApplicationContext
    {
        Thread translationThread;
        Translator translator;
        AboutForm aboutForm = new AboutForm();
        TranslationResultForm translationResultForm = new TranslationResultForm();
        NotifyIconContainer notifyIconContainer;
        string lastClipboardText;
        NHotKeyManager hotKeyManager;

        public Core()
        {
            this.hotKeyManager = new NHotKeyManager();
            this.translator = new Translator();
            this.notifyIconContainer = new JustTranslator.Views.NotifyIconContainer();
            //this.StartTranslationLoop();
            this.hotKeyManager.AddHotKey(new HotKey { Key = Keys.F10, KeyModifiers = KeyModifiers.Control }, new EventHandler(this.OnTranslate));
        }

        private static bool IsPhraseToTranslate(string s)
        {
            const int maxTextLength = 50;
            Regex r = new Regex("[a-zA-Z]");

            return (
                s.Length < maxTextLength &&
                r.IsMatch(s)
                );
        }

        private static string GetClipboardText()
        {
            if (Clipboard.ContainsText())
                return Clipboard.GetText();
            else
                return null;
        }

        public void ShowTranslationResult(string result)
        {
            this.translationResultForm.ShowTranslation(result);
        }

        protected void OnTranslate(object sender, EventArgs e)
        {
            Language srcLang = Language.English;
            Language dstLang = Language.Polish;

            string txt = null;
            string result;

            txt = GetClipboardText();
            //Check if there is new phrase to translate
            //and if the phrase is properly formated (not number etc)
            if (txt != this.lastClipboardText && IsPhraseToTranslate(txt))
            {
                //Store translation result
                this.lastClipboardText = txt;
                //Translate
                result = this.translator.Translate(txt, srcLang, dstLang);
                this.ShowTranslationResult(result);
            }
        }
    }
}
