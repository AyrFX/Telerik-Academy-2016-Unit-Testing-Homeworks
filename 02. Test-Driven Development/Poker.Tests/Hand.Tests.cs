namespace Poker.Tests
{
	using System;
	using System.Collections.Generic;
	using NUnit.Framework;

	[TestFixture]
	public class HandTests
	{
		[Test]
		public void HandToStringShouldReturnRighrResult()
		{
			var cardsSet = new List<ICard>();
			cardsSet.Add(new Card(CardFace.Eight, CardSuit.Clubs));
			cardsSet.Add(new Card(CardFace.Queen, CardSuit.Spades));
			cardsSet.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
			cardsSet.Add(new Card(CardFace.Seven, CardSuit.Hearts));
			cardsSet.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
			string cardsText = "";
			for (int i = 0; i < cardsSet.Count; i++) {
				cardsText += cardsSet[i].ToString();
				if (i != cardsSet.Count - 1)
				{
					cardsText += ", ";
				}
			}
						
			var hand = new Hand((IList<ICard>)cardsSet);

			Assert.That(cardsText, Is.EqualTo(hand.ToString()));
		}
	}
}
