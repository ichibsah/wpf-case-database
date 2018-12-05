using CaseDatabase.Models;
using erminas.SmartAPI.CMS.Project;
using erminas.SmartAPI.Utils;
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
    public partial class Login : UserControl
    {
        private LoginModel _model;
        public event EventHandler LoginSuccess;
        public event EventHandler LoginFailure;
        
        public Login()
        {
            InitializeComponent();

            _model = new LoginModel();
            this.DataContext = _model;
        }

        private async void login_Click(object sender, RoutedEventArgs e)
        {
            SessionContext.Username = username.Text;
            SessionContext.Password = password.Password;
            SessionContext.Url = "http://localhost/cms";

            SessionContext.AuthData = new PasswordAuthentication(SessionContext.Username, SessionContext.Password);
            //var login = new ServerLogin() { Address = new Uri(url), AuthData = authData };
            SessionContext.Login = new ServerLogin(SessionContext.Url, SessionContext.AuthData) { Name = "adminLogin" };
            //var login = new ServerLogin(url, null);
            ////SessionContext.Session = SessionBuilder.CreateOrReplaceOldestSession(SessionContext.Login);
            ////SessionContext.ServerManager = SessionContext.Session.ServerManager;

            //these are all projects, the active user is assigned to
            ////SessionContext.CurrentUsersProjects = SessionContext.ServerManager.Projects.ForCurrentUser;
            ////SessionContext.LoginGuid = SessionContext.Session.LogonGuid;
            ////SessionContext.SessionKey = SessionContext.Session.SessionKey;
            ////SessionContext.ProjectGuidDropList = SessionContext.CurrentUsersProjects.ToList();
            //var projectGuid = serverManager.Projects.ForCurrentUser.GetByGuid(new Guid());
            ////SessionContext.ProjectGuid = new Guid();
            ////var selectedProject = (from IProject sp in SessionContext.CurrentUsersProjects
            ////where SessionContext.CurrentUsersProjects.ContainsName("prjName")
            ////select sp.Guid);

            ////var sessionBuilder = new SessionBuilder(SessionContext.Login, SessionContext.LoginGuid, SessionContext.SessionKey, SessionContext.ProjectGuid);
            //sessionBuilder.

            //Fetch password directly from view. Not according to MVC, but needed because password
            //  is  secure string and we don't want it hanging around in memory.
            //Any password (except "") is accepted in this demo.
            if ( !string.IsNullOrWhiteSpace(password.Password))
            {
                await OnSuccess();
            }
            else
            {
                await OnFailure();
            }
        }

        private async Task OnSuccess()
        {
            //Show info popup.
            await infoPopup.ShowAsync(InfoPopup.PopupStyle.Success);
            
            //Raise success event. 
            if (LoginSuccess != null)
            {
                LoginSuccess(this, EventArgs.Empty);
            }
        }

        private async Task OnFailure()
        {
            //Show info popup.
            await infoPopup.ShowAsync(InfoPopup.PopupStyle.Error);

            //Raise failure event.
            if (LoginFailure != null)
            {
                LoginFailure(this, EventArgs.Empty);
            }
        }

        private void InfoPopup_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
