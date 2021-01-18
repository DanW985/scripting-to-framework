using System.IO;
using System.Linq;
using System.Threading;
using Framework.Models;
using Framework.Selenium;
using Framework.Services;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.Pages;
using System.Collections.Generic;
using Framework;

namespace Royale.Tests
{
    public class CardTests
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
            
        }

        [TearDown]
        public void AfterEach()
        {
            Driver.Current.Quit();
        }

        static IList<Card> apiCards = new ApiCardServiceCalls().GetAllCards();

        [Test, Category("cards")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_is_on_cards_page(Card card)
        {         
            
            var cardOnPage = Pages.PagesWrapper.Cards.Goto().GetCardByName(card.Name);
            Assert.That(cardOnPage.Displayed);
        }

        
        [Test, Category("cards")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_headers_are_correct_on_card_details_page(Card card)
        {
            PagesWrapper.Cards.Goto().GetCardByName(card.Name).Click();

            var cardOnPage = PagesWrapper.CardDetails.GetBaseCard();
            

            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Type, cardOnPage.Type);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            
        }
    }
}