using System.Collections.Generic;
using TransFeeCalculator.Domain.Models;

namespace TransFeeCalculator.Domain.IRepository
{
    public interface IFeesRepository
    {
        IEnumerable<Fee> GetFees();
        Fee GetFee(int amount);
    }
}
