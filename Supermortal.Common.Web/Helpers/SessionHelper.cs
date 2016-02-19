using System;
using System.Web;
using log4net;
using Supermortal.Common.Web.Helpers.Log;

namespace Supermortal.Common.Web.Helpers
{
    public class SessionHelper
    {

        private static readonly ILog Log = LogHelper.GetLogger(typeof (SessionHelper));

        ////////////////////////////////////////////////////

        private static SessionHelper _instance;
        public static SessionHelper Instance
        {
            get
            {
                return _instance ?? (_instance = new SessionHelper());
            }
        }

        ////////////////////////////////////////////////////

        private const string IPADDRESS_SESSION_KEY = "IPADDRESS_SESSION";
        public string IPAddress
        {
            get
            {
                try
                {
                    if (HttpContext.Current.Session[IPADDRESS_SESSION_KEY] == null)
                        HttpContext.Current.Session[IPADDRESS_SESSION_KEY] = GetIP();

                    return HttpContext.Current.Session[IPADDRESS_SESSION_KEY].ToString();
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message, ex);
                    return null;
                }
            }
        }

        private const string SESSION_STARTED_SESSION_KEY = "SESSION_STARTED_SESSION";
        public bool SessionStarted
        {
            get
            {
                try
                {
                    if (HttpContext.Current.Session[SESSION_STARTED_SESSION_KEY] == null)
                        HttpContext.Current.Session[SESSION_STARTED_SESSION_KEY] = false;

                    return (bool)HttpContext.Current.Session[SESSION_STARTED_SESSION_KEY];
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message, ex);
                    return false;
                }
            }
            private set { HttpContext.Current.Session[SESSION_STARTED_SESSION_KEY] = value; }
        }

        private SessionHelper()
        {
            
        }

        private static string GetIP()
        {
            try
            {
                //string ip = null;
                //var hostName = Dns.GetHostName();
                //var dnsEntry = Dns.GetHostEntry(hostName);
                //if (dnsEntry != null && dnsEntry.AddressList.Length > 0)
                //    ip = dnsEntry.AddressList[0].ToString();

                //return ip;

                return HttpContext.Current.Request.UserHostAddress;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return null;
            }
        }

        public void SessionIsStarted()
        {
            try
            {
                SessionStarted = true;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
        }

    }
}
