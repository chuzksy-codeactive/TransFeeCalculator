using System.Collections.Generic;
using TransFeeCalculator.Domain.Models;

namespace TransFeeCalculator.Application.Models
{
    public class FeeDTO
    {
        public int MinAmount { get; set; }
        public int MaxAmount { get; set; }
        public int FeeAmount { get; set; }
    }
}
