namespace TransFeeCalculator.Application.Models
{
    public class CustomerTransferDTO
    {
        public int TransferAmount { get; set; }
        public int ExpectedCharge { get; set; }
        public int Charge { get; set; }
    }
}
