using System.Threading;
using Framework.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Royale.Pages;
using System;
using Framework;
using System.Text.RegularExpressions;

namespace Tests
{
    public class CopyDeckTests
    {
        [OneTimeSetUp]
        public void BeforeAll()
        {
            
            FW.CreateTestResultsDirectory();
            
        }
        [SetUp]
        public void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            PagesWrapper.Init();
            Driver.GotTo("https://statsroyale.com");
            Driver.Current.Manage().Window.Maximize();
            Thread.Sleep(6000);
            Driver.Current.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/span[1]/a")).Click();
            Thread.Sleep(2000);
            
        }

        [TearDown]
        public void AfterEach()
        {
            Driver.Current.Quit();
        }

        [Test, Category("copydeck")]
        public void User_can_copy_the_deck()
        {
           
            PagesWrapper.DeckBuilder.Goto().AddCardsManually();
            PagesWrapper.DeckBuilder.CopySuggestedDeck();
            PagesWrapper.CopyDeck.Yes();
            Assert.That(PagesWrapper.CopyDeck.Map.CopiedMessage.Displayed);
        }

        [Test, Category("copydeck")]
        public void User_opens_app_store()
        {
            PagesWrapper.DeckBuilder.Goto().AddCardsManually();
            PagesWrapper.DeckBuilder.CopySuggestedDeck();
            PagesWrapper.CopyDeck.No().OpenAppStore();

            var title = Regex.Replace(Driver.Title, @"\u0200e", string.Empty);

            Assert.That(title, Is.EqualTo("Clash Royale on the App Store"));
        }

        [Test, Category("copydeck")]
        public void User_opens_google_play()
        {
            PagesWrapper.DeckBuilder.Goto().AddCardsManually();
            PagesWrapper.DeckBuilder.CopySuggestedDeck();
            PagesWrapper.CopyDeck.No().OpenGooglePlay();
            Assert.AreEqual("Clash Royale - Apps on Google Play", Driver.Title);
        }
    }
}