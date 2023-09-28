using HtmlAgilityPack;
using System;

namespace LeagueOfJacob_App.Data
{

    public class LeagueDataService
    {
        private String[]? data;
        public Task<LeagueData> setLeagueData(String region,String username)
        {

            data = search(region,username);
            return Task.FromResult(new LeagueData
            {
                region = data[0],
                username = data[1],
                rank = data[2]
            });
        }

        public String[] getLeagueData()
        {
            return data;    
        }

        public String[] search(String region, String username)
        {

            String url = "https://www.leagueofgraphs.com/summoner/" + region + "/" + username;
            var httpClient = new HttpClient();

            HtmlDocument? htmlDocument = new HtmlDocument();
            String rank = "Invalid";
            try
            {
                var html = httpClient.GetStringAsync(url).Result;
                htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);
                var rankElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='leagueTier']");
                rank = rankElement.InnerText.Trim();
            }
            catch (Exception e) {
                
            }

            String[] result = { region,username,rank};
            return result;
        }
    }
}
