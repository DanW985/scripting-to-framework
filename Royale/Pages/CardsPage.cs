using Framework.Selenium;
using OpenQA.Selenium;
using System.Threading;


namespace Royale.Pages
{

public class CardsPage : PageBase
{
    public readonly CardsPageMap Map;

    public CardsPage()
    {
        Map = new CardsPageMap();
    }

    public CardsPage Goto()
    {
        HeaderNav.GotoCardsPage();
        Thread.Sleep(3000);
        return this;
    }
    public Element GetCardByName(string cardName)
    {

        if(cardName.Contains(" "))
        {
            cardName = cardName.Replace(" ", "+");
        }

        return Map.Card(cardName);
        

    }
}

public class CardsPageMap
{
        public Element Card(string name) => Driver.FindElement(By.CssSelector($"a[href*='{name}']"), $"Card: {name} ");
}

}