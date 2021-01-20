using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using NewsFeedWebsite.Custom;
using NewsFeedWebsite.Models;
using NewsFeedWebsite.Services;
namespace NewsFeedWebsite.Controllers
{
    public class RssFeedController : Controller
    {

        public RssFeedController()
        {
        }
        public IActionResult Index(string searchString, string sortOrder)
        {
            // searchString = "https://www.dr.dk/nyheder/service/feeds/allenyheder";

            List<RssFeedModel> feeds = new List<RssFeedModel>();
            if (!String.IsNullOrEmpty(searchString))
            {
                //Temp store searchstring if needed to add extra parameters as sortorder
                ViewData["SearchString"] = searchString;

                //Get Rss Feeds from URL
                API api = new API();
                feeds = api.GetRssFeedByUrl(searchString);

            }
            
            //temp store the sort data to toggle between asc and desc
            ViewData["FeedTitle"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";

            ViewData["PublishDate"] = sortOrder == "date_asc" ? "date_desc" : "date_asc";

                // Sort Feed list
                switch (sortOrder)
                {
                    case "title_desc":
                        feeds = feeds.OrderByDescending(f => f.Title).ToList();
                        break;

                    case "date_asc":
                        feeds = feeds.OrderBy(s => s.PublishDate).ToList();
                        break;
                    case "date_desc":
                        feeds = feeds.OrderByDescending(s => s.PublishDate).ToList();
                        break;
                    default:
                        //title_asc
                        feeds = feeds.OrderBy(f => f.Title).ToList();
                        break;
                }
            
            

            return View(feeds);
        }

        // Get: /CustomIndex/
        public IActionResult CustomIndex(string searchString)
        {
             searchString = "https://www.dr.dk/nyheder/service/feeds/allenyheder";

            CustomRssList<RssFeedModel> feeds = new CustomRssList<RssFeedModel>();
            if (!String.IsNullOrEmpty(searchString))
            {
                //Temp store searchstring if needed to add extra parameters as sortorder
                ViewData["SearchString"] = searchString;

                //Get Rss Feeds from URL
                API api = new API();

                feeds = api.GetRssFeedByUrlCustomList(searchString);
            }
           
            
            return View(feeds);
        }

    }
}
