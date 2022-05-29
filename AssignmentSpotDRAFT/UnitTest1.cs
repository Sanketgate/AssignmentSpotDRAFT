using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace AssignmentSpotDRAFT
{
    public class Tests
    {
        public static IWebDriver driver;
        [SetUp]
        public void Setup() //driver initialization
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("-start-maximized-");
            driver = new ChromeDriver(options);
            driver.Manage().Cookies.DeleteAllCookies();
        }

        [Test]
        public void Test1()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            driver.Navigate().GoToUrl("https://www.goodreads.com/"); //Navigating to Goodreads.com

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='signIn']/div/div/a")));

            driver.FindElement(By.XPath("//div[@id='signIn']/div/div/a")).Click(); //click on the Sign In link

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText("Sign in with email")));

            driver.FindElement(By.LinkText("Sign in with email")).Click(); //click on the Sign In with email button

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("signInSubmit")));

            driver.FindElement(By.Id("ap_email")).SendKeys("sanket.gate18@gmail.com"); //Insert email in Email textbox
            driver.FindElement(By.Id("ap_password")).SendKeys("Sanket@test"); //Insert password in password textbox

            driver.FindElement(By.Id("signInSubmit")).Click(); //click on the Sign In button

            driver.FindElement(By.XPath("//input[@class='searchBox__input searchBox__input--navbar']")).SendKeys("Business Model Generation"); //Insert Name of book in search textbox

            driver.FindElement(By.XPath("//input[@class='searchBox__input searchBox__input--navbar']/following-sibling::button")).Click(); //click on the Search button

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='wtrButtonContainer'and starts-with(@id,'1_')]/div[1]"))).Click(); //click on the "Want to read" button

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='wtrButtonContainer'and starts-with(@id,'1_')]/div/form/button[@class='wtrStatusToRead wtrUnshelve']"))); //Waiting for Green check mark to appear on "Want to read" button

            driver.FindElement(By.XPath("//ul[@class='personalNav']/li[5]")).Click(); //click on the Profile icon

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//ul[@class='personalNav']/li/div/div/div/ul/li[1]"))).Click(); //click on the Profile section from profile dropdown

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='shelves']/div[3]/a"))).Click(); //click on the "to-read" link


            driver.FindElement(By.CssSelector("a.actionLinkLite.smallText.deleteLink")).Click(); //click on the Cross mark to remove book from my books

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent()); //Wait for alert to be present

            driver.SwitchTo().Alert().Accept(); //Accept the alert(Selecting OK)

            driver.FindElement(By.XPath("//ul[@class='personalNav']/li[5]")).Click(); //click on the Profile icon

            driver.FindElement(By.XPath("//ul[@class='personalNav']/li/div/div/div/ul/li[13]")).Click(); //click on the Sign out section from profile dropdown

            Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='signIn']/div/div/a")).Displayed); //Assert if "Sign In" is displayed on the webpage
            
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}