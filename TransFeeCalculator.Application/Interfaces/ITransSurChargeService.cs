using TransFeeCalculator.Application.Models;

namespace TransFeeCalculator.Application.Interfaces
{
    public interface ITransSurChargeService
    {
        CustomerDebitDTO DebitTransaction(AmountDTO amount);
    }
}
