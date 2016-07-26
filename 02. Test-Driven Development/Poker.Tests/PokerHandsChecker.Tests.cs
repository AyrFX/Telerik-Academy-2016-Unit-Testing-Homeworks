namespace Poker.Tests
{
	using System;
	using System.Collections.Generic;
	using NUnit.Framework;

	[TestFixture]
	public class PokerHandsCheckerTests
	{
		[Test]
		public void IsValidShouldReturnFalseIfCardsAreNull()
		{
			List<ICard> cardsSet = null;
			var hand = new Hand(cardsSet);
			var checker = new PokerHandsChecker();
			
			Assert.That(checker.IsValidHand(hand), Is.False);
		}
		
		[Test]
		public void IsValidShouldReturnFalseIfCardsAreLessOf5()
		{
			var cardsSet = new List<ICard>();
			var generator = new Random();
			for (int i = 0; i < 3; i++) {
				var face = (CardFace)generator.Next(2, 14);
				var suit = (CardSuit)generator.Next(1, 4);
				cardsSet.Add(new Card(face, suit));
			}
			var hand = new Hand(cardsSet);
			var checker = new PokerHandsChecker();
			
			Assert.That(checker.IsValidHand(hand), Is.False);
		}
		
		[Test]
		public void IsValidShouldReturnFalseIfCardsAreMoreThan5()
		{
			var cardsSet = new List<ICard>();
			var generator = new Random();
			for (int i = 0; i < 6; i++)
			{
				var face = (CardFace)generator.Next(2, 14);
				var suit = (CardSuit)generator.Next(1, 4);
				cardsSet.Add(new Card(face, suit));
			}
			var hand = new Hand(cardsSet);
			var checker = new PokerHandsChecker();
			
			Assert.That(checker.IsValidHand(hand), Is.False);
		}
		
		[Test]
		public void IsValidShouldReturnTrueIfCardsAre5()
		{
			var cardsSet = new List<ICard>();
			var generator = new Random();
			for (int i = 0; i < 5; i++)
			{
				var face = (CardFace)generator.Next(2, 14);
				var suit = (CardSuit)generator.Next(1, 4);
				cardsSet.Add(new Card(face, suit));
			}
			
			var hand = new Hand(cardsSet);
			var checker = new PokerHandsChecker();
			
			Assert.That(checker.IsValidHand(hand), Is.True);
		}
		
		[Test]
		[Repeat(100)]
		public void IsValidShouldReturnTrueIfCardsAreDifferent()
		{
			var cardsSet = new List<ICard>();
			var generator = new Random();
			for (int i = 0; i < 5; i++)
			{
				var face = (CardFace)generator.Next(2, 14);
				var suit = (CardSuit)generator.Next(1, 4);
				cardsSet.Add(new Card(face, suit));
			}
			
			var hand = new Hand(cardsSet);
			bool onlyDifferent = true;
			for (int i = 0; i < 5; i++) {
				for (int j = i+1; j < 5; j++) {
					if(hand.Cards[i].Face == hand.Cards[j].Face &&
					   hand.Cards[i].Suit == hand.Cards[j].Suit)
					{
						onlyDifferent = false;
						break;
					}
				}
				if (!onlyDifferent)
				{
					break;
				}
			}
			
			var checker = new PokerHandsChecker();
			Assert.That(checker.IsValidHand(hand), Is.EqualTo(onlyDifferent));
		}
		
		[Test]
		public void IsFlushShouldReturnFalseIfHandIsNotValid()
		{
			var cardsSet = new List<ICard>();
			var generator = new Random();
			for (int i = 0; i < 4; i++)
			{
				var face = (CardFace)generator.Next(2, 14);
				var suit = (CardSuit)generator.Next(1, 4);
				cardsSet.Add(new Card(face, suit));
			}
			
			var hand = new Hand(cardsSet);
			var checker = new PokerHandsChecker();
			
			Assert.That(checker.IsValidHand(hand), Is.EqualTo(checker.IsFlush(hand)));
		}
		
		[Test]
		[Repeat(100)]
		public void IsFlushShouldReturnTrueIfAllCardsAreOfTheSameSuit()
		{
			var cardsSet = new List<ICard>();
			var generator = new Random();
			for (int i = 0; i < 5; i++)
			{
				var face = (CardFace)generator.Next(2, 14);
				var suit = (CardSuit)generator.Next(1, 4);
				cardsSet.Add(new Card(face, suit));
			}
			
			var hand = new Hand(cardsSet);
			var checker = new PokerHandsChecker();
			var firstCardSuit = hand.Cards[0].Suit;
			var areOfSameSuit = true;
			for (int i = 1; i < hand.Cards.Count; i++) {
				if (hand.Cards[i].Suit != firstCardSuit)
				{
					areOfSameSuit = false;
					break;
				}
			}
				
			Assert.That(checker.IsFlush(hand), Is.EqualTo(areOfSameSuit));
		}
		
		[Test]
		public void IsFourOfAKindShouldReturnFalseIfHandIsNotValid()
		{
			var cardsSet = new List<ICard>();
			var generator = new Random();
			for (int i = 0; i < 4; i++)
			{
				var face = (CardFace)generator.Next(2, 14);
				var suit = (CardSuit)generator.Next(1, 4);
				cardsSet.Add(new Card(face, suit));
			}
			
			var hand = new Hand(cardsSet);
			var checker = new PokerHandsChecker();
			
			Assert.That(checker.IsValidHand(hand), Is.EqualTo(checker.IsFourOfAKind(hand)));
		}
		
		[Test]
		[Repeat(100)]
		public void IsFourOfAKindShouldReturnTrueIf4CardsAreOfTheSameFace()
		{
			var cardsSet = new List<ICard>();
			var generator = new Random();
			for (int i = 0; i < 5; i++)
			{
				var face = (CardFace)generator.Next(2, 14);
				var suit = (CardSuit)generator.Next(1, 4);
				cardsSet.Add(new Card(face, suit));
			}
			
			var isFourOfAKind = false;
			var hand = new Hand(cardsSet);
			CardFace currentFace;
			byte currentFaceCount;
			for (int i = 0; i < hand.Cards.Count; i++) {
				currentFace = hand.Cards[i].Face;
				currentFaceCount = 1;
				for (int j = 0; j < hand.Cards.Count; j++) {
					if (i == j)
					{
						continue;
					}
					if (currentFace == hand.Cards[j].Face)
					{
						currentFaceCount += 1;
					}
				}
				if (currentFaceCount >= 4) {
					isFourOfAKind = true;
					break;
				}
			}
			
			var checker = new PokerHandsChecker();	
			Assert.That(checker.IsFourOfAKind(hand), Is.EqualTo(isFourOfAKind));
		}
	}
}
