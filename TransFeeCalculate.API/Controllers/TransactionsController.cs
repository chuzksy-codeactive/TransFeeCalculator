using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TransFeeCalculator.Application.Interfaces;

namespace TransFeeCalculate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        public readonly ICalculateFeeService _calculateFeeService;
        public TransactionsController(ICalculateFeeService calculateFeeService)
        {
            _calculateFeeService = calculateFeeService ?? throw new ArgumentNullException(nameof(calculateFeeService));
        }

        [HttpGet]
        public IActionResult GetAllFees()
        {
            var transactinFee = _calculateFeeService.TransactionFee();

            return Ok(transactinFee);
        }
    }
}
