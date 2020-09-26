using TransFeeCalculator.Application.Models;

namespace TransFeeCalculator.Application.Interfaces
{
    public interface ICalculateFeeService
    {
        CustomerTransferDTO TransferTransaction(AmountDTO amount);
    }
}
