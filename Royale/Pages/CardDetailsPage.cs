using System.Linq;
using Framework.Models;
using Framework.Selenium;
using OpenQA.Selenium;


namespace Royale.Pages
{
    public class CardDetailsPage : PageBase
    {
        public readonly CardsDetailsPageMap Map;

        public CardDetailsPage()
        {
            Map = new CardsDetailsPageMap();
        }

        public (string Category, string Arena) GetCardCategory()
        {
            var categories = Map.CardCategory.Text.Split(',');
            return (categories[0].Trim(), categories[1].Trim());
        }

        public Card GetBaseCard()
        {
            var (category, arena) = GetCardCategory();

            return new Card
            {
                Name = Map.CardName.Text,
                Type = category,
                Arena = arena
            };
        }
    }

    public class CardsDetailsPageMap
    {
        public Element CardName => Driver.FindElement(By.CssSelector("div[class*='cardName']"), "Card Name");

        public Element CardCategory => Driver.FindElement(By.CssSelector("div[class*='card__rarity']"), "Card Category");

        public Element CardRarity => Driver.FindElement(By.CssSelector("[class/*='rarityCaption']"), "Card Rarity");
    }
}