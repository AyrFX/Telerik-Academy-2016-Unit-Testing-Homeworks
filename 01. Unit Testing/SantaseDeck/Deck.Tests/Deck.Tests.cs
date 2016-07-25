using System;
using System.Collections.Generic;
using NUnit.Framework;

using Santase.Logic.Cards;

namespace Deck.Tests
{
	[TestFixture]
    public class DeckTests
    {
        [Test]
        public void TrumpCardShouldBeNonNullable()
        {
            IDeck deck = new Santase.Logic.Cards.Deck();
            
            Assert.That(deck.TrumpCard, Is.Not.Null);
        }

        [Test]
        public void TrumpCardShouldBeRandom()
        {
            const int NumberOfRandomDecks = 25;
            var lastCard = new Santase.Logic.Cards.Deck().TrumpCard;
            for (var i = 0; i < NumberOfRandomDecks - 1; i++)
            {
                IDeck deck = new Santase.Logic.Cards.Deck();
                if (!deck.TrumpCard.Equals(lastCard))
                {
                    return;
                }

                lastCard = deck.TrumpCard;
            }

            Assert.Fail(NumberOfRandomDecks + " times generated the same trump card!");
        }

        [Test]
        public void CardsLeftShouldBe24ForANewDeck()
        {
            IDeck deck = new Santase.Logic.Cards.Deck();
            
            Assert.That(deck.CardsLeft, Is.EqualTo(24));
        }

        [Test]
        public void CardsLeftShouldBe23AfterDrawingOneCard()
        {
            IDeck deck = new Santase.Logic.Cards.Deck();
            deck.GetNextCard();
            
            Assert.That(deck.CardsLeft, Is.EqualTo(23));
        }

        [Test]
        public void CardsLeftShouldBe0AfterDrawing24Cards()
        {
            IDeck deck = new Santase.Logic.Cards.Deck();
            for (var i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }
            
            Assert.That(deck.CardsLeft, Is.EqualTo(0));
        }

        [Test]
        public void GetNextCardShouldThrowExceptionWhenCalled25Times()
        {
            IDeck deck = new Santase.Logic.Cards.Deck();
            for (var i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }

            Assert.That(() => { deck.GetNextCard(); }, Throws.Exception.TypeOf<InternalGameException>());
        }

        [Test]
        public void GetNextCardShouldNotChangeTheTrumpCard()
        {
            IDeck deck = new Santase.Logic.Cards.Deck();
            var trumpBefore = deck.TrumpCard;
            deck.GetNextCard();
            var trumpAfter = deck.TrumpCard;
            
            Assert.That(trumpBefore, Is.EqualTo(trumpAfter));
        }

        [Test]
        public void GetNextCardShouldReturnDifferentNonNullCardEveryTime()
        {
            IDeck deck = new Santase.Logic.Cards.Deck();
            var cards = new HashSet<Card>();
            var cardsCount = deck.CardsLeft;
            for (var i = 0; i < cardsCount; i++)
            {
                var card = deck.GetNextCard();
                
                Assert.That(card, Is.Not.Null);
                Assert.That(cards.Contains(card), Is.False);
                cards.Add(card);
            }
        }

        [Test]
        public void ChangeTrumpCardShouldWorkProperly()
        {
            IDeck deck = new Santase.Logic.Cards.Deck();
            var card = new Card(CardSuit.Spade, CardType.Nine);
            deck.ChangeTrumpCard(card);
            var trumpCard = deck.TrumpCard;
            
            Assert.That(card, Is.EqualTo(trumpCard));
        }

        [Test]
        public void ChangeTrumpCardShouldChangeTheLastCardInTheDeck()
        {
            IDeck deck = new Santase.Logic.Cards.Deck();
            var card = new Card(CardSuit.Club, CardType.Ace);
            deck.ChangeTrumpCard(card);
            var cardsCount = deck.CardsLeft;
            for (var i = 0; i < cardsCount - 1; i++)
            {
                deck.GetNextCard();
            }

            var lastCard = deck.GetNextCard();
            
            Assert.That(card, Is.EqualTo(lastCard));
        }
	}
}
