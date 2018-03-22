using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.DBModels
{
    public class SharedArticle
    {
        public Guid ID { get; set; }
        [ForeignKey("User")]
        public string UserID { get; set; }
        [ForeignKey("Article")]
        public Guid ArticleID { get; set; }
        
        public virtual ApplicationUser User { get; set; }
   
        public virtual Article Article { get; set; }
    }
}