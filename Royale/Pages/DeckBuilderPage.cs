using OpenQA.Selenium;
using Framework.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Framework;

namespace Royale.Pages
{
    public class DeckBuilderPage : PageBase
    {
        public readonly DeckBuilderPageMap Map;

        public DeckBuilderPage()
        {
            Map = new DeckBuilderPageMap();
        }

        public DeckBuilderPage Goto()
        {
            FW.Log.Step("Click Deck Builder Link");
            HeaderNav.Map.DeckBuilderLink.Click();
            return this;
        }

        public void AddCardsManually()
        {
            Driver.Wait.Until(drvr => Map.AddCardsManuallyLink.Displayed);
            FW.Log.Step("Click Add Cards Manually link");
            Map.AddCardsManuallyLink.Click();
            Driver.Wait.Until(drvr => Map.CopyDeckIcon.Displayed);
        }

        public void CopySuggestedDeck()
        {
            FW.Log.Step("Click Copy Deck icon");
            Map.CopyDeckIcon.Click();
        }

    }

    public class DeckBuilderPageMap
    {
        public Element AddCardsManuallyLink => Driver.FindElement(By.XPath("//a[text()='add cards manually']"), "Add cards manually link");
        public Element CopyDeckIcon => Driver.FindElement(By.CssSelector(".copyButton"), "Copy Deck icon");
        
    }
}