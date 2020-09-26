using System;
using System.Collections.Generic;
using System.Text;

namespace TransFeeCalculator.Domain.Models
{
    public class Surcharge
    {
        public int MinAmount { get; set; }
        public int MaxAmount { get; set; }
        public int FeeAmount { get; set; }
    }

    public class SurchargeCollection
    {
        public List<Surcharge> Fees { get; set; }
    }
}
