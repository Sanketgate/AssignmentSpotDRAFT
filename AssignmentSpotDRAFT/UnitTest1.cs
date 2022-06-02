using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace AssignmentSpotDRAFT
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("-start-maximized-");
            Collections.driver = new ChromeDriver(options);
            Collections.driver.Manage().Cookies.DeleteAllCookies();
            Collections.driver.Navigate().GoToUrl("https://www.goodreads.com/");//Navigating to Goodreads.com
        }

        [Test]
        public void Test1()
        {
            WebDriverWait wait = new WebDriverWait(Collections.driver, TimeSpan.FromSeconds(30));

            Objects page = new Objects();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(page.signInLink));
            page.signInLink.Click(); //click on the Sign In link

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(page.signInWithEmailButton));
            page.signInWithEmailButton.Click(); //click on the Sign In with email button

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(page.signInButton));
            
            //LogIn functionality
            page.emailTextbox.SendKeys("sanket.gate18@gmail.com");
            page.passwordTextbox.SendKeys("Sanket@test");
            page.signInButton.Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(page.searchTextbox));
            page.searchTextbox.SendKeys("Business Model Generation"); //Insert Name of book in search textbox
            page.searchButton.Click(); //click on the Search button

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(page.wantToReadButton));
            page.wantToReadButton.Click(); //click on the "Want to read" button

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(page.checkmarkOnWantToReadButton));
            page.profileIconButton.Click(); //click on the Profile icon

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(page.profileMenuOnProfileDropdown));
            page.profileMenuOnProfileDropdown.Click(); //click on the Profile section from profile dropdown

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(page.toReadOption));
            page.toReadOption.Click(); //click on the "to-read" link

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(page.crossmarkOnToRead));
            page.crossmarkOnToRead.Click(); //click on the Cross mark to remove book from my books

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent()); //Wait for alert to be displayed

            Collections.driver.SwitchTo().Alert().Accept(); //Accept the alert(Selecting OK)

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(page.profileIconButton));
            page.profileIconButton.Click(); //click on the Profile icon

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(page.logoutMenuOnProfileDropdown));
            page.logoutMenuOnProfileDropdown.Click(); //click on the Sign out section from profile dropdown

            Assert.AreEqual("Sign In", page.signInTextForAssert.Text); //Assert if "Sign In" text displayed on the webpage
        }

        [TearDown]
        public void TearDown()
        {
            Collections.driver.Quit();
        }
    }
}