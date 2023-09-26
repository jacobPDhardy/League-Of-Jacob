using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Drawing;

IWebDriver driver = new FirefoxDriver();
driver.Url = "https://www.leagueofgraphs.com/summoner/euw/m7md333";

IWebElement tierTF = driver.FindElement(By.ClassName("leagueTier"));
Console.WriteLine(tierTF.Text); 

var masteries = driver.FindElements(By.ClassName("champColumn"));
foreach (var mastery in masteries)
{
    Console.WriteLine("AAA");
    Console.WriteLine(mastery.get);
}