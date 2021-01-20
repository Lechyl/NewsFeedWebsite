using NewsFeedWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;
using NewsFeedWebsite.Custom;

namespace NewsFeedWebsite.Services
{
    public class API
    {
        public API()
        {

        }
        public List<RssFeedModel> GetRssFeedByUrl(string url)
        {
            List<RssFeedModel> rssFeeds = new List<RssFeedModel>();
            try
            {
                //http request
                using XmlReader xr = XmlReader.Create(url);
                //convert the xml format to feed object
                SyndicationFeed feed = SyndicationFeed.Load(xr);
                foreach (var item in feed.Items)
                {
                    rssFeeds.Add(new RssFeedModel { Title = item.Title.Text, Summary = item.Summary.Text, PublishDate = item.PublishDate, Url = item.Links[0].Uri });
                }
                return rssFeeds;
            }
            catch (Exception)
            {

                return rssFeeds;
            }
        }

        public CustomRssList<RssFeedModel> GetRssFeedByUrlCustomList(string url)
        {
            CustomRssList<RssFeedModel> rssFeeds = new CustomRssList<RssFeedModel>();
            try
            {
                //http request
                using XmlReader xr = XmlReader.Create(url);
                //convert the xml format to feed object
                SyndicationFeed feed = SyndicationFeed.Load(xr);
                foreach (var item in feed.Items)
                {
                    rssFeeds.Add(new RssFeedModel { Title = item.Title.Text, Summary = item.Summary.Text, PublishDate = item.PublishDate, Url = item.Links[0].Uri });
                }
                return rssFeeds;
            }
            catch (Exception)
            {

                return rssFeeds;
            }
        }
    }
}
