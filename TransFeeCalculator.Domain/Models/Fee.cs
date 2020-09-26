using System.Collections.Generic;

namespace TransFeeCalculator.Domain.Models
{
    public class Fee
    {
        public int MinAmount { get; set; }
        public int MaxAmount { get; set; }
        public int FeeAmount { get; set; }
    }

    public class FeesCollection
    {
        public List<Fee> Fees { get; set; }
    }
}
