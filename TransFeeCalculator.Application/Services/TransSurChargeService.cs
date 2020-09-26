using System;
using TransFeeCalculator.Application.Interfaces;
using TransFeeCalculator.Application.Models;
using TransFeeCalculator.Domain.IRepository;

namespace TransFeeCalculator.Application.Services
{
    public class TransSurChargeService : ITransSurChargeService
    {
        public readonly ITransSurChargeRepository _transSurChargeRepository;

        public TransSurChargeService(ITransSurChargeRepository transSurChargeRepository)
        {
            _transSurChargeRepository = transSurChargeRepository ?? throw new ArgumentNullException(nameof(transSurChargeRepository));
        }
        public CustomerDebitDTO DebitTransaction(AmountDTO dto)
        {
            var charge = _transSurChargeRepository.GetSurcharge(dto.Amount);
            var transferAmount = _transSurChargeRepository.GetTransferAmount(dto.Amount);

            if (charge.FeeAmount > dto.Amount)
            {
                throw new ArgumentException("The amount is too low to transfer");
            }

            if (charge == null)
            {
                throw new ArgumentNullException("Sorry! Something went wrong. Try again.");
            }

            var debitInfo = new CustomerDebitDTO
            {
                Amount = transferAmount + charge.FeeAmount,
                TransferAmount = transferAmount,
                Charge = charge.FeeAmount,
                DebitAmount = transferAmount + charge.FeeAmount
            };

            return debitInfo;
        }
    }
}
