// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TeamExplorerDialog.cs" company="">
//   
// </copyright>
// <summary>
//   The team explorer dialog.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TFSIntegration.Classes
{
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.Core.WebApi;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>The team explorer dialog.</summary>
    public class TeamExplorerDialog
    {
        #region Fields

        /// <summary>The storage.</summary>
        private readonly SettingStorage storage;

        /// <summary>The selected team project.</summary>
        private ProjectInfo selectedTeamProject;

        /// <summary>The TFS.</summary>
        private TfsTeamProjectCollection tfs;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="TeamExplorerDialog" /> class. </summary>
        public TeamExplorerDialog()
        {
            this.storage = new SettingStorage();
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the selected team project.</summary>
        public ProjectInfo SelectedTeamProject
        {
            get
            {
                if (this.storage.SelectedTeamProject == null)
                {
                    this.ConnectToTfsUsingTeamProjectPicker();
                }

                return this.selectedTeamProject;
            }

            set
            {
                this.selectedTeamProject = this.storage.SelectedTeamProject = value;
            }
        }

        /// <summary>Gets or sets the TFS.</summary>
        public TfsTeamProjectCollection Tfs
        {
            get
            {
                string uri = this.storage.TfsTeamProjectCollectionUri;
                if (string.IsNullOrEmpty(uri))
                {
                    this.ConnectToTfsUsingTeamProjectPicker();
                }

                return this.tfs ?? (this.tfs = new TfsTeamProjectCollection(new Uri(uri)));
            }

            set
            {
                if (value != null)
                {
                    this.tfs = value;
                    this.storage.TfsTeamProjectCollectionUri = value.Uri.ToString();
                }
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The connect to TFS using team project picker.</summary>
        public void ConnectToTfsUsingTeamProjectPicker()
        {
            // The  user is allowed to select only one project
            var tfsPp = new TeamProjectPicker(TeamProjectPickerMode.SingleProject, false);

            DialogResult result = tfsPp.ShowDialog();

            switch (result)
            {
                case DialogResult.Yes:
                case DialogResult.OK:
                    this.Tfs = tfsPp.SelectedTeamProjectCollection;
                    if (tfsPp.SelectedProjects.Any())
                    {
                        // The selected Team Project
                        // this.SelectedTeamProject = tfsPp.SelectedProjects[0];
                    }

                    break;
            }
        }

        #endregion
    }
}