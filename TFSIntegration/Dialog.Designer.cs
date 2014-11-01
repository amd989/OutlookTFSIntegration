namespace TFSIntegration
{
    partial class Dialog
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
            this.components = new System.ComponentModel.Container();
            this.taskTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.taskListView = new System.Windows.Forms.ListView();
            this.TaskId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.loaderIcon = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.deleteSelectedButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaderIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // taskTextBox
            // 
            this.taskTextBox.AcceptsReturn = true;
            this.taskTextBox.CausesValidation = false;
            this.taskTextBox.Location = new System.Drawing.Point(53, 15);
            this.taskTextBox.Name = "taskTextBox";
            this.taskTextBox.Size = new System.Drawing.Size(218, 20);
            this.taskTextBox.TabIndex = 0;
            this.taskTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.taskTextBox_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Task:";
            // 
            // addButton
            // 
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Image = global::TFSIntegration.Properties.Resources.plus;
            this.addButton.Location = new System.Drawing.Point(305, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(25, 24);
            this.addButton.TabIndex = 1;
            this.toolTip1.SetToolTip(this.addButton, "Add Task");
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(309, 166);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(55, 23);
            this.acceptButton.TabIndex = 5;
            this.acceptButton.Text = "Save";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(228, 166);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // taskListView
            // 
            this.taskListView.CheckBoxes = true;
            this.taskListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TaskId,
            this.Title});
            this.taskListView.Location = new System.Drawing.Point(13, 41);
            this.taskListView.Name = "taskListView";
            this.taskListView.Size = new System.Drawing.Size(351, 119);
            this.taskListView.TabIndex = 2;
            this.taskListView.UseCompatibleStateImageBehavior = false;
            this.taskListView.View = System.Windows.Forms.View.Details;
            this.taskListView.Validating += new System.ComponentModel.CancelEventHandler(this.taskListView_Validating);
            // 
            // TaskId
            // 
            this.TaskId.Text = "TaskId";
            this.TaskId.Width = 56;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 257;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // loaderIcon
            // 
            this.loaderIcon.Image = global::TFSIntegration.Properties.Resources.spin;
            this.loaderIcon.Location = new System.Drawing.Point(336, 132);
            this.loaderIcon.Name = "loaderIcon";
            this.loaderIcon.Size = new System.Drawing.Size(24, 24);
            this.loaderIcon.TabIndex = 6;
            this.loaderIcon.TabStop = false;
            this.loaderIcon.Visible = false;
            // 
            // deleteSelectedButton
            // 
            this.deleteSelectedButton.FlatAppearance.BorderSize = 0;
            this.deleteSelectedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteSelectedButton.Image = global::TFSIntegration.Properties.Resources.x;
            this.deleteSelectedButton.Location = new System.Drawing.Point(336, 13);
            this.deleteSelectedButton.Name = "deleteSelectedButton";
            this.deleteSelectedButton.Size = new System.Drawing.Size(28, 23);
            this.deleteSelectedButton.TabIndex = 7;
            this.toolTip1.SetToolTip(this.deleteSelectedButton, "Delete Selected");
            this.deleteSelectedButton.UseVisualStyleBackColor = true;
            this.deleteSelectedButton.Click += new System.EventHandler(this.deleteSelectedButton_Click);
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(376, 203);
            this.Controls.Add(this.deleteSelectedButton);
            this.Controls.Add(this.loaderIcon);
            this.Controls.Add(this.taskListView);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.taskTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Tasks";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaderIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox taskTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListView taskListView;
        private System.Windows.Forms.ColumnHeader TaskId;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.PictureBox loaderIcon;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button deleteSelectedButton;
    }
}