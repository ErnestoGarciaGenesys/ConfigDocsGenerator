using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CfgDoc.CfgObjects;
using CfgDoc.Properties;


namespace CfgDoc.Output.Html
{
    class HtmlOutput : ICfgOutput
    {
        public HtmlSettings Settings = new HtmlSettings();

        private CfgSystem system;

        IDictionary<string, object> replacements;
        Regex variableRegex = new Regex(@"\$\w+");


        public void Generate(CfgSystem system)
        {
            this.system = system;

            bool outputFolderOk = checkAndConfirmOutputFolder(Settings.OutputPath);
            if (outputFolderOk)
                doGenerate();
        }

        private bool checkAndConfirmOutputFolder(string path)
        {
            bool result = false;

            if (Directory.Exists(Settings.OutputPath))
            {
                DialogResult folderConfirmed = MessageBox.Show(
                    "Files inside the folder will be overwritten (" +
                    Settings.OutputPath + ").\n" +
                    "Do you want to continue?",
                    "Warning!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (folderConfirmed == DialogResult.Yes)
                {
                    result = true;
                }
            }
            else
            {
                DialogResult createDir = MessageBox.Show(
                    "Output folder does not exist (" +
                    Settings.OutputPath + ").\n" +
                    "Do you want the folder to be created?",
                    "Output folder",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (createDir == DialogResult.Yes)
                {
                    bool createDirSuccess = true;

                    try
                    {
                        Directory.CreateDirectory(Settings.OutputPath);

                    }
                    catch (IOException) { createDirSuccess = false; }
                    catch (ArgumentException) { createDirSuccess = false; }
                    catch (NotSupportedException) { createDirSuccess = false; }

                    if (createDirSuccess)
                    {
                        result = true;
                    }
                    else
                    {
                        MessageBox.Show(
                                "Folder cannot be created (" +
                                Settings.OutputPath + ").",
                                "Create Folder",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return result;
        }

        private void doGenerate()
        {
            File.WriteAllText(
                Settings.OutputPath + "\\gencfg.css", 
                Resources.css, 
                Encoding.GetEncoding(1252));

            using (StreamWriter writer =
                    new StreamWriter(Settings.OutputPath + "\\gencfg.htm",
                        false, Encoding.GetEncoding(1252)))
            {
                IDictionary<string, object> globalReplacements = new Dictionary<string, object>();
                globalReplacements.Add("$Company", Settings.CompanyName);
                globalReplacements.Add("$Description", Settings.Description);
                globalReplacements.Add("$Author", Settings.AuthorName);
                globalReplacements.Add("$ProjectID", Settings.ProjectId);
                globalReplacements.Add("$Date", DateTime.Now.ToString());
                globalReplacements.Add("$Gather_date", system.GatheredDate);
                writer.Write(replaceVariables(Resources.html_start, globalReplacements));

                writer.Write(Resources.host_start);

                int row = 0;
                IDictionary<string, object> hostReplacements = new Dictionary<string, object>();
                foreach (CfgHost host in system.Hosts)
                {
                    hostReplacements["$host_dbid"] = host.Dbid;
                    hostReplacements["$host_name"] = host.Name;
                    hostReplacements["$host_os_type"] = host.OsType;
                    hostReplacements["$host_os_version"] = host.OsVersion;
                    hostReplacements["$host_ip_address"] = host.IpAddress;
                    hostReplacements["$host_lca_port"] = host.LcaPort;
                    hostReplacements["$class"] = row % 2 == 0 ? "w" : "g";
                    writer.Write(replaceVariables(Resources.host, hostReplacements));
                    row++;
                }
                writer.Write(Resources.host_end);
                writer.Write(Resources.html_end);
            }
            
            MessageBox.Show("Generated.", "Generated.",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string replaceVariables(string input, IDictionary<string, object> replacements)
        {
            this.replacements = replacements;
            return variableRegex.Replace(input, matchEvaluator);
        }

        private string matchEvaluator(Match m)
        {
            object replacement = replacements[m.Value];
            return ReferenceEquals(replacement, null) ? "" : replacement.ToString();
        }
    }
}
