using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CaseDatabase
{
    /// <summary>
    /// Interaction logic for Case.xaml
    /// </summary>
    public partial class Cases : UserControl
    {
        public event EventHandler BackClicked;

        //public delegate void StudentSelectionHandler(object sender, StudentEventArgs e);
        //public event StudentSelectionHandler StudentSelected;

        
        public Cases()
        {
            InitializeComponent();
            GetComboProjects();
        }

        private void Login_LoginSuccess(object sender, EventArgs e)
        {
            GetComboProjects(); 
        }

        public void GetComboProjects()
        {
            ProjectsCombo.Items.Clear();
            foreach (var item in SessionContext.CurrentUsersProjects)
            {
                ProjectsCombo.Items.Add(item.ToString());
            }
            
        }

        public void GetComboProjectsSample()
        {
            ProjectsCombo.Items.Clear();
            ProjectsCombo.Items.Add("test");
            ProjectsCombo.Items.Add("tfl");
            ProjectsCombo.Items.Add("postbank");


        }


        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (BackClicked != null)
            {
                BackClicked(this, EventArgs.Empty);
            }
        }
    }
}
