using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Article
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}