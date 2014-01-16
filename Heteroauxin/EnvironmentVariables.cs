using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Heteroauxin
{
    class EnvironmentVariables
    {
        private IDictionary variables;
        private List<string> variableList;
        private string errorMsg;

        public EnvironmentVariableTarget CurrentTarget;
        public List<string> VariableList
        {
            get
            {
                variableList.Clear();
                foreach (var va in variables.Keys)
                {
                    variableList.Add(va.ToString());
                }
                return variableList;
            }
        }

        public EnvironmentVariables(EnvironmentVariableTarget target = EnvironmentVariableTarget.Process)
        {
            CurrentTarget = target;
            variableList = new List<string>();
            errorMsg = "Unknown";
        }

        public bool LoadVariables()
        {
            try
            {
                variables = Environment.GetEnvironmentVariables(CurrentTarget);
            }
            catch (SecurityException se)
            {
                errorMsg = se.Message;
                return false;
            }
            return true;
        }

        public string GetLastError()
        {
            return errorMsg;
        }

        public bool AddVariable(string name, string value)
        {
            variables.Add(name, value);
            return true;
        }

        public bool AddVariable(string name, List<string> valueList)
        {
            string value = String.Join(";", valueList);
            variables.Add(name, value);
            return true;
        }

        public bool DeleteVariable(string name)
        {
            if (!variables.Contains(name)) return false;
            variables[name] = String.Empty;
            return true;
        }

        public bool EditVariableValue(string name, string newValue)
        {
            if (!variables.Contains(name)) return false;
            variables[name] = newValue;
            return true;
        }

        public bool EditVariableValue(string name, List<string> newValueList)
        {
            if (!variables.Contains(name)) return false;
            string value = String.Join(";", newValueList);
            variables[name] = value;
            return true;
        }

        public bool EditVariableName(string oldName, string newName, List<string> valueList)
        {
            if (!variables.Contains(oldName)) return false;
            variables.Remove(oldName);
            var value = String.Join(";", valueList);
            variables.Add(newName, value);
            return true;
        }

        /// <summary>
        /// Add a new value item. Value items are separated by ;
        /// </summary>
        /// <param name="name">The variable name</param>
        /// <param name="newValue">The new value to be added</param>
        /// <returns>Returns whether the action is successful</returns>
        public bool AddValueItem(string name, string newValue)
        {
            if (!variables.Contains(name)) return false;
            string originalValue = variables[name].ToString();
            if (String.IsNullOrEmpty(originalValue))
            {
                variables[name] = newValue;
            }
            else if (!originalValue.EndsWith(";"))
            {
                newValue = ";" + newValue;
                variables[name] = variables[name] + newValue;
            }
            return true;
        }

        /// <summary>
        /// Delete a value item. Value items are separated by ;
        /// </summary>
        /// <param name="name">The variable name</param>
        /// <param name="value">The value item to be deleted</param>
        /// <returns></returns>
        public bool DeleteValueItem(string name, string value)
        {
            if (!variables.Contains(name)) return false;
            string originalValue = variables[name].ToString();
            string newValue = originalValue.Replace(value, String.Empty);
            variables[name] = newValue;
            return true;
        }

        /// <summary>
        /// Export environment variables to a text file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Returns whether the action is successful</returns>
        public bool ExportToFile(string fileName)
        {
            if (variables == null) return false;
            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                foreach (var key in variables.Keys)
                {
                    string line = String.Format("{0}={1}", key, variables[key]);
                    streamWriter.WriteLine(line);
                }
                streamWriter.Close();
                fileStream.Close();
            }
            catch (Exception e)
            {
                // TODO Deal with file exceptions
                return false;
            }
            return true;
        }
        /// <summary>
        /// Load evnvironment variables from a text file
        /// </summary>
        /// <param name="fileName">The file name of the text file</param>
        /// <returns>Returns whether the action is successful</returns>
        public bool LoadFromFile(string fileName)
        {
            variables.Clear();
            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Open);
                StreamReader streamReader = new StreamReader(fileStream);
                while (streamReader.Peek() > 0)
                {
                    var line = streamReader.ReadLine();
                    string[] entry = line.Split('=');
                    if (entry.Length < 2) return false; // Parsing error
                    variables.Add(entry[0], entry[1]);
                }
                streamReader.Close();
                fileStream.Close();
                CurrentTarget = EnvironmentVariableTarget.Process;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Clear all the variables stored in this class
        /// </summary>
        public void Clear()
        {
            variables.Clear();
            variableList.Clear();
        }

        /// <summary>
        /// Get the value of a specific variable
        /// </summary>
        /// <param name="name">The name of the variable</param>
        /// <returns>The value of the variable</returns>
        public string GetValue(string name)
        {
            return variables.Contains(name) ? variables[name].ToString() : null;
        }

        /// <summary>
        /// Check whether the class is storing any variables
        /// </summary>
        /// <returns>Returns whether the class is empty (not storing variables)</returns>
        public bool IsNullOrEmpty()
        {
            if (variables == null) return true;
            if (variables.Count <= 0) return true;
            return false;
        }

        /// <summary>
        /// Apply changes to environment variables
        /// </summary>
        /// <param name="variableTarget">The target of the environment variables</param>
        /// <returns>Returns whether the action is successful</returns>
        public bool ApplyEnvironmentVariables(EnvironmentVariableTarget variableTarget)
        {
            if (variableList.Count < 0)
            {
                // Throw exceptions
                return false;
            }
            try
            {
                RegistryKey regKey = null;
                switch (CurrentTarget)
                {
                    case EnvironmentVariableTarget.Machine:
                        regKey = Registry.LocalMachine.OpenSubKey(
                            @"System\CurrentControlSet\Control\Session Manager\Environment", true);
                        break;
                    case EnvironmentVariableTarget.User:
                        regKey = Registry.CurrentUser.OpenSubKey(@"Environment", true);
                        break;
                }
                foreach (var name in variables.Keys)
                {
                    string variable = name.ToString();
                    string value = variables[name].ToString();
                    if (regKey != null)
                    {
                        if (String.IsNullOrEmpty(value))
                        {
                            regKey.DeleteSubKey(variable, false);
                        }
                        else
                        {
                            regKey.SetValue(variable, value);
                        }
                        regKey.Close();
                    }
                    else return false;
                }
                
            }
            catch (SecurityException se)
            {
                errorMsg = se.Message;
                return false;
            }
            catch (ArgumentException ae)
            {
                errorMsg = ae.Message;
                return false;
            }
            return true;
        }
    }
}
