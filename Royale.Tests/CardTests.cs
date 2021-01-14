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

namespace Royale.Tests
{
    public class CardTests
    {
        [SetUp]
        public void BeforeEach()
        {
            Driver.Init();
            Pages.PagesWrapper.Init();
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

        [Test]
        public void Ice_Spirit_is_on_cards_page()
        {         
                     
            
            var iceSpirit = Pages.PagesWrapper.Cards.Goto().GetCardByName("Ice Spirit");
            Assert.That(iceSpirit.Displayed);
        }

        static string[] cardNames = { "Ice Spirit", "Mirror" };
        [Test, Category("Cards")]
        [TestCaseSource("cardNames")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_headers_are_correct_on_card_details_page(string cardName)
        {
            Pages.PagesWrapper.Cards.Goto().GetCardByName(cardName).Click();

            var cardOnPage = Pages.PagesWrapper.CardDetails.GetBaseCard();
            var card = new InMemoryCardService().GetCardByName(cardName);

            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Type, cardOnPage.Type);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            
        }
    }
}