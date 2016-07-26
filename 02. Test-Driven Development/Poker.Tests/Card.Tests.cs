namespace Poker.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    class CardTests
    {
        [TestCase(CardFace.Ace, CardSuit.Clubs, "Ace of Clubs")]
        [TestCase(CardFace.Four, CardSuit.Diamonds, "Four of Diamonds")]
        [TestCase(CardFace.King, CardSuit.Hearts, "King of Hearts")]
        [TestCase(CardFace.Queen, CardSuit.Spades, "Queen of Spades")]
        [TestCase(CardFace.Three, CardSuit.Clubs, "Three of Clubs")]
        [TestCase(CardFace.Seven, CardSuit.Diamonds, "Seven of Diamonds")]
        [TestCase(CardFace.Nine, CardSuit.Hearts, "Nine of Hearts")]
        [Test]
        public void CardToStringShouldReturnRightResult(CardFace face, CardSuit suit, string result)
        {
            var card = new Card((CardFace)face, (CardSuit)suit);

            Assert.That(card.ToString(), Is.EqualTo(result));
        }

        [Test]
        public void CardToStringShouldReturnRightResultForAllCases(
            [Range((int)CardFace.Two, (int)CardFace.Ace)] int face,
            [Range((int)CardSuit.Clubs, (int)CardSuit.Spades)] int suit)
        {
            var card = new Card((CardFace)face, (CardSuit)suit);
            string result = (CardFace)face + " of " + (CardSuit)suit;

            Assert.That(card.ToString(), Is.EqualTo(result));
        }
    }
}
