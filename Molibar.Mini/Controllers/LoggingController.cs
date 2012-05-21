using System;
using System.Configuration;
using System.Web.Management;
using System.Web.Mvc;

namespace Molibar.Mini.Controllers
{
    public class LoggingController : Controller
    {
        public ActionResult Index()
        {
            var sqlServerConnectionString =
                ConfigurationManager.AppSettings["SQLSERVER_CONNECTION_STRING"];
            var sqlServerUri =
                ConfigurationManager.AppSettings["SQLSERVER_URI"];
            var sqlServerConnectionStringAlias =
                ConfigurationManager.AppSettings["SQLSERVER_CONNECTION_STRING_ALIAS"];
            var message = string.Format("CONSTR {0}, SERVERURI {1}, ALIAS {2}",
                          sqlServerConnectionString,
                          sqlServerUri,
                          sqlServerConnectionStringAlias);
            new LogEvent(message).Raise();
            return new EmptyResult();
        }
    }

    public class LogEvent : WebRequestErrorEvent
    {
        public LogEvent(string message)
            : base(null, null, 100001, new Exception(message))
        {
        }
    }
}
