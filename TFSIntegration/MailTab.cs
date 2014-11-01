using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace TFSIntegration
{
    using System.Windows.Forms;

    using Microsoft.Office.Interop.Outlook;

    public partial class MailTab
    {
        private void MailTab_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void openDialogButton_Click(object sender, RibbonControlEventArgs e)
        {
            var context = this.Context as Inspector;
            if (context != null)
            {
                var explorer = context.Application.ActiveExplorer();
                var selectedEmails = explorer.Selection;
                if (selectedEmails.Count > 0)
                {
                    var dialog = new Dialog(selectedEmails.Cast<MailItem>().ToList());
                    var dialogResult = dialog.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                    }
                }
            }
        }
    }
}
