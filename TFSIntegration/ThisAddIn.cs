// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThisAddIn.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ThisAddIn type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TFSIntegration
{
    using System;

    /// <summary>The this add in.</summary>
    public partial class ThisAddIn
    {
        #region Methods

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += this.ThisAddIn_Startup;
            this.Shutdown += this.ThisAddIn_Shutdown;
        }

        /// <summary>The this add in_ shutdown.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {
        }

        /// <summary>The this add in_ startup.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
        }

        #endregion
    }
}