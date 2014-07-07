using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhenoCare
{
    public class RssChannel
    {
        public string Title { get; set; }
        public System.Uri Link { get; set; }
        public string Description { get; set; }
        public RssDocument Rss { get; set; }

        public RssChannel()
        {
            this.Rss = new RssDocument();
        }
    }
}