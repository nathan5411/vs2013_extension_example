using Microsoft.VisualStudio.Shell;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using EnvDTE;

namespace Company.VSPackage1
{
    /// <summary>
    /// Interaction logic for MyControl.xaml
    /// </summary>
    public partial class MyControl : UserControl
    {
        
        private EnvDTE.DTE DTE;
        private LogManager manager;

        public MyControl()
        {
            InitializeComponent();

            // initialize member variable
            DTE = (EnvDTE.DTE)Microsoft.VisualStudio.Shell.ServiceProvider.GlobalProvider.GetService(typeof(EnvDTE.DTE));
            manager = new LogManager();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")]
        private void openFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            bool? result = dialog.ShowDialog();

            if (result.Value)
            {
                //analyze
                manager.Parse(dialog.FileName);

                //diaplay
                logView.ItemsSource = manager.getDisplayData();
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            manager.Clear();
            logView.ItemsSource = manager.getDisplayData();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")]
        private void search_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(searchText.Text))
            {
                manager.Reset();
            }
            else
            {
                bool success = manager.Search(searchText.Text);
                if (!success)
                {
                    MessageBox.Show("text not found.", "message");
                }
            }

            logView.ItemsSource = manager.getDisplayData();
        }

        /// <summary>
        /// find project item by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private ProjectItem find(string name)
        {
            ProjectItem result = null;

            foreach (Project project in DTE.Solution.Projects)
            {
                result = find(project.ProjectItems, name);

                if (result != null)
                {
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// recursive call projectitems until found
        /// </summary>
        /// <param name="projectItems"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private ProjectItem find( ProjectItems projectItems, string name)
        {
            ProjectItem result = null;

            if ( projectItems.Count == 0 )
            {
                return result ;
            }

            foreach (ProjectItem item in projectItems)
            {
                result = find(item.ProjectItems, name);

                if (result != null)
                {
                    break;
                }

                if (item.Name.Equals(name))
                {
                    return item;
                }
            }

            return result;
        }
        
        /// <summary>
        /// double click then go to the specific file and line number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid datagrid = sender as DataGrid;
            int index = datagrid.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            //TODO get moduleName and lineNum
            
            
        }

        /// <summary>
        /// go to module file and line number
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="lineNum"></param>
        private void gotoLine(string moduleName, int lineNum)
        {
            ProjectItem pi = find(moduleName);

            if (pi == null)
            {
                //TODO show message
                return;
            }

            EnvDTE.Window win = pi.Open();
            win.Document.Activate();
            ((EnvDTE.TextSelection)DTE.ActiveDocument.Selection).GotoLine(lineNum, true);
        }
    }

  

    
}