namespace Heteroauxin
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.checkBoxMatchCase = new System.Windows.Forms.CheckBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.listViewVariables = new System.Windows.Forms.ListView();
            this.columnVariables = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewValues = new System.Windows.Forms.ListView();
            this.columnValues = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLoadUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLoadSystem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonApplyUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripApplySystem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonLoadFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExportFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonAddDirectory = new System.Windows.Forms.Button();
            this.buttonDeleteValue = new System.Windows.Forms.Button();
            this.buttonAddValue = new System.Windows.Forms.Button();
            this.buttonDeleteVariable = new System.Windows.Forms.Button();
            this.buttonAddVariable = new System.Windows.Forms.Button();
            this.buttonValidateDirectory = new System.Windows.Forms.Button();
            this.toolTipButtons = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxFilter
            // 
            resources.ApplyResources(this.textBoxFilter, "textBoxFilter");
            this.textBoxFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFilter.Name = "textBoxFilter";
            this.toolTipButtons.SetToolTip(this.textBoxFilter, resources.GetString("textBoxFilter.ToolTip"));
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
            this.textBoxFilter.Enter += new System.EventHandler(this.textBoxFilter_Enter);
            this.textBoxFilter.Leave += new System.EventHandler(this.textBoxFilter_Leave);
            // 
            // checkBoxMatchCase
            // 
            resources.ApplyResources(this.checkBoxMatchCase, "checkBoxMatchCase");
            this.checkBoxMatchCase.Name = "checkBoxMatchCase";
            this.toolTipButtons.SetToolTip(this.checkBoxMatchCase, resources.GetString("checkBoxMatchCase.ToolTip"));
            this.checkBoxMatchCase.UseVisualStyleBackColor = true;
            this.checkBoxMatchCase.CheckedChanged += new System.EventHandler(this.checkBoxMatchCase_CheckedChanged);
            // 
            // openFileDialog
            // 
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // saveFileDialog
            // 
            resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
            // 
            // listViewVariables
            // 
            resources.ApplyResources(this.listViewVariables, "listViewVariables");
            this.listViewVariables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewVariables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnVariables});
            this.listViewVariables.FullRowSelect = true;
            this.listViewVariables.GridLines = true;
            this.listViewVariables.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewVariables.HideSelection = false;
            this.listViewVariables.LabelEdit = true;
            this.listViewVariables.Name = "listViewVariables";
            this.listViewVariables.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.toolTipButtons.SetToolTip(this.listViewVariables, resources.GetString("listViewVariables.ToolTip"));
            this.listViewVariables.UseCompatibleStateImageBehavior = false;
            this.listViewVariables.View = System.Windows.Forms.View.Details;
            this.listViewVariables.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listViewVariables_AfterLabelEdit);
            this.listViewVariables.Click += new System.EventHandler(this.listViewVariables_Click);
            this.listViewVariables.DoubleClick += new System.EventHandler(this.listViewVariables_DoubleClick);
            this.listViewVariables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewVariables_KeyDown);
            // 
            // columnVariables
            // 
            resources.ApplyResources(this.columnVariables, "columnVariables");
            // 
            // listViewValues
            // 
            resources.ApplyResources(this.listViewValues, "listViewValues");
            this.listViewValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnValues});
            this.listViewValues.GridLines = true;
            this.listViewValues.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewValues.LabelEdit = true;
            this.listViewValues.Name = "listViewValues";
            this.listViewValues.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.toolTipButtons.SetToolTip(this.listViewValues, resources.GetString("listViewValues.ToolTip"));
            this.listViewValues.UseCompatibleStateImageBehavior = false;
            this.listViewValues.View = System.Windows.Forms.View.Details;
            this.listViewValues.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listViewValues_AfterLabelEdit);
            this.listViewValues.DoubleClick += new System.EventHandler(this.listViewValues_DoubleClick);
            this.listViewValues.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewValues_KeyDown);
            // 
            // columnValues
            // 
            resources.ApplyResources(this.columnValues, "columnValues");
            // 
            // folderBrowserDialog
            // 
            resources.ApplyResources(this.folderBrowserDialog, "folderBrowserDialog");
            // 
            // toolStrip
            // 
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLoadUser,
            this.toolStripButtonLoadSystem,
            this.toolStripButtonApplyUser,
            this.toolStripApplySystem,
            this.toolStripSeparator1,
            this.toolStripButtonLoadFile,
            this.toolStripButtonExportFile,
            this.toolStripSeparator2,
            this.toolStripButtonAbout,
            this.toolStripButtonExit});
            this.toolStrip.Name = "toolStrip";
            this.toolTipButtons.SetToolTip(this.toolStrip, resources.GetString("toolStrip.ToolTip"));            // 
            // toolStripButtonLoadUser
            // 
            resources.ApplyResources(this.toolStripButtonLoadUser, "toolStripButtonLoadUser");
            this.toolStripButtonLoadUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLoadUser.Name = "toolStripButtonLoadUser";
            this.toolStripButtonLoadUser.Click += new System.EventHandler(this.toolStripButtonLoadUser_Click);
            // 
            // toolStripButtonLoadSystem
            // 
            resources.ApplyResources(this.toolStripButtonLoadSystem, "toolStripButtonLoadSystem");
            this.toolStripButtonLoadSystem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLoadSystem.Name = "toolStripButtonLoadSystem";
            this.toolStripButtonLoadSystem.Click += new System.EventHandler(this.toolStripButtonLoadSystem_Click);
            // 
            // toolStripButtonApplyUser
            // 
            resources.ApplyResources(this.toolStripButtonApplyUser, "toolStripButtonApplyUser");
            this.toolStripButtonApplyUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonApplyUser.Name = "toolStripButtonApplyUser";
            this.toolStripButtonApplyUser.Click += new System.EventHandler(this.toolStripButtonApplyUser_Click);
            // 
            // toolStripApplySystem
            // 
            resources.ApplyResources(this.toolStripApplySystem, "toolStripApplySystem");
            this.toolStripApplySystem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripApplySystem.Name = "toolStripApplySystem";
            this.toolStripApplySystem.Click += new System.EventHandler(this.toolStripApplySystem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolStripButtonLoadFile
            // 
            resources.ApplyResources(this.toolStripButtonLoadFile, "toolStripButtonLoadFile");
            this.toolStripButtonLoadFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLoadFile.Name = "toolStripButtonLoadFile";
            this.toolStripButtonLoadFile.Click += new System.EventHandler(this.toolStripButtonLoadFile_Click);
            // 
            // toolStripButtonExportFile
            // 
            resources.ApplyResources(this.toolStripButtonExportFile, "toolStripButtonExportFile");
            this.toolStripButtonExportFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExportFile.Name = "toolStripButtonExportFile";
            this.toolStripButtonExportFile.Click += new System.EventHandler(this.toolStripButtonExportFile_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // toolStripButtonAbout
            // 
            resources.ApplyResources(this.toolStripButtonAbout, "toolStripButtonAbout");
            this.toolStripButtonAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAbout.Name = "toolStripButtonAbout";
            this.toolStripButtonAbout.Click += new System.EventHandler(this.toolStripButtonAbout_Click);
            // 
            // toolStripButtonExit
            // 
            resources.ApplyResources(this.toolStripButtonExit, "toolStripButtonExit");
            this.toolStripButtonExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExit.Name = "toolStripButtonExit";
            this.toolStripButtonExit.Click += new System.EventHandler(this.toolStripButtonExit_Click);
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Name = "statusStrip";
            this.toolTipButtons.SetToolTip(this.statusStrip, resources.GetString("statusStrip.ToolTip"));
            // 
            // toolStripStatusLabel
            // 
            resources.ApplyResources(this.toolStripStatusLabel, "toolStripStatusLabel");
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            // 
            // buttonAddDirectory
            // 
            resources.ApplyResources(this.buttonAddDirectory, "buttonAddDirectory");
            this.buttonAddDirectory.FlatAppearance.BorderSize = 0;
            this.buttonAddDirectory.Image = global::Heteroauxin.Properties.Resources.folder_Closed_16xLG;
            this.buttonAddDirectory.Name = "buttonAddDirectory";
            this.toolTipButtons.SetToolTip(this.buttonAddDirectory, resources.GetString("buttonAddDirectory.ToolTip"));
            this.buttonAddDirectory.UseVisualStyleBackColor = true;
            this.buttonAddDirectory.Click += new System.EventHandler(this.buttonDirectory_Click);
            // 
            // buttonDeleteValue
            // 
            resources.ApplyResources(this.buttonDeleteValue, "buttonDeleteValue");
            this.buttonDeleteValue.FlatAppearance.BorderSize = 0;
            this.buttonDeleteValue.Image = global::Heteroauxin.Properties.Resources.action_minus_16xLG;
            this.buttonDeleteValue.Name = "buttonDeleteValue";
            this.toolTipButtons.SetToolTip(this.buttonDeleteValue, resources.GetString("buttonDeleteValue.ToolTip"));
            this.buttonDeleteValue.UseVisualStyleBackColor = true;
            this.buttonDeleteValue.Click += new System.EventHandler(this.buttonDeleteValue_Click);
            // 
            // buttonAddValue
            // 
            resources.ApplyResources(this.buttonAddValue, "buttonAddValue");
            this.buttonAddValue.FlatAppearance.BorderSize = 0;
            this.buttonAddValue.Name = "buttonAddValue";
            this.toolTipButtons.SetToolTip(this.buttonAddValue, resources.GetString("buttonAddValue.ToolTip"));
            this.buttonAddValue.UseVisualStyleBackColor = true;
            this.buttonAddValue.Click += new System.EventHandler(this.buttonAddValue_Click);
            // 
            // buttonDeleteVariable
            // 
            resources.ApplyResources(this.buttonDeleteVariable, "buttonDeleteVariable");
            this.buttonDeleteVariable.FlatAppearance.BorderSize = 0;
            this.buttonDeleteVariable.Image = global::Heteroauxin.Properties.Resources.action_minus_16xLG;
            this.buttonDeleteVariable.Name = "buttonDeleteVariable";
            this.toolTipButtons.SetToolTip(this.buttonDeleteVariable, resources.GetString("buttonDeleteVariable.ToolTip"));
            this.buttonDeleteVariable.UseVisualStyleBackColor = true;
            this.buttonDeleteVariable.Click += new System.EventHandler(this.buttonDeleteVariable_Click);
            // 
            // buttonAddVariable
            // 
            resources.ApplyResources(this.buttonAddVariable, "buttonAddVariable");
            this.buttonAddVariable.FlatAppearance.BorderSize = 0;
            this.buttonAddVariable.Name = "buttonAddVariable";
            this.toolTipButtons.SetToolTip(this.buttonAddVariable, resources.GetString("buttonAddVariable.ToolTip"));
            this.buttonAddVariable.UseVisualStyleBackColor = true;
            this.buttonAddVariable.Click += new System.EventHandler(this.buttonAddVariable_Click);
            // 
            // buttonValidateDirectory
            // 
            resources.ApplyResources(this.buttonValidateDirectory, "buttonValidateDirectory");
            this.buttonValidateDirectory.FlatAppearance.BorderSize = 0;
            this.buttonValidateDirectory.Image = global::Heteroauxin.Properties.Resources.LightBulb_16xLG;
            this.buttonValidateDirectory.Name = "buttonValidateDirectory";
            this.toolTipButtons.SetToolTip(this.buttonValidateDirectory, resources.GetString("buttonValidateDirectory.ToolTip"));
            this.buttonValidateDirectory.UseVisualStyleBackColor = true;
            this.buttonValidateDirectory.Click += new System.EventHandler(this.buttonValidateDirectory_Click);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonValidateDirectory);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.buttonAddDirectory);
            this.Controls.Add(this.buttonDeleteValue);
            this.Controls.Add(this.buttonAddValue);
            this.Controls.Add(this.buttonDeleteVariable);
            this.Controls.Add(this.buttonAddVariable);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.listViewValues);
            this.Controls.Add(this.listViewVariables);
            this.Controls.Add(this.checkBoxMatchCase);
            this.Controls.Add(this.textBoxFilter);
            this.Name = "FormMain";
            this.toolTipButtons.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.formMain_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.CheckBox checkBoxMatchCase;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ListView listViewVariables;
        private System.Windows.Forms.ColumnHeader columnVariables;
        private System.Windows.Forms.ListView listViewValues;
        private System.Windows.Forms.ColumnHeader columnValues;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadUser;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadSystem;
        private System.Windows.Forms.ToolStripButton toolStripButtonApplyUser;
        private System.Windows.Forms.ToolStripButton toolStripApplySystem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadFile;
        private System.Windows.Forms.ToolStripButton toolStripButtonExportFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonExit;
        private System.Windows.Forms.ToolStripButton toolStripButtonAbout;
        private System.Windows.Forms.Button buttonAddVariable;
        private System.Windows.Forms.Button buttonDeleteVariable;
        private System.Windows.Forms.Button buttonAddValue;
        private System.Windows.Forms.Button buttonDeleteValue;
        private System.Windows.Forms.Button buttonAddDirectory;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Button buttonValidateDirectory;
        private System.Windows.Forms.ToolTip toolTipButtons;
    }
}

