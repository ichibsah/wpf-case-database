using System;
using System.Windows.Controls;
using erminas.SmartAPI.CMS;
using erminas.SmartAPI.CMS.Project;
using erminas.SmartAPI.CMS.ServerManagement;
using erminas.SmartAPI.Utils;
using erminas.SmartAPI.Utils.CachedCollections;

namespace CaseDatabase
{
    public static class SessionContext
    {
        public static string Username;
        public static string Password;

        public static PasswordAuthentication AuthData { get; internal set; }
        public static ServerLogin Login { get; internal set; }
        public static ISession Session { get; internal set; }
        public static IServerManager ServerManager { get; internal set; }
        public static string Url { get; internal set; }
        public static IIndexedRDList<string, IProject> CurrentUsersProjects { get; internal set; }
        public static Guid LoginGuid { get; internal set; }
        public static string SessionKey { get; internal set; }
        public static object ProjectGuidDropList { get; internal set; }
        public static Guid ProjectGuid { get; internal set; }
    }
}

   
