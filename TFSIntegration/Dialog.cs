// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Dialog.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Dialog type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TFSIntegration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    using Microsoft.Office.Interop.Outlook;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;

    using TFSIntegration.Classes;
    using TFSIntegration.Model;
    using TFSIntegration.Properties;

    using Attachment = Microsoft.TeamFoundation.WorkItemTracking.Client.Attachment;
    using Exception = System.Exception;

    /// <summary>The dialog.</summary>
    public partial class Dialog : Form
    {
        #region Fields

        /// <summary>The mail mailItem.</summary>
        private readonly List<MailItem> mailItems;

        /// <summary>The team explorer dialog.</summary>
        private readonly TeamExplorerDialog teamExplorerDialog;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="Dialog"/> class.</summary>
        /// <param name="mailItems">The mail Item list.</param>
        /// <param name="teamExplorerDialog">The team Explorer Dialog.</param>
        public Dialog(List<MailItem> mailItems, TeamExplorerDialog teamExplorerDialog)
        {
            this.mailItems = mailItems;
            this.teamExplorerDialog = teamExplorerDialog;
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>The get tasks.</summary>
        /// <param name="taskId">The task id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        private Task GetTasks(int taskId)
        {
            try
            {
                var workItemStore = this.teamExplorerDialog.Tfs.GetService<WorkItemStore>();
                var task = workItemStore.GetWorkItem(taskId);
                return new Task { Title = task.Title, TaskId = task.Id };
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>The save email.</summary>
        /// <param name="mailItem">The mailItem.</param>
        /// <returns>The <see cref="string"/> path.</returns>
        private string SaveEmail(MailItem mailItem)
        {
            if (mailItem == null)
            {
                throw new ArgumentNullException("mailItem");
            }

            var validName = mailItem.Subject;
            var invalidChars = Path.GetInvalidFileNameChars();
            validName = invalidChars.Aggregate(
                validName, 
                (current, c) => current.Replace(c.ToString(CultureInfo.InvariantCulture), string.Empty));
            string path = string.Format(CultureInfo.InvariantCulture, "{0}.msg", validName);
            mailItem.SaveAs(path);
            return path;
        }

        /// <summary>The accept button_ click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void acceptButton_Click(object sender, EventArgs e)
        {
            var workItemStore = this.teamExplorerDialog.Tfs.GetService<WorkItemStore>();
            var itemCollection = this.taskListView.Items;

            if (itemCollection.Count > 0)
            {
                foreach (var mailItem in this.mailItems)
                {
                    string path = this.SaveEmail(mailItem);
                    foreach (var workItem in
                        from ListViewItem task in itemCollection
                        select workItemStore.GetWorkItem(Convert.ToInt32(task.Text)))
                    {
                        workItem.Attachments.Add(new Attachment(path, "Attached email"));
                        workItem.Save();
                        File.Delete(path);
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    Resources.Dialog_acceptButton_Click_Please_add_at_least_one_task, 
                    Resources.Dialog_addButton_Click_Error, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                this.taskTextBox.SelectAll();
                this.taskTextBox.Focus();
            }
        }

        /// <summary>The add button_ click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void addButton_Click(object sender, EventArgs e)
        {
            string taskId = this.taskTextBox.Text;
            if (!string.IsNullOrEmpty(taskId))
            {
                int taskNumber = Convert.ToInt32(taskId);
                var task = this.GetTasks(taskNumber);
                if (task != null)
                {
                    var listItem = new ListViewItem(task.TaskId.ToString(CultureInfo.InvariantCulture));
                    listItem.SubItems.Add(task.Title);
                    this.taskListView.Items.Add(listItem);
                    this.taskTextBox.Text = string.Empty;
                    this.errorProvider.SetError(this.taskTextBox, string.Empty);
                }
                else
                {
                    MessageBox.Show(
                        Resources.Dialog_addButton_Click_Invalid_Task_number, 
                        Resources.Dialog_addButton_Click_Error, 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                    this.taskTextBox.SelectAll();
                }
            }
        }

        /// <summary>The background worker_ do work.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        /// <summary>The cancel button_ click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>The delete selected button_ click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void deleteSelectedButton_Click(object sender, EventArgs e)
        {
            ListView.ListViewItemCollection itemCollection = this.taskListView.Items;
            foreach (ListViewItem item in itemCollection.Cast<ListViewItem>().Where(item => item.Checked))
            {
                item.Remove();
            }
        }

        /// <summary>The task list view_ validating.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void taskListView_Validating(object sender, CancelEventArgs e)
        {
            var listView = sender as ListView;
            if (listView != null)
            {
                if (listView.Items.Count == 0)
                {
                    e.Cancel = true;
                    this.errorProvider.SetError(listView, "Please add more tasks");
                }
            }
        }

        /// <summary>The task text box_ validating.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void taskTextBox_Validating(object sender, CancelEventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox != null)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    e.Cancel = true;
                    this.errorProvider.SetError(textBox, "Required Value");
                    return;
                }

                if (this.taskListView.Items.Count == 0)
                {
                    e.Cancel = true;
                    this.errorProvider.SetError(textBox, "Required Value");
                }
            }
        }

        #endregion

    }
}