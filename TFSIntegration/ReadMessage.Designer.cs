namespace TFSIntegration
{
    partial class ReadMessage : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ReadMessage()
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
            Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl1 = this.Factory.CreateRibbonDialogLauncher();
            this.TFSTab = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.openDialogButton = this.Factory.CreateRibbonButton();
            this.TFSTab.SuspendLayout();
            this.group1.SuspendLayout();
            // 
            // TFSTab
            // 
            this.TFSTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.TFSTab.ControlId.OfficeId = "TabReadMessage";
            this.TFSTab.Groups.Add(this.group1);
            this.TFSTab.Label = "TabReadMessage";
            this.TFSTab.Name = "TFSTab";
            // 
            // group1
            // 
            this.group1.DialogLauncher = ribbonDialogLauncherImpl1;
            this.group1.Items.Add(this.openDialogButton);
            this.group1.Label = "TFS";
            this.group1.Name = "group1";
            this.group1.DialogLauncherClick += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Group_DialogLauncherClick);
            // 
            // openDialogButton
            // 
            this.openDialogButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.openDialogButton.Label = "Attach email to task";
            this.openDialogButton.Name = "openDialogButton";
            this.openDialogButton.OfficeImageId = "AttachItemCombo";
            this.openDialogButton.ScreenTip = "Attach the currently selected emails to a task in TFS";
            this.openDialogButton.ShowImage = true;
            this.openDialogButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.openDialogButton_Click);
            // 
            // ReadMessage
            // 
            this.Name = "ReadMessage";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.TFSTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.TFSTab.ResumeLayout(false);
            this.TFSTab.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab TFSTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton openDialogButton;
    }

    partial class ThisRibbonCollection
    {
        internal ReadMessage Ribbon
        {
            get { return this.GetRibbon<ReadMessage>(); }
        }
    }
}
