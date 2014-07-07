using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhenoCare
{
    public class RssDocument
    {
        public List<Item> Items { get; set; }

        public RssDocument()
        {
            this.Items = new List<Item>();
        }
    }
}