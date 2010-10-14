using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace JustTranslator.Views
{
    public class NotifyIconContainer
    {
        private NotifyIcon _notifyIcon;
        private ContextMenuStrip _notifyIconContextMenu;
        private ToolStripMenuItem _closeCommandItem;
        private ToolStripMenuItem _aboutCommandItem;

        public NotifyIconContainer()
        {
            this.InitializeComponents();
        }

        public void InitializeComponents()
        {
            //Icon is set to type of AboutForm
            //because the resource is set to System.Windows.Forms type
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this._notifyIcon = new NotifyIcon();
            this._notifyIconContextMenu = new ContextMenuStrip();
            this._closeCommandItem = new ToolStripMenuItem();
            this._aboutCommandItem = new ToolStripMenuItem();

            this._closeCommandItem.Name = "icon2ToolStripMenuItem";
            this._closeCommandItem.Size = new System.Drawing.Size(103, 22);
            this._closeCommandItem.Text = "Icon2";

            this._aboutCommandItem.Name = "icon1ToolStripMenuItem";
            this._aboutCommandItem.Size = new System.Drawing.Size(103, 22);
            this._aboutCommandItem.Text = "Icon1";

            this._notifyIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutCommandItem,
            this._closeCommandItem});
            this._notifyIconContextMenu.Name = "contextMenuStrip1";
            this._notifyIconContextMenu.Size = new System.Drawing.Size(104, 48);

            this._notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this._notifyIcon.Text = "notifyIcon1";
            this._notifyIcon.ContextMenuStrip = this._notifyIconContextMenu;
            this._notifyIcon.Visible = true;
        }
        
    }
}
