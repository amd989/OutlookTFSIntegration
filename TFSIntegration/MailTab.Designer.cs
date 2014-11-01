namespace TFSIntegration
{
    partial class MailTab : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public MailTab()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TFSIntegration = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.openDialogButton = this.Factory.CreateRibbonButton();
            this.TFSIntegration.SuspendLayout();
            this.group1.SuspendLayout();
            // 
            // TFSIntegration
            // 
            this.TFSIntegration.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.TFSIntegration.ControlId.OfficeId = "TabMail";
            this.TFSIntegration.Groups.Add(this.group1);
            this.TFSIntegration.Label = "TabMail";
            this.TFSIntegration.Name = "TFSIntegration";
            // 
            // group1
            // 
            this.group1.Items.Add(this.openDialogButton);
            this.group1.Label = "TFS";
            this.group1.Name = "group1";
            // 
            // openDialogButton
            // 
            this.openDialogButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.openDialogButton.Label = "Attach Email to TFS";
            this.openDialogButton.Name = "openDialogButton";
            this.openDialogButton.OfficeImageId = "AttachItemCombo";
            this.openDialogButton.ScreenTip = "Attach the currently selected emails to a task in TFS";
            this.openDialogButton.ShowImage = true;
            this.openDialogButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.openDialogButton_Click);
            // 
            // MailTab
            // 
            this.Name = "MailTab";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.TFSIntegration);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.MailTab_Load);
            this.TFSIntegration.ResumeLayout(false);
            this.TFSIntegration.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab TFSIntegration;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton openDialogButton;
    }

    partial class ThisRibbonCollection
    {
        internal MailTab MailTab
        {
            get { return this.GetRibbon<MailTab>(); }
        }
    }
}
