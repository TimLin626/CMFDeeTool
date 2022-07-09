using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using MessageBox = System.Windows.Forms.MessageBox;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace CMF.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private string newLine = Environment.NewLine;
        public string URL { get; set; }
        public string DeeResult { get; set; }
        public string ActionGroup { get; set; }
        public string ActionGroupPre { get; set; }
        public string ActionGroupPost { get; set; }
        public string UsingText { get; set; }
        public ObservableCollection<string> DllFilesName { get; set; } = new ObservableCollection<string>();
        public MainViewModel()
        {

        }

        public ICommand GenerateURLCommand => new RelayCommand(() =>
        {
            if (URL is null) return;
            char[] splitstring = { '/' };
            string[] urlsplit = URL.Split(splitstring);
            if (urlsplit.Length != 6)
            {
                MessageBox.Show("It's not a CMF URL");
                return;
            }
            string service = urlsplit[4];
            string operation = urlsplit[5];

            ActionGroupPre = $"{service}Management.{service}ManagementOrchestration.{operation}.Pre";
            ActionGroupPost = $"{service}Management.{service}ManagementOrchestration.{operation}.Post";
        });


        public ICommand InsertDllFilesCommand => new RelayCommand(() =>
        {
            // Set the file dialog to filter for graphics files.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter =
                "dll Files (*.dll;)|*.dll|" +
                "All files (*.*)|*.*";
            openFileDialog1.Multiselect = true;

            openFileDialog1.Title = "Select dll files to insert";

            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                DllFilesName.Clear();
                foreach (string file in openFileDialog1.FileNames)
                {
                    DllFilesName.Add(Path.GetFileName(file));
                }
            }
        });


        public ICommand GenerateDeeReferencesCommand => new RelayCommand(() =>
        {
            if(DllFilesName.Count == 0)
            {
                MessageBox.Show("No dll files inserted");
                return;
            }

            if(UsingText == null)
            {
                MessageBox.Show("No using line");
                return;
            }

            char[] splitstring = { ';' };
            char[] splitdot = { '.' };
            List<string> usingTexts = UsingText.Split(splitstring).ToList();
            usingTexts.RemoveAll(usingtext => usingtext == "" || usingtext == null);
            List<string> usingAssmbles = new List<string>();
            List<string> usingNamespace = new List<string>();
            List<string> dllfilenames = new List<string>(); ;
            foreach (string dllfileName in DllFilesName) dllfilenames.Add(Regex.Replace(dllfileName, ".dll", "").Trim());
            bool isaddcustmodll = false;
            foreach (string usingtext in usingTexts)
            {
                string namespaceString = Regex.Replace(usingtext, "using", "").Trim();
                usingNamespace.Add($"UseReference(\"\", \"{namespaceString}\");");
                if (namespaceString.Substring(0, 6) == "System") continue;
                while(true)
                {
                    //Normal
                    if (dllfilenames.Any(dllfilename => dllfilename == namespaceString))
                    {
                        string name = dllfilenames.Where(dllfilename => dllfilename == namespaceString).FirstOrDefault();
                        string usereferencedll = getdllreference(name);
                        if(!usingAssmbles.Contains(usereferencedll)) usingAssmbles.Add(usereferencedll);
                        break;
                    }
                    if (namespaceString.Contains(".")) 
                    {
                        //Erp
                        if (namespaceString.Substring(namespaceString.LastIndexOf(".")+1) == "Erp")
                        {
                            string usereferencedll = getdllreference("Cmf.Custom.BusinessObjects.ErpCustomManagement");
                            if (!usingAssmbles.Contains(usereferencedll)) usingAssmbles.Add(usereferencedll);
                            break;
                        }
                        //Customer
                        if (namespaceString.Contains("Cmf.Custom") && namespaceString.Contains("BusinessObjects"))
                        {
                            if (isaddcustmodll) break;
                            List<string> customdllname = dllfilenames.Where(dllfilename => dllfilename.Contains("Cmf.Custom.CriticalManufacturing.BusinessObjects.")).ToList();
                            foreach (string customdll in customdllname)
                            {
                                string usereferencedll = getdllreference(customdll);
                                if (!usingAssmbles.Contains(usereferencedll)) usingAssmbles.Add(usereferencedll);
                            }
                            isaddcustmodll = true;
                            break;
                        }
                        namespaceString = namespaceString.Substring(0, namespaceString.LastIndexOf("."));
                        continue;
                    }
                    else
                    {
                        MessageBox.Show($"Couldn't find any dll realted to {Regex.Replace(usingtext, "using", "")}");
                        return;
                    }
                }
            }
            DeeResult = "";
            DeeResult += "/**Using Assmbles**/" + newLine;
            foreach(string assmblename in usingAssmbles) DeeResult += assmblename + newLine;
            DeeResult += "/**Using NameSpace**/" + newLine;
            foreach (string namespacename in usingNamespace) DeeResult += namespacename + newLine;
        });

        private string getdllreference(string dllname)
        {
            return $"UseReference(\"{dllname}.dll\", \"\");";
        }
    }

    
}