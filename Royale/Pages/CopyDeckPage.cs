using Framework.Selenium;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class CopyDeckPage
    {
        public readonly CopyDeckPageMap Map;

        public CopyDeckPage()
        {
            Map = new CopyDeckPageMap();
        }

        public CopyDeckPage Yes()
        {
            Map.YesButton.Click();
            Driver.Wait.Until(drvr => Map.CopiedMessage.Displayed);
            return this;
        }

        public CopyDeckPage No()
        {
            Map.NoButton.Click();
            AcceptCookies();
            return this;
        }

        public void AcceptCookies()
        {
            Map.AcceptCookiesBtn.Click();
            Driver.Wait.Until(drvr => !Map.AcceptCookiesBtn.Displayed);
        }

        public void OpenAppStore()
        {
            Map.AppStoreBtn.Click();
        }

        public void OpenGooglePlay()
        {
            Map.GooglePlayStoreBtn.Click();
        }
    }

    public class CopyDeckPageMap
    {
        public Element YesButton => Driver.FindElement(By.Id("button-open"), "Yes Button");
        public Element CopiedMessage => Driver.FindElement(By.CssSelector(".notes.active"), "Copied Message");
        public Element NoButton => Driver.FindElement(By.Id("not-installed"), "No Button");
        public Element AppStoreBtn => Driver.FindElement(By.XPath("//a[text()='App Store']"), "App Store Button");
        public Element GooglePlayStoreBtn => Driver.FindElement(By.XPath("//a[text()='Google Play']"), "Google Play Store Button");
        public Element AcceptCookiesBtn => Driver.FindElement(By.CssSelector("a.cc-btn.cc-dismiss"), "Accept Cookies Button");
        
    }
}