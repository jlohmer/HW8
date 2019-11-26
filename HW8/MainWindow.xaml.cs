using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace HW8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Select_Directory_Click(object sender, RoutedEventArgs e)
        {
            
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = false;
            DialogResult result = dialog.ShowDialog();

           

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtFolderPath.Text = dialog.SelectedPath;
                btn_Populate_Files.IsEnabled = true;
            }
        }

        private void Populate_Files_Click(object sender, RoutedEventArgs e)
        {
            // Source: https://stackoverflow.com/questions/3152157/find-a-file-with-a-certain-extension-in-folder/3152180
            string path = txtFolderPath.Text;
            if (Directory.Exists(path) == true)
            {
                string[] files = System.IO.Directory.GetFiles(path, "*.csv");

                foreach (var file in files)
                {
                    lstFiles.Items.Add(file);
                }
                btn_Run_Analysis.IsEnabled = true;
            }
            else
            {
                System.Windows.MessageBox.Show("Must select a valid directory first.");
            }

 
            //Add all the *.csv files to the listbox
        }

        private void btn_Run_Analysis_Click(object sender, RoutedEventArgs e)
        {
            if (lstFiles.SelectedValue != null)
            {
                string selectedFile = lstFiles.SelectedValue.ToString();

                var lines = File.ReadAllLines(selectedFile).Skip(1);

                foreach (var line in lines)
                {
                    var pieces = line.Split(',');
                    Student stud = new Student()
                    {
                        FirstName = pieces[0],
                        LastName = pieces[1],
                        SoonerID = pieces[2],
                        FourByFour = pieces[3],
                        Email = pieces[4],
                        ResidentStatus = pieces[5],
                        Level = pieces[6],
                        RegistrationDate = pieces[7]
                    };

                    for (int i = 8; i < 13; i++)
                    {
                        if(pieces[i].ToUpper().Contains("MINOR") == true)
                        {
                            stud.ProgramCodes["MINOR"].Add(pieces[i]);
                        }
                        else
                        {
                            stud.ProgramCodes["MAJOR"].Add(pieces[i]);
                        }
                    }
                    string s = line;
                }
            }
        }
    }

}
