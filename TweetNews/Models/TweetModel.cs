using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetNews.Models
{
    public class TweetModel
    {
        public TweetModel()
        {
            TweetUsers = new HashSet<TwitterUser>();
        }

        [Key]
        public long TweetId { get; set; }

     
        public long  CreatorId { get; set; }    

        [Required]
        public string Text { get; set; }

        public bool Retweet { get; set; }

        public virtual ICollection<TwitterUser> TweetUsers { get; set; }

    }

}
