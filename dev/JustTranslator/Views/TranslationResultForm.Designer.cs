namespace JustTranslator
{
    partial class TranslationResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblResult = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblResult.Location = new System.Drawing.Point(10, 9);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 20);
            this.lblResult.TabIndex = 1;
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(16, 30);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(166, 20);
            this.txtSource.TabIndex = 2;
            this.txtSource.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSource_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Origin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Translation";
            // 
            // txtDestination
            // 
            this.txtDestination.BackColor = System.Drawing.Color.White;
            this.txtDestination.ForeColor = System.Drawing.Color.Black;
            this.txtDestination.Location = new System.Drawing.Point(16, 75);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(166, 20);
            this.txtDestination.TabIndex = 5;
            // 
            // TranslationResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JustTranslator.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(200, 109);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.lblResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TranslationResultForm";
            this.Text = "TranslationResult";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.TranslationResultForm_Deactivate);
            this.LocationChanged += new System.EventHandler(this.TranslationResultForm_LocationChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDestination;
    }
}