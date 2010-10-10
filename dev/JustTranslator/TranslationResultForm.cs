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
    public partial class TranslationResultForm : Form
    {
        public void ShowTranslation(string txt)
        {
            this.lblResult.Text = txt;
            this.Hide();       
            this.Show();

            this.Width = lblResult.Width + 20;
            this.Height = lblResult.Height + 20;
            this.Location = System.Windows.Forms.Cursor.Position;
            this.Show();
            this.Hide();
            this.Location = System.Windows.Forms.Cursor.Position;
            this.Show();
        }

        public TranslationResultForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        private void TranslationResultForm_MouseMove(object sender, MouseEventArgs e)
        {
            //It is invoked after Show() so check condition;
            if (e.X != 0 && e.Y != 0)
                this.Hide();
        }

    }
}
