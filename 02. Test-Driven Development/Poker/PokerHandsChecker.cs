using System;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
        	if (hand.Cards == null)
        	{
        		return false;
        	}
        	
        	if (hand.Cards.Count != 5)
        	{
        		return false;
        	}
        	
        	for (int i = 0; i < hand.Cards.Count; i++) {
        		for (int j = i+1; j < hand.Cards.Count; j++) {
        			if (hand.Cards[i].Face == hand.Cards[j].Face &&
        			    hand.Cards[i].Suit == hand.Cards[j].Suit)
        			{
        				return false;
        			}
        		}
        	}
        	return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
        	{
        		return false;
        	}
            
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
					return true;
				}
			}
            
			return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
        	if (!this.IsValidHand(hand))
        	{
        		return false;
        	}
        	
        	var firstCardSuit = hand.Cards[0].Suit;
        	for (int i = 1; i < hand.Cards.Count; i++) {
        		if (hand.Cards[i].Suit != firstCardSuit)
        		{
        			return false;
        		}
        	}
        	
        	return true;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
