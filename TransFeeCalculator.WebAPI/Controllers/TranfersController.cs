using Microsoft.AspNetCore.Mvc;
using System;
using TransFeeCalculator.Application.Interfaces;
using TransFeeCalculator.Application.Models;

namespace TransFeeCalculate.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TranfersController : ControllerBase
    {
        public readonly ICalculateFeeService _calculateFeeService;
        public TranfersController(ICalculateFeeService calculateFeeService)
        {
            _calculateFeeService = calculateFeeService ?? throw new ArgumentNullException(nameof(calculateFeeService));
        }

        /// <summary>
        /// The method computes the expected charge base on the amount
        /// </summary>
        /// <remarks>
        /// the charge is based on the content of he configuration file.
        /// </remarks>
        /// <param name="amount">The amount of money the customer wants to transfer</param>
        /// <returns>Returns the transaction object</returns>
        [HttpPost]
        public IActionResult Transfer(AmountDTO amount)
        {
            try
            {
                var transactinFee = _calculateFeeService.TransferTransaction(amount);

                return Ok(new
                {
                    success = true,
                    message = "Your transfer was successfully",
                    data = transactinFee
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message,
                    data = new { }
                });
            }
        }
    }
}
