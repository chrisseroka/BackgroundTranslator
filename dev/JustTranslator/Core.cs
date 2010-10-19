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
        Translator translator;
        IWindowView aboutForm;
        IWindowView AboutForm
        {
            get { if (aboutForm == null) aboutForm = new AboutForm(); return this.aboutForm; }
        }

        ITranslatorView translationResultForm;
        ITranslatorView TranslationResultForm
        {
            get
            {
                if (translationResultForm == null)
                { translationResultForm = new TranslationResultForm();
                this.translationResultForm.Translate += new EventHandler(translationResultForm_Translate);
                } return this.translationResultForm;
            }
        }

        NotifyIconContainer notifyIconContainer;
        string lastClipboardText;
        NHotKeyManager hotKeyManager;
        Language srcLang = Language.English;
        Language dstLang = Language.Polish;

        public Core()
        {
            this.hotKeyManager = new NHotKeyManager();
            this.translator = new Translator();
            this.notifyIconContainer = new JustTranslator.Views.NotifyIconContainer();
            //this.StartTranslationLoop();
            this.hotKeyManager.AddHotKey(new HotKey { Key = Keys.T, KeyModifiers = KeyModifiers.Control | KeyModifiers.Windows }, 
                new EventHandler(this.OnTranslate));
            this.hotKeyManager.AddHotKey(new HotKey
            {
                Key = Keys.T,
                KeyModifiers = NHotKey.KeyModifiers.Windows |
                               NHotKey.KeyModifiers.Control |
                               NHotKey.KeyModifiers.Shift
            },new EventHandler(this.OnShowTranslationWindow));
        }

        void translationResultForm_Translate(object sender, EventArgs e)
        {
            this.Translate(this.TranslationResultForm.TextToTranslate, this.srcLang, this.dstLang);
        }

        void OnShowTranslationWindow(object sender, EventArgs e)
        {
            this.TranslationResultForm.Show();
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

        public void ShowTranslationResult(string origin, string result)
        {
            this.TranslationResultForm.TextTranslated = result;
            this.TranslationResultForm.TextToTranslate = origin;

            this.TranslationResultForm.Show();
        }

        private void Translate(string txt, Language srcLang, Language dstLang)
        {
            string result = this.translator.Translate(txt, srcLang, dstLang);
            this.ShowTranslationResult(txt, result);
        }

        protected void OnTranslate(object sender, EventArgs e)
        {
            string txt = null;

            txt = GetClipboardText();
            //Check if there is new phrase to translate
            //and if the phrase is properly formated (not number etc)
            if (txt != this.lastClipboardText && IsPhraseToTranslate(txt))
            {
                //Store translation result
                this.lastClipboardText = txt;
                //Translate
                this.Translate(txt, this.srcLang, this.dstLang);
            }
        }
    }
}
