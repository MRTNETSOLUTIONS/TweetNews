using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi;
using TweetNews.Models;

namespace TweetNews.Helpers
{

    public class TweetService
    {
        public static List<TweetModel> Tweets = new List<TweetModel>();
        public static List<TwitterUser> TwitterUserList = new List<TwitterUser>();
        const string S_NAME = "MRTNetSolutions";
        static int tweetCount, userCount;

        public static void ClearLists()
        {
            tweetCount = 0;
            userCount = 0;
            Tweets.Clear();
            TwitterUserList.Clear();
        }

        static async Task<List<TwitterUser>> GetUsersAsync(string screenName)
        {
            TwitterDbContext db = new TwitterDbContext();
            TwitterUserList.Clear();

            await Task.Run(() =>
            {
                var screen = Tweetinvi.User.GetUserFromScreenName(screenName);
                var _twitterUsers = screen == null ? null : screen.GetFriends();
                var _dbUsers = db.Users.AsEnumerable();

                if (_dbUsers != null && _dbUsers.Count() > 0 && _twitterUsers != null && _twitterUsers.Count() > 0)
                {
                    foreach (var user in _twitterUsers)
                    {
                        if (!_dbUsers.Any(t => t.TwitterId == user.Id))
                        {
                            TwitterUserList.Add(new TwitterUser { Name = user.Name, TwitterId = user.Id, Location = user.Location, UserName = user.ScreenName });
                        }

                    }
                }
                else
                {
                    if (_twitterUsers != null && _twitterUsers.Count() > 0)
                    {
                        foreach (var user in _twitterUsers)
                        {
                            TwitterUserList.Add(new TwitterUser { Name = user.Name, TwitterId = user.Id, Location = user.Location, UserName = user.ScreenName });
                        }
                    }
                }
            });
            return TwitterUserList;
        }






        static async Task<List<TweetModel>> GetTweetsAsync()
        {
            TwitterDbContext db = new TwitterDbContext();
            Tweets.Clear();
            await Task.Run(() =>
            {
                var tweets = Timeline.GetHomeTimeline();
                var _dbTweets = db.Tweets.AsEnumerable();

                if (_dbTweets != null && _dbTweets.Count() > 0 && tweets != null)
                {
                    foreach (var tweet in tweets)
                    {
                        if (!_dbTweets.Any(t => t.TweetId == tweet.Id || t.Text.ToLower() == tweet.Text.ToLower()))
                        {
                            Tweets.Add(new TweetModel { TweetId = tweet.Id, Text = tweet.Text, Retweet = tweet.Retweeted, CreatorId = tweet.CreatedBy.Id });
                        }
                    }

                }
                else
                {
                    if (tweets != null)
                    {
                        foreach (var tweet in tweets)
                        {
                            Tweets.Add(new TweetModel { TweetId = tweet.Id, Text = tweet.Text, Retweet = tweet.Retweeted, CreatorId = tweet.CreatedBy.Id });
                        }

                    }
                }
            });
            return Tweets;
        }

        public static async void SaveUsers()
        {
            TwitterDbContext db = new TwitterDbContext();
            var users = await GetUsersAsync(S_NAME);
            db.Users.AddRange(users);
            if (await db.SaveChangesAsync() > 0)
            {
                userCount += users.Count;
                Console.WriteLine("Users Saved : " + DateTime.Now+ " Total(" + userCount.ToString() + ") ");

            }
        }

        public static async void SaveTweets()
        {
            TwitterDbContext db = new TwitterDbContext();
            var tweets = await GetTweetsAsync();

            db.Tweets.AddRange(tweets);

            if (await db.SaveChangesAsync() > 0)
            {
                tweetCount += tweets.Count;
                Console.WriteLine("Tweets Saved : " + DateTime.Now+ " Total(" +tweetCount.ToString()+ ") " );
            }
        }

    }


}
