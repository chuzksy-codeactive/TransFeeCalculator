using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TransFeeCalculator.Domain.IRepository;
using TransFeeCalculator.Domain.Models;

namespace TransFeeCalculator.Data.Repository
{
    public class TransSurChargeRepository : ITransSurChargeRepository
    {
        public Surcharge GetSurcharge(int amount)
        {
            var surcharges = GetSurcharges();

            var fee = surcharges.SingleOrDefault(x => amount >= x.MinAmount && amount <= x.MaxAmount);

            return fee;
        }

        public IEnumerable<Surcharge> GetSurcharges()
        {
            string directoryPath = Path.Combine(Environment.CurrentDirectory, @"wwwroot/Data");
            string path = $@"{directoryPath}/charges.config.json";

            var surchargeCollection = JsonConvert.DeserializeObject<SurchargeCollection>(File.ReadAllText(path));

            return surchargeCollection.Fees;
        }

        public int GetTransferAmount(int amount)
        {
            var charge = GetSurcharge(amount).FeeAmount;

            var transferAmount = amount - charge;

            return transferAmount;
        }
    }
}
