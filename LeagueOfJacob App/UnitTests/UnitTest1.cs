using LeagueOfJacob_App.Data;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void setCorrectData()
        {
            LeagueData leagueData = LeagueData.Instance;
            leagueData.setLeagueData("euw","harflite");

        }
        [TestMethod]
        public void setIncorrectRegion()
        {
            LeagueData leagueData = LeagueData.Instance;
            leagueData.setLeagueData("kr", "harflite");

        }

        [TestMethod]
        public void setIncorrectusername()
        {
            LeagueData leagueData = LeagueData.Instance;
            leagueData.setLeagueData("euw", "uwnsbafwmksonana");
        }

        [TestMethod]
        public void setEmpty()
        {
            LeagueData leagueData = LeagueData.Instance;
            leagueData.setLeagueData("", "");

        }
    }
}