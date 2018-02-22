using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetNews.Models
{
    public class TwitterDbContext : DbContext
    {
        public TwitterDbContext() :
         base("DefaultConnection")
        {
        }

        public virtual DbSet<TwitterUser>     Users      { get; set; }
        public virtual DbSet<TweetModel>      Tweets     { get; set; }
        public virtual DbSet<Category>        Categories { get; set; }
       
    }
}
