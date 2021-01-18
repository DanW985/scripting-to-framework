using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Framework.Selenium
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        [ThreadStatic]
        public static Wait Wait;
        
        public static void Init()
        {
            FW.Log.Info("Browser: Chrome");
            _driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
            Wait = new Wait(30);
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null");

        public static string Title => Current.Title;

        public static void GotTo(string url)
        {
            if (!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }

            FW.Log.Info(url);
            Current.Navigate().GoToUrl(url);
        }

        public static void Quit()
        {
            FW.Log.Info("Close Browser");
            Current.Quit();
            Current.Dispose();
        }

        public static Element FindElement(By by, string elementName)
        {
            return new Element(Current.FindElement(by), elementName)
            {
                FoundBy = by
            };
        }

        public static IList<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }
    }
}