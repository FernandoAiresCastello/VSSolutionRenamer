using Microsoft.VisualBasic;
using Microsoft.VisualBasic.MyServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSSolutionRenamer
{
    public partial class MainWindow : Form
    {
        private readonly FileSystemProxy FileSystem = new Microsoft.VisualBasic.Devices.Computer().FileSystem;

        private const string LangCSharp = "C#";

        public MainWindow()
        {
            InitializeComponent();
            InitializeLanguagesCombo();
        }

        private void InitializeLanguagesCombo()
        {
            CmbLanguage.SelectedIndexChanged += CmbLanguage_SelectedIndexChanged;
            CmbLanguage.Items.Add(LangCSharp);
            CmbLanguage.SelectedIndex = 0;
        }

        private void CmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string language = (string)CmbLanguage.SelectedItem;
            string pattern = "";

            switch (language)
            {
                case LangCSharp:
                    pattern = "*.cs";
                    break;
            }

            TxtFileSearchPattern.Text = pattern;
        }

        private void BtnSelectOld_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.MyComputer;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TxtOldPath.Text = dialog.SelectedPath;
            }
        }

        private void BtnRename_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(TxtOldPath.Text.Trim()))
            {
                RenameSolution();
                MessageBox.Show("The solution has been renamed successfully.", "Operation successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The original solution folder was not found.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Encoding GetFileEncoding(string filename)
        {
            var bom = new byte[4];

            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;

            return Encoding.Default;
        }

        private void RenameSolution()
        {
            string pathOld = TxtOldPath.Text.Trim().Replace('/', '\\');
            if (pathOld.EndsWith("\\"))
                pathOld = pathOld.Remove(pathOld.Length - 1, 1);

            string nameOld = pathOld.Split('\\').Last().Trim();
            string nameNew = TxtNew.Text.Trim();
            string pathNew = Path.Combine(pathOld.Substring(0, pathOld.LastIndexOf('\\')).Trim(), nameNew).Trim();

            bool cancel = false;

            if (Directory.Exists(pathNew))
            {
                DialogResult option = MessageBox.Show(
                    "Unable to create new solution folder, folder already exists.\nDo you wish to delete the existing folder?",
                    "Warning",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (option == DialogResult.OK)
                {
                    try
                    {
                        Directory.Delete(pathNew, true);
                    }
                    catch
                    {
                        cancel = true;
                        MessageBox.Show("Unable to delete folder. Folder is currently in use.", 
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    cancel = true;
            }

            if (!cancel)
            {
                DuplicateSolution(pathOld, pathNew);
                UpdateNewSolution(pathNew, nameNew, nameOld);
                UpdateNewMainProject(pathNew, nameNew, nameOld);
                CleanNewMainProject(pathNew, nameNew);

                string fileExt = TxtFileSearchPattern.Text.Trim();
                if (!string.IsNullOrWhiteSpace(fileExt))
                    UpdateFilesWithExtensions(pathNew, fileExt, nameOld, nameNew);
            }
        }

        private void DuplicateSolution(string pathOld, string pathNew)
        {
            Directory.CreateDirectory(pathNew);
            FileSystem.CopyDirectory(pathOld, pathNew);
        }

        private void UpdateNewSolution(string pathNew, string nameNew, string nameOld)
        {
            string oldSolutionFilePath = Path.Combine(pathNew, nameOld + ".sln");
            string newSolutionFileName = nameNew + ".sln";
            string newSolutionFilePath = Path.Combine(pathNew, newSolutionFileName);

            FileSystem.RenameFile(oldSolutionFilePath, newSolutionFileName);
            ReplaceInFile(newSolutionFilePath, nameOld, nameNew);

            string hiddenVsFolder = Path.Combine(pathNew, ".vs");
            Directory.Delete(hiddenVsFolder, true);
        }

        private void UpdateNewMainProject(string pathNew, string nameNew, string nameOld)
        {
            string oldProjectFolder = Path.Combine(pathNew, nameOld);
            string newProjectFolder = Path.Combine(pathNew, nameNew);
            FileSystem.RenameDirectory(oldProjectFolder, nameNew);

            string projectFileExt = "." + GetProjectFileExtensionByLanguage();

            string oldProjectFilePath = Path.Combine(pathNew, nameNew, nameOld + projectFileExt);
            string newProjectFileName = nameNew + projectFileExt;
            string newProjectFilePath = Path.Combine(newProjectFolder, newProjectFileName);
            FileSystem.RenameFile(oldProjectFilePath, newProjectFileName);
            
            ReplaceInFile(newProjectFilePath, nameOld, nameNew);
        }

        private string GetProjectFileExtensionByLanguage()
        {
            string language = (string)CmbLanguage.SelectedItem;
            string extension = "";

            switch (language)
            {
                case LangCSharp:
                    extension = "csproj";
                    break;
            }

            return extension;
        }

        private void CleanNewMainProject(string pathNew, string nameNew)
        {
            string newProjectFolder = Path.Combine(pathNew, nameNew);
            string binFolder = Path.Combine(newProjectFolder, "bin");
            string objFolder = Path.Combine(newProjectFolder, "obj");

            Directory.Delete(binFolder, true);
            Directory.Delete(objFolder, true);
        }

        private void ReplaceInFile(string file, string oldText, string newText)
        {
            Encoding encoding = GetFileEncoding(file);
            string oldContents = File.ReadAllText(file);
            string newContents = oldContents.Replace(oldText, newText);
            File.WriteAllText(file, newContents, encoding);
        }

        private void UpdateFilesWithExtensions(string pathNew, string fileExt, string nameOld, string nameNew)
        {
            try
            {
                var files = Directory.EnumerateFiles(pathNew, fileExt, SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    ReplaceInFile(file, nameOld, nameNew);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to update files with extensions " + fileExt + "\n\nError detail:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
