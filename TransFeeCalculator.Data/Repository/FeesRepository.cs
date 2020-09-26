using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TransFeeCalculator.Domain.IRepository;
using TransFeeCalculator.Domain.Models;

namespace TransFeeCalculator.Data.Repository
{
    public class FeesRepository : IFeesRepository
    {
        public Fee GetFee(int amount)
        {
            var fees = GetFees();

            var fee = fees.SingleOrDefault(x => amount >= x.MinAmount && amount <= x.MaxAmount);

            return fee;
        }

        public IEnumerable<Fee> GetFees()
        {
            string directoryPath = Path.Combine(Environment.CurrentDirectory, @"wwwroot/Data");
            string path = $@"{directoryPath}/fees.config.json";

            var feesCollection = JsonConvert.DeserializeObject<FeesCollection>(File.ReadAllText(path));

            return feesCollection.Fees;
        }
    }
}
