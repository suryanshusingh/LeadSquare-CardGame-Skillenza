using System;
using System.Collections.Generic;
using System.Text;

namespace leadsquare
{
    class Card
    {
        private readonly CardNumber cardNumber;
        private readonly SuitType suitType;

        public string Suit
        {
            get
            {
                return suitType.Suit;
            }
        }

        public string CardNum
        {
            get { return cardNumber.Number; }
        }



        public Card(SuitTypeEnum suitType, CardNumberEnum cardNumber)
        {
            this.cardNumber = new CardNumber(cardNumber);
            this.suitType = new SuitType(suitType);
        }

        public string Play()
        {
            return CardNum + " of " + Suit;
        }
    }


}
