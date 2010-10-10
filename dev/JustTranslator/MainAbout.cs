using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
[assembly:CLSCompliant(true)]

namespace JustTranslator
{
    public partial class MainAbout : Form
    {
        Translator translator;
        TranslationResultForm trForm;
        string lastClipboardText;

        public MainAbout()
        {
            InitializeComponent();
            this.translator = new Translator();
            this.Hide();
        }

        public void StartTranslationLoop()
        {
            ThreadPool.QueueUserWorkItem((WaitCallback)( x => this.TranslationLoop()));
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

        private void TranslationLoop()
        {
            const int sleepTimeout = 200;
            Language srcLang = Language.English;
            Language dstLang = Language.Polish;

            string txt = null;
            string result;

            //Get Clipboard data to avoid showing the tip at the application startup
            this.Invoke((Action)(() => txt = GetClipboardText()));

            while (true)
            {
               
                this.Invoke( (Action) ( () => txt = GetClipboardText()  ));
                //Check if there is new phrase to translate
                //and if the phrase is properly formated (not number etc)
                if (txt != this.lastClipboardText  &&   IsPhraseToTranslate(txt))
                {
                    //Store translation result
                    this.lastClipboardText = txt;
                    //Translate
                    result = this.translator.Translate(txt, srcLang, dstLang);
                    this.Invoke( (Action) (() => this.ShowTranslationResult(result) ));
                }

                Thread.Sleep(sleepTimeout);
            }
        }

        private void ShowTranslationResult(string txt)
        {
            if (this.trForm == null)
                this.trForm = new TranslationResultForm();
            this.trForm.ShowTranslation(txt);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.HideAll();
            e.Cancel = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.HideAll();
        }

        private void ShowAll()
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void HideAll()
        {
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.trayIcon.Visible = false;
            Application.Exit();
        }

        private void MainAbout_Load(object sender, EventArgs e)
        {
            this.HideAll();
            this.StartTranslationLoop();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowAll();
        }

        private void MainAbout_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.trayIcon.Visible = false;
        }
    }
}
