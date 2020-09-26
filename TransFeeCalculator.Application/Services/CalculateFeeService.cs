using System;
using TransFeeCalculator.Application.Interfaces;
using TransFeeCalculator.Application.Models;
using TransFeeCalculator.Domain.IRepository;

namespace TransFeeCalculator.Application.Services
{
    public class CalculateFeeService : ICalculateFeeService
    {
        public readonly IFeesRepository _feesRepository;
        public CalculateFeeService(IFeesRepository feesRepository)
        {
            _feesRepository = feesRepository ?? throw new ArgumentNullException(nameof(feesRepository));
        }

        public CustomerTransferDTO TransferTransaction(AmountDTO dto)
        {
            var fee = _feesRepository.GetFee(dto.Amount);

            if (fee == null)
            {
                throw new ArgumentNullException("Sorry! Something went wrong. Try again.");
            }

            var transferInfo = new CustomerTransferDTO
            {
                TransferAmount = dto.Amount,
                ExpectedCharge = dto.Amount + fee.FeeAmount,
                Charge = fee.FeeAmount
            };

            return transferInfo;
        }
    }
}
