using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;

namespace TweetNews.Authentication
{
    public class Authorize
    {
        public  const  string Owner = "MRTNetSolutions";
        const   string oauth_consumer_key = "dUREbKT3bkCPJMLzM7NCKfq3u";
        const   string url = "https://api.twitter.com/1.1/statuses/home_timeline.json";
        const   string oauth_token = "762598479847952385-2gZGlTtgp7rEdburSggKRehJR28FK4x";
        const   string oauth_token_secret = "yduCRKbvMVHAVpYpUYk8NRfso5hoH4cYVO4gy93mDPoX6";     
        const   string oauth_consumer_secret = "x1Tw6CQ6eQHWL0XZjFOSjADDyegKjDPhy1CmuOokeK5l8WrsMr";

        public void AuthenticateUser()
        {
            Auth.SetUserCredentials(oauth_consumer_key, oauth_consumer_secret, oauth_token, oauth_token_secret);
        }


      //UserOperations uo = new TwitterOperations.UserOperations("MRTNetSolutions", oauth_token, oauth_token_secret, oauth_consumer_key, oauth_consumer_secret);

    }
}
