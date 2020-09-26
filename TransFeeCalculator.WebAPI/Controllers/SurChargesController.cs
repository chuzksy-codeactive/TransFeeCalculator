using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransFeeCalculator.Application.Interfaces;
using TransFeeCalculator.Application.Models;

namespace TransFeeCalculator.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SurChargesController : ControllerBase
    {
        public readonly ITransSurChargeService _transSurChargeService;

        public SurChargesController(ITransSurChargeService transSurChargeService)
        {
            _transSurChargeService = transSurChargeService ?? throw new ArgumentNullException(nameof(transSurChargeService));
        }

        /// <summary>
        /// The method uses the amount configuration file to compute the advised transfer
        /// Amount and the amount the customer will be debited.
        /// </summary>
        /// <param name="amount">The amount of money the customer wants to transfer</param>
        /// <returns>Returns a debited info object</returns>
        [HttpPost]
        public IActionResult Surcharge(AmountDTO amount)
        {
            try
            {
                var debit = _transSurChargeService.DebitTransaction(amount);

                return Ok(new
                {
                    success = true,
                    message = "Your transfer was successfully",
                    data = debit
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
