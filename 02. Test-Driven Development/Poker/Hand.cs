using System;
using System.Collections.Generic;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
        	string result = "";
        	for (int i = 0; i < this.Cards.Count; i++) {
        		result += this.Cards[i].ToString();
        		if (i != this.Cards.Count - 1)
        		{
        			result += ", ";
        		}
        	}
        	return result;
        }
    }
}
