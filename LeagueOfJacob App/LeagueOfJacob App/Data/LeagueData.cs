using HtmlAgilityPack;

namespace LeagueOfJacob_App.Data
{
    public sealed class LeagueData
    {
        private static readonly Lazy<LeagueData> lazy = new Lazy<LeagueData>(() => new LeagueData());
        public static LeagueData Instance { get { return lazy.Value; } }
        private LeagueData()
        {
        }

        private String region ="";
        private String username="";
        private String rank="";

        public void setLeagueData(String region, String username)
        {

            String[] data = search(region, username);
            this.region = data[0];
            this.username = data[1];   
            this.rank = data[2];
        }

        public String[] getLeagueData()
        {

            return (new String[] { this.region, this.username,this.rank });
        }

        public String[] search(String region, String username)
        {

            String url = "https://www.leagueofgraphs.com/summoner/" + region + "/" + username;
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var rankElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='leagueTier']");
            var rank = rankElement.InnerText.Trim();
            String[] result = { region, username, rank };
            return result;
        }

        public bool exists(String region, String username)
        {

            try
            {
                var httpClient = new HttpClient();
                var html = httpClient.GetStringAsync("https://www.leagueofgraphs.com/summoner/" + region + "/" + username).Result;
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}