// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReadMessage.cs" company="">
//   
// </copyright>
// <summary>
//   The ribbon.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TFSIntegration
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    using Microsoft.Office.Interop.Outlook;
    using Microsoft.Office.Tools.Ribbon;

    using TFSIntegration.Classes;

    /// <summary>The ribbon.</summary>
    public partial class ReadMessage
    {
        #region Fields

        /// <summary>The storage.</summary>
        private Storage storage;

        /// <summary>The team explorer dialog.</summary>
        private TeamExplorerDialog teamExplorerDialog;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="ReadMessage"/> class.</summary>
        /// <param name="factory">The factory.</param>
        public ReadMessage(RibbonFactory factory)
            : base(factory)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the team explorer dialog.</summary>
        public TeamExplorerDialog TeamExplorerDialog
        {
            get
            {
                return this.teamExplorerDialog ?? (this.teamExplorerDialog = new TeamExplorerDialog());
            }

            set
            {
                this.teamExplorerDialog = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>The group_ dialog launcher click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void Group_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            this.TeamExplorerDialog.ConnectToTfsUsingTeamProjectPicker();
        }

        /// <summary>The ribbon load.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {
            this.storage = new Storage(this.Context as Inspector);
        }

        /// <summary>The open dialog button_ click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void openDialogButton_Click(object sender, RibbonControlEventArgs e)
        {
            var context = this.Context as Inspector;
            if (context != null)
            {
                ////var explorer = context.Application.ActiveExplorer();
                ////if (explorer.Selection.Count > 0)
                ////{
                var mailItem = context.CurrentItem as MailItem;
                var dialog = new Dialog(new List<MailItem> { mailItem }, this.TeamExplorerDialog);

                ////var dialog = new Dialog(explorer.Selection.Cast<MailItem>().ToList());
                DialogResult dialogResult = dialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                }

                //// }
            }
        }

        #endregion
    }
}