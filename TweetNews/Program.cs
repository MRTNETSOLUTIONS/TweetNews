using System;
using System.Threading;
using System.Threading.Tasks;
using TweetNews.Authentication;
using TweetNews.Helpers;

namespace TweetNews
{
    class Program
    {
        static Timer tweetTimer = null;        


        static void Main(string[] args)
        {
            InitApplication();
        }

       

        private static void InitApplication()
        {            
            Authorize auth = new Authorize();
            auth.AuthenticateUser();
            TweetService.ClearLists();
            tweetTimer = new Timer(TimerCallback, null, 0, 60000);          
            Console.ReadLine();
        }

       

        private static void TimerCallback(Object o)
        {
            try
            {
                Task.Run(() =>
                {
                    TweetService.SaveUsers();
                    TweetService.SaveTweets();
                });
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                GC.Collect();
            }
        }


    }
}
