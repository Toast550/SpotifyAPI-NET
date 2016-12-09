using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Enums;
using SpotifyAPI.Local.Models;

namespace WebInterface
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static SpotifyLocalAPI _spotify;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            _spotify = new SpotifyLocalAPI();
            if (SpotifyLocalAPI.IsSpotifyRunning())
            {
                _spotify.Connect();
                _spotify.ListenForEvents = true;
            }
        }
    }
}
