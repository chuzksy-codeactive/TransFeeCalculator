using System.Collections.Generic;
using TransFeeCalculator.Domain.Models;

namespace TransFeeCalculator.Domain.IRepository
{
    public interface ITransSurChargeRepository
    {
        IEnumerable<Surcharge> GetSurcharges();
        Surcharge GetSurcharge(int amount);
        int GetTransferAmount(int amount);
    }
}
