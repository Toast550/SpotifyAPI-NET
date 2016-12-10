using System;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Enums;
using SpotifyAPI.Local.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebInterface.Controllers
{
    public class HomeController : Controller
    {
        private Track _currentTrack;
        // GET: Index
        public ActionResult Index()
        { 

            if (!SpotifyLocalAPI.IsSpotifyRunning())
            {
                ViewBag.song = "Spotify is not running!";
            }
            else
            {
                StatusResponse status = MvcApplication._spotify.GetStatus();
                _currentTrack = status.Track;
                if (_currentTrack.IsAd())
                {
                    ViewBag.song = "Ad";
                }
                else
                {
                    ViewBag.song = _currentTrack.TrackResource.Name + ", " + _currentTrack.ArtistResource.Name;
                }
            }
            return View();
        }

        public void Skip()
        {
            MvcApplication._spotify.Skip();
            Response.Redirect("/");
        }
    }
}