using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace PhenoCare.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/
        [OutputCache(Duration = 3600,VaryByParam="none")]
        public ActionResult Index()
        {
            //var rssChannel = Read(new Uri(
            //    "http://blog.vishalrakeshgupta.com/syndication.axd"));

            var rssChannel = Read(new Uri(
                "http://vishalrakeshgupta.blogspot.com/feeds/posts/default"));

            return View(rssChannel);
        }


        public RssChannel Read(Uri url)
        {
            //return GetSyndicationFeeds(url);

            return GetAtomFeeds(url);
        }

        public RssChannel GetAtomFeeds(Uri url)
        {
            try
            {
                var xdoc = XDocument.Load(url.AbsoluteUri);
                XNamespace ns = XNamespace.Get("http://www.w3.org/2005/Atom");

                var itemFeeds = xdoc.Root
                    .Descendants(ns + "entry")
                    .Select(n =>
                        new
                        {
                            Title = n.Element(ns + "title").Value,
                            PubDate = DateTime.Parse(n.Element(ns + "published").Value),
                            Content=n.Element(ns+"content").Value
                        }).ToList();

                if (itemFeeds != null)
                {
                    // Create the channel and set attributes
                    RssChannel rssChannel = new RssChannel();

                    foreach (var feed in itemFeeds)
                    {
                        Item item = new Item()
                        {
                            Title = feed.Title,
                            Link = string.Empty,
                            Description = feed.Content,
                            PubDate = Convert.ToDateTime(feed.PubDate).ToString("D")
                        };

                        rssChannel.Rss.Items.Add(item);
                    }

                    return rssChannel;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public RssChannel GetSyndicationFeeds(Uri url)
        {
            WebRequest request = WebRequest.Create(url.AbsoluteUri);

            WebResponse response = request.GetResponse();
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(response.GetResponseStream());
                XmlElement rssElement = xmlDoc["rss"];
                if (rssElement == null)
                {
                    return null;
                }

                XmlElement channelElement = rssElement["channel"];

                if (channelElement != null)
                {
                    // Create the channel and set attributes
                    RssChannel rssChannel = new RssChannel();
                    rssChannel.Title = channelElement["title"].InnerText;
                    rssChannel.Link = new Uri(channelElement["link"].InnerText);
                    rssChannel.Description = channelElement["description"].InnerText;

                    // Read the content
                    XmlNodeList itemElements =
                  channelElement.GetElementsByTagName("item");

                    foreach (XmlElement itemElement in itemElements)
                    {
                        Item item = new Item()
                        {
                            Title = itemElement["title"].InnerText,
                            Link = itemElement["link"].InnerText,
                            Description = itemElement["description"].InnerText,
                            PubDate = itemElement["pubDate"].InnerText
                        };

                        rssChannel.Rss.Items.Add(item);
                    }
                    return rssChannel;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
