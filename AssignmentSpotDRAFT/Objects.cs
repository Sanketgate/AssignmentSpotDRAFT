using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;

namespace AssignmentSpotDRAFT
{
    class Objects
    {

        public Objects()
        {
            PageFactory.InitElements(Collections.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@id='signIn']/div/div/a")]
        public IWebElement signInLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Sign in with email")]
        public IWebElement signInWithEmailButton { get; set; }

        [FindsBy(How = How.Id, Using = "ap_email")]
        public IWebElement emailTextbox { get; set; }

        [FindsBy(How = How.Id, Using = "ap_password")]
        public IWebElement passwordTextbox { get; set; }

        [FindsBy(How = How.Id, Using = "signInSubmit")]
        public IWebElement signInButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='searchBox__input searchBox__input--navbar']")]
        public IWebElement searchTextbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='searchBox__input searchBox__input--navbar']/following-sibling::button")]
        public IWebElement searchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='wtrButtonContainer'and starts-with(@id,'1_')]/div[1]")]
        public IWebElement wantToReadButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='wtrButtonContainer'and starts-with(@id,'1_')]/div/form/button[@class='wtrStatusToRead wtrUnshelve']")]
        public IWebElement checkmarkOnWantToReadButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='personalNav']/li[5]")]
        public IWebElement profileIconButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='personalNav']/li/div/div/div/ul/li[1]")]
        public IWebElement profileMenuOnProfileDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='shelves']/div[3]/a")]
        public IWebElement toReadOption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.actionLinkLite.smallText.deleteLink")]
        public IWebElement crossmarkOnToRead { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='personalNav']/li/div/div/div/ul/li[13]")]
        public IWebElement logoutMenuOnProfileDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='signIn']/div/div/a[text()]")]
        public IWebElement signInTextForAssert { get; set; }

    }
}
