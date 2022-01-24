
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using HtmlAgilityPack;

namespace Crypto_Bot
{
    //If you want to access the bot go to: https://twitter.com/cryptbott
    class Program
    {
        private static string apiNormal = "Your normal api key here";
        private static string apiSecret = "Your secret api key here";
        private static string accessNormal = "Yor normal access key here";
        private static string accessSecret = "Your secret access key here";
        private static string btc = string.Empty;
        private static string eth = string.Empty;
        private static string ada = string.Empty;
        private static string bnb = string.Empty;
        private static string ergo = string.Empty;
        private static string cake = string.Empty;
        private static string doge = string.Empty;

        static void BitcoinPrice()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://br.financas.yahoo.com/quote/BTC-USD/");
            var headernames = doc.DocumentNode.SelectNodes("//fin-streamer[@class='Fw(b) Fz(36px) Mb(-4px) D(ib)']");
            //Load a site and take a node from it
            foreach (var currNode in headernames)
            {
                btc = currNode.InnerText;
                //Converts the node into a string
            }
        }

        static void EthereumPrice()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://finance.yahoo.com/quote/ETH-USD/");
            var headernames = doc.DocumentNode.SelectNodes("//fin-streamer[@class='Fw(b) Fz(36px) Mb(-4px) D(ib)']");
            foreach (var currNode in headernames)
            {
                eth = currNode.InnerText;
            }
        }

        static void CardanoPrice()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://finance.yahoo.com/quote/ADA-USD/");
            var headernames = doc.DocumentNode.SelectNodes("//fin-streamer[@class='Fw(b) Fz(36px) Mb(-4px) D(ib)']");
            foreach (var currNode in headernames)
            {
                ada = currNode.InnerText;
            }
        }

        static void BinanceCoinPrice()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://finance.yahoo.com/quote/BNB-USD/");
            var headernames = doc.DocumentNode.SelectNodes("//fin-streamer[@class='Fw(b) Fz(36px) Mb(-4px) D(ib)']");
            foreach (var currNode in headernames)
            {
                bnb = currNode.InnerText;
            }
        }

        static void ErgoPrice()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://finance.yahoo.com/quote/ERG-USD/");
            var headernames = doc.DocumentNode.SelectNodes("//fin-streamer[@class='Fw(b) Fz(36px) Mb(-4px) D(ib)']");
            foreach (var currNode in headernames)
            {
                ergo = currNode.InnerText;
            }
        }

        static void PancakeSwapPrice()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://finance.yahoo.com/quote/CAKE-USD?p=CAKE-USD/");
            var headernames = doc.DocumentNode.SelectNodes("//fin-streamer[@class='Fw(b) Fz(36px) Mb(-4px) D(ib)']");
            foreach (var currNode in headernames)
            {
                cake = currNode.InnerText;
            }
        }

        static void DogeCoinPrice()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://finance.yahoo.com/quote/DOGE-USD/");
            var headernames = doc.DocumentNode.SelectNodes("//fin-streamer[@class='Fw(b) Fz(36px) Mb(-4px) D(ib)']");
            foreach (var currNode in headernames)
            {
                doge = currNode.InnerText;
            }
        }

        static async Task Main(string[] args)
        {
            BitcoinPrice();
            EthereumPrice();
            CardanoPrice();
            BinanceCoinPrice();
            ErgoPrice();
            PancakeSwapPrice();
            DogeCoinPrice();
            //Load the price of the coins

            TwitterClient client = new TwitterClient(apiNormal, apiSecret, accessNormal, accessSecret);
            //Creates a twitter client
            ITweet tweet = await client.Tweets.PublishTweetAsync(new PublishTweetParameters($"Crypto Prices (U$D) today at 13:00PM - Brazil:\n" +
                $"BTC: {btc}\n" +
                $"ETH: {eth}\n" +
                $"ADA: {ada}\n" +
                $"BNB: {bnb}\n" +
                $"ERGO: {ergo}\n" +
                $"CAKE: {cake}\n" +
                $"DOGE: {doge}\n" +
                $"Font: Finance Yahoo"));
            //Make the post of the specified informations
        }
    }
}
// To do the post everyday of the tweet use Task Scheduller, more informations in this link: https://www.c-sharpcorner.com/article/setup-task-scheduler-to-run-application/?fbclid=IwAR37sxqp8kOIbFFl4oClCjTBgKhJYxAFRoG7lfW58HfZrfknBnYNieCKfao
