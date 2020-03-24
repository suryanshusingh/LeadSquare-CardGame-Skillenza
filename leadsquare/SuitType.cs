using System;
using System.Collections.Generic;
using System.Text;

namespace leadsquare
{
    public class SuitType
    {
        private readonly SuitTypeEnum suitTypeEnum;

        public string Suit
        {
            get { return suitTypeEnum.ToString(); }
        }

        public SuitType(SuitTypeEnum suitTypeEnum)
        {
            this.suitTypeEnum = suitTypeEnum;
        }
    }
}
