using LeagueOfJacob_App.Data;
using System.Security.Cryptography;

namespace UnitTests

{
    [TestClass]
    public class UnitTest1
    {
        public LeagueDataService lgs = new LeagueDataService();

        [TestMethod]
        public void validTypeData()
        {
            lgs.search("euw","harflite");
        }

        [TestMethod]
        public void invalidTypeData()
        {
            lgs.search("oi", "im wrong");

        }
    }
}