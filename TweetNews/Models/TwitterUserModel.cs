using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetNews.Models
{
    public class TwitterUser
    {

        public TwitterUser()
        {
            Tweets = new HashSet<TweetModel>();
        }

        [Key]
        public long TwitterUserId { get; set; }

        [Index(IsUnique = true)]
        public long TwitterId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
        public string UserName { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<TweetModel> Tweets { get; set; }
    }
}
