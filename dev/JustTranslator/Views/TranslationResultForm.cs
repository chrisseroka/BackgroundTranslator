using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JustTranslator
{
    public partial class TranslationResultForm : Form, ITranslatorView
    {

        public TranslationResultForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        private void txtSource_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Enter)
                 && e.Modifiers == Keys.None
                 && this.Translate != null)
                this.Translate(this, new EventArgs());
            else if (e.KeyCode == Keys.Escape && e.Modifiers == Keys.None)
                this.Hide();
        }

        public event EventHandler Translate;

        string ITranslatorView.TextToTranslate
        {
            get
            {
                return this.txtSource.Text;
            }
            set
            {
                this.txtSource.Text = value;
            }
        }

        string ITranslatorView.TextTranslated
        {
            get
            {
                return this.txtDestination.Text;
            }
            set
            {
                this.txtDestination.Text = value;
            }
        }

        private void TranslationResultForm_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TranslationResultForm_LocationChanged(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - this.Size.Width,
Screen.PrimaryScreen.WorkingArea.Bottom - this.Size.Height);

        }
    }
}
