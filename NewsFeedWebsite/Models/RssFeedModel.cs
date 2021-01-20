using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeedWebsite.Models
{
    public class RssFeedModel
    {
        [Display(Name = "Titel")]
        public string Title { get; set; }

        [Display(Name = "UnderTitel")]
        public string Summary { get; set; }

        [Display(Name ="Udgivelses dato")]
        public DateTimeOffset PublishDate { get; set; }

        public Uri Url { get; set; }
    }
}
