using Framework.Selenium;
using System;

namespace Royale.Pages
{
    public class PagesWrapper
    {
        [ThreadStatic]
        public static CardsPage Cards;

        [ThreadStatic]
        public static CardDetailsPage CardDetails;

        [ThreadStatic]
        public static DeckBuilderPage DeckBuilder;

        [ThreadStatic]
        public static CopyDeckPage CopyDeck;

        public static void Init()
        {
            Cards = new CardsPage();
            CardDetails = new CardDetailsPage();
            DeckBuilder = new DeckBuilderPage();
            CopyDeck = new CopyDeckPage();
        }
    }
}