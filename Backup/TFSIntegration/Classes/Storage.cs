// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Storage.cs" company="">
//   
// </copyright>
// <summary>
//   The storage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TFSIntegration.Classes
{
    using Microsoft.Office.Interop.Outlook;

    /// <summary>The storage.</summary>
    public class Storage
    {
        #region Fields

        /// <summary>The context.</summary>
        private readonly Inspector context;

        /// <summary>The inbox.</summary>
        private readonly MAPIFolder inbox;

        /// <summary>The storage.</summary>
        private StorageItem storage;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="Storage"/> class.
        ///     Initializes a new instance of the <see cref="T:System.Object"/> class.</summary>
        /// <param name="context"></param>
        public Storage(Inspector context)
        {
            this.context = context;
            this.inbox = this.context.Application.Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The create storage.</summary>
        public void CreateStorage()
        {
            this.storage = this.inbox.GetStorage("TfsAddin", OlStorageIdentifierType.olIdentifyBySubject);
            if (this.storage.Size == 0)
            {
                this.storage.UserProperties.Add("tfs", OlUserPropertyType.olOutlookInternal);
            }
        }

        #endregion
    }
}