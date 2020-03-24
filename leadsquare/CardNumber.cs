using System;
using System.Collections.Generic;
using System.Text;

namespace leadsquare
{
    public class CardNumber
    {
        private readonly CardNumberEnum cardNumberEnum;

        public string Number
        {
            get { return cardNumberEnum.ToString(); }
        }
        public CardNumber(CardNumberEnum cardNumberEnum)
        {
            this.cardNumberEnum = cardNumberEnum;
        }
    }
}
