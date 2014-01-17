using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Heteroauxin.Properties;

namespace Heteroauxin
{
    public partial class FormMain : Form
    {
        private EnvironmentVariables envVariables;
        private AboutBox aboutBox;
        private bool isNewValue;
        private bool isNewVariable;
        private bool isSaved;

        public FormMain()
        {
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
            InitializeComponent();

            envVariables = new EnvironmentVariables();
            aboutBox = new AboutBox();
            isNewValue = false;
            isNewVariable = false;
            isSaved = true;
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            listViewVariables.Columns[0].Width = listViewVariables.Width - 24;
            listViewValues.Columns[0].Width = listViewValues.Width - 10;
            textBoxFilter.Font = new Font(textBoxFilter.Font, FontStyle.Italic);
            textBoxFilter.ForeColor = Color.Gray;
            listViewVariables.Select();
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxFilter.Focused) return;
            MatchFilter();
            if (listViewVariables.Items.Count <= 0)
                listViewValues.Items.Clear();
        }

        private void MatchFilter()
        {
            if (envVariables == null) return;
            if (envVariables.IsNullOrEmpty()) return;

            if (!String.IsNullOrEmpty(textBoxFilter.Text))
            {
                listViewVariables.Items.Clear();
                var pattern = checkBoxMatchCase.Checked ?
                    new Regex(textBoxFilter.Text) :
                    new Regex(textBoxFilter.Text, RegexOptions.IgnoreCase);
                foreach (var name in envVariables.VariableList.Where(name => pattern.IsMatch(name)))
                {
                    listViewVariables.Items.Add(name);
                }
            }
            else
            {
                listViewVariables.Items.Clear();
                foreach (var name in envVariables.VariableList)
                {
                    listViewVariables.Items.Add(name);
                }
            }
        }
        private void textBoxFilter_Enter(object sender, EventArgs e)
        {
            if (textBoxFilter.Text == Resources.FormMain_textBoxFilter_Enter_Filter)
            {
                textBoxFilter.Text = String.Empty;
                textBoxFilter.Font = new Font(textBoxFilter.Font, FontStyle.Regular);
                textBoxFilter.ForeColor = Color.Black;
            }
        }

        private void textBoxFilter_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxFilter.Text))
            {
                textBoxFilter.Font = new Font(textBoxFilter.Font, FontStyle.Italic);
                textBoxFilter.ForeColor = Color.Gray;
                textBoxFilter.Text = Resources.FormMain_textBoxFilter_Enter_Filter;
            }
        }

        private void checkBoxMatchCase_CheckedChanged(object sender, EventArgs e)
        {
            MatchFilter();
        }

        private void UpdateValueListView(string name)
        {
            listViewValues.Items.Clear();
            string value = envVariables.GetValue(name);
            if (value == null) return;
            string[] valueArray = value.Split(';');
            foreach (var s in valueArray)
            {
                if (!String.IsNullOrEmpty(s))
                {
                    listViewValues.Items.Add(s);
                }
                listViewValues.Sort();
            }
        }
        private void listViewVariables_Click(object sender, EventArgs e)
        {
            if (listViewVariables.Items.Count <= 0)
                return;
            if (listViewVariables.SelectedItems.Count > 1)
            {
                listViewValues.Clear();
                return;
            }
            listViewValues.Items.Clear();
            string name = listViewVariables.SelectedItems[0].SubItems[0].Text;
            UpdateValueListView(name);
        }

        private void listViewVariables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                buttonDeleteValue_Click(buttonDeleteValue, null);
            }
        }

        private void listViewVariables_DoubleClick(object sender, EventArgs e)
        {
            listViewVariables.SelectedItems[0].BeginEdit();
        }

        private void listViewValues_DoubleClick(object sender, EventArgs e)
        {
            listViewValues.SelectedItems[0].BeginEdit();
        }

        private void listViewValues_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (String.IsNullOrEmpty(e.Label))
            {
                e.CancelEdit = true;
                return;
            }

            if (listViewVariables.SelectedItems.Count <= 0)
            {
                
            }
            string name = listViewVariables.SelectedItems[0].Text;
            if (isNewValue)
            {
                envVariables.AddValueItem(name, e.Label);
                isNewValue = false;
                e.CancelEdit = true;
            }
            else
            {
                string originalValue = envVariables.GetValue(name);
                string selectedValue = listViewValues.SelectedItems[0].Text;
                string newValue = originalValue.Replace(selectedValue, e.Label);
                envVariables.EditVariableValue(name, newValue);
            }
            UpdateValueListView(name);
            isSaved = false;
        }

        private void listViewVariables_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (String.IsNullOrEmpty(e.Label))
            {
                e.CancelEdit = true;
                return;
            }
            if (isNewVariable)
            {
                listViewValues.Items.Clear();
                envVariables.AddVariable(e.Label, String.Empty);
                isNewVariable = false;
                e.CancelEdit = true;
            }
            else
            {
                var valueList = (from ListViewItem item in listViewValues.Items select item.Text).ToList();
                envVariables.EditVariableName(listViewVariables.SelectedItems[0].Text, e.Label, valueList);
            }
            UpdateVariablesListView();
            isSaved = false;
        }

        private void buttonDirectory_Click(object sender, EventArgs e)
        {
            if (listViewVariables.SelectedItems.Count <= 0)
            {
                MessageBox.Show(
                    Properties.Resources.FormMain_buttonDirectory_Choose_left,
                    Properties.Resources.MessageBox_Caution,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.Cancel) return;

            string dir = folderBrowserDialog.SelectedPath;
            string name = listViewVariables.SelectedItems[0].Text;
            envVariables.AddValueItem(name, dir);
            UpdateValueListView(name);
            isSaved = false;
        }

        private void listViewValues_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var result = MessageBox.Show(
                    Properties.Resources.MessageBox_Confirm_Delete,
                    Properties.Resources.MessageBox_Warning,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.No) return;

                string name = listViewVariables.SelectedItems[0].Text;
                ListView.SelectedListViewItemCollection selectedItems = listViewValues.SelectedItems;
                foreach (ListViewItem item in selectedItems)
                {
                    envVariables.DeleteValueItem(name, item.Text);
                    listViewValues.Items.Remove(item);
                }
                isSaved = false;
            }
        }

        private void toolStripButtonLoadUser_Click(object sender, EventArgs e)
        {
            if (!isSaved)
            {
                var result = MessageBox.Show(
                    Properties.Resources.MessageBox_Unsaved_User,
                    Properties.Resources.MessageBox_Warning,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;
            }

            envVariables = new EnvironmentVariables(EnvironmentVariableTarget.User);
            if (!envVariables.LoadVariables())
            {
                MessageBox.Show(
                    Properties.Resources.MessageBox_Fail_Load_User,
                    Properties.Resources.MessageBox_Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                return;
            }
            listViewValues.Items.Clear();
            UpdateVariablesListView();
        }

        private void toolStripButtonLoadSystem_Click(object sender, EventArgs e)
        {
            if (!isSaved)
            {
                var result = MessageBox.Show(
                    Properties.Resources.MessageBox_Unsaved_System,
                    Properties.Resources.MessageBox_Caution,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;  
            }
            envVariables = new EnvironmentVariables(EnvironmentVariableTarget.Machine);
            if (!envVariables.LoadVariables())
            {
                MessageBox.Show(
                    Properties.Resources.MessageBox_Failed_Load_System,
                    Properties.Resources.MessageBox_Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            listViewValues.Items.Clear();
            UpdateVariablesListView();
        }

        private void UpdateVariablesListView()
        {
            listViewVariables.Items.Clear();
            foreach (var va in envVariables.VariableList)
            {
                listViewVariables.Items.Add(va);
            }
        }


        private void toolStripButtonApplyUser_Click(object sender, EventArgs e)
        {
            if (listViewVariables.Items.Count <= 0) return;
            DialogResult result;

            if (envVariables.CurrentTarget != EnvironmentVariableTarget.User)
            {
                result = MessageBox.Show(
                    Properties.Resources.MessageBox_Not_User,
                    Properties.Resources.MessageBox_Caution,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.No) return;
            }

            result = MessageBox.Show(
                Properties.Resources.MessageBox_Apply_User,
                Properties.Resources.MessageBox_Warning,
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.No) return;

            toolStripStatusLabel.Text = Properties.Resources.StatusLabel_Appying_User;
            bool isSuccess = envVariables.ApplyEnvironmentVariables(EnvironmentVariableTarget.User);
            if (isSuccess)
            {
                toolStripStatusLabel.Text = Properties.Resources.StatusLabel_Apply_User_Successful;
                isSaved = true;
            }
            else
            {
                MessageBox.Show(
                    Properties.Resources.MessageBox_Failed_Apply,
                    Properties.Resources.MessageBox_Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripApplySystem_Click(object sender, EventArgs e)
        {
            if (listViewVariables.Items.Count <= 0) return;
            DialogResult result = MessageBox.Show(
                Properties.Resources.MessageBox_Apply_System,
                Properties.Resources.MessageBox_Warning,
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.No) return;

            bool isSuccess = envVariables.ApplyEnvironmentVariables(EnvironmentVariableTarget.Machine);
            if (isSuccess)
            {
                toolStripStatusLabel.Text = Properties.Resources.StatusLabel_Apply_User_Successful;
                isSaved = true;
            }
            else
            {
                MessageBox.Show(
                    Properties.Resources.MessageBox_Failed_Apply,
                    Properties.Resources.MessageBox_Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonLoadFile_Click(object sender, EventArgs e)
        {
            DialogResult result;
            if (!isSaved)
            {
                result = MessageBox.Show(
                    Properties.Resources.MessageBox_Unsaved_New,
                    Properties.Resources.MessageBox_Caution,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.No) return;
            }
            result = openFileDialog.ShowDialog();
            if (result == DialogResult.Cancel) return;
            bool isSuccess = envVariables.LoadFromFile(openFileDialog.FileName);
            if (!isSuccess)
            {
                MessageBox.Show(Properties.Resources.MessageBox_Failed_Load_File,
                    Properties.Resources.MessageBox_Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            listViewValues.Items.Clear();
            UpdateVariablesListView();
        }

        private void toolStripButtonExportFile_Click(object sender, EventArgs e)
        {
            if (envVariables.IsNullOrEmpty())
            {
                MessageBox.Show(Properties.Resources.MessageBox_Nothing_Save);
                return;
            }

            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.Cancel) return;
            bool isSuccess = envVariables.ExportToFile(saveFileDialog.FileName);
            if (!isSuccess)
            {
                MessageBox.Show(Properties.Resources.MessageBox_Failed_Export,
                    Properties.Resources.MessageBox_Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                isSaved = true;
            }
        }

        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            if (!isSaved)
            {
                var result = MessageBox.Show(
                    Properties.Resources.MessageBox_Unsaved_Exit,
                    Properties.Resources.MessageBox_Warning,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;  
            }
            Application.Exit();
        }

        private void toolStripButtonAbout_Click(object sender, EventArgs e)
        {
            aboutBox.Show();
        }

        private void buttonAddVariable_Click(object sender, EventArgs e)
        {
            if (envVariables.IsNullOrEmpty())
            {
                MessageBox.Show(Properties.Resources.MessageBox_Not_Loaded,
                    Properties.Resources.MessageBox_Caution,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (isNewVariable)
            {
                MessageBox.Show(Properties.Resources.MessageBox_Already_New);
                return;
            }
            isNewVariable = true;
            listViewVariables.Items.Add(" (New variable)");
            /* For the next line, it is not appropriate to assume the " (New variable)" is the first item in the
             * ListView. However, I added a [space] at the beginning of the string. Since the space is the
             * first printable ASCII character. Usually the " (New variable)" should appear on the top of the
             * ListView. The same thing applies to buttonAddValue_Click function
             */
            listViewVariables.Items[0].BeginEdit();
        }

        private void buttonDeleteVariable_Click(object sender, EventArgs e)
        {
            if (listViewVariables.SelectedItems.Count <= 0) return;
            DialogResult result = MessageBox.Show(
                    "Do you really want to delete the selected environment variable(s)?",
                    Properties.Resources.MessageBox_Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;
            ListView.SelectedListViewItemCollection selectedItems= listViewVariables.SelectedItems;
            foreach (ListViewItem item in selectedItems)
            {
                envVariables.DeleteVariable(item.Text);
                listViewVariables.Items.Remove(item);
            }
            listViewValues.Items.Clear();
        }

        private void buttonDeleteValue_Click(object sender, EventArgs e)
        {
            if (listViewValues.SelectedItems.Count <= 0) return;
            DialogResult result = MessageBox.Show(
                    "Do you really want to delete the selected environment value(s)?",
                    Properties.Resources.MessageBox_Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;
            string name = listViewVariables.SelectedItems[0].Text;
            ListView.SelectedListViewItemCollection selectedItems = listViewValues.SelectedItems;
            foreach (ListViewItem item in selectedItems)
            {
                envVariables.DeleteValueItem(name, item.Text);
                listViewValues.Items.Remove(item);
            }
            isSaved = false;
        }

        private void buttonAddValue_Click(object sender, EventArgs e)
        {
            if (envVariables.IsNullOrEmpty())
            {
                MessageBox.Show(Properties.Resources.MessageBox_Not_Loaded, "Caution",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (listViewVariables.Items.Count <= 0 || listViewVariables.SelectedItems.Count <= 0)
            {
                MessageBox.Show(Properties.Resources.FormMain_buttonDirectory_Choose_left);
                return;
            }
            if (isNewValue)
            {
                MessageBox.Show("You have added a new value. You cannot add more before you set its value.");
            }
            isNewValue = true;
            listViewValues.Items.Add(" (New value)");
            listViewValues.Items[0].BeginEdit();
        }

        private void buttonValidateDirectory_Click(object sender, EventArgs e)
        {
            // TODO
            /*
             * Obviously, most values are not valid directories. They are not directories at all.
             * So this function need to be amended.
             */
            if (listViewValues.Items.Count <= 0) return;

            bool isValid = true;
            foreach (ListViewItem item in listViewValues.Items)
            {
                string str = item.Text;
                if (!Directory.Exists(str))
                {
                    listViewValues.Items[item.Index].BackColor = Color.Yellow;
                    isValid = false;
                }
            }
            if (isValid)
            {
                toolStripStatusLabel.Text = Properties.Resources.StatusLabel_Is_Valid;
            }
            else
            {
                toolStripStatusLabel.Text = Properties.Resources.StatusLabel_Not_Valid;
            }
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
