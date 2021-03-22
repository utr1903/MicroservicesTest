using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeverageMicroservice.Entities;
using BeverageMicroservice.Services.AdvancedService.BeverageServiceA;
using BeverageMicroservice.Services.AdvancedService.BeverageServiceA.Models;
using Microsoft.AspNetCore.Mvc;
using URF.Core.Abstractions;

namespace BeverageMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeverageController : ControllerBase
    {
        private readonly IBeverageServiceA _beverageServiceA;
        private readonly IUnitOfWork _unitOfWork;

        public BeverageController(
            IBeverageServiceA beverageServiceA,
            IUnitOfWork unitOfWork)
        {
            _beverageServiceA = beverageServiceA;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetBeverages")]
        public ActionResult<IEnumerable<Beverage>> GetBeverages()
        {
            if (!ModelState.IsValid)
                return ValidationProblem();
            
            try
            {
                var result = _beverageServiceA.GetBeverages();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("InsertBeverage")]
        public async Task<ActionResult> InsertBeverage([FromBody] InsertBeverageRequestModel dto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem();
            
            try
            {
                _beverageServiceA.InsertBeverage(dto);
                await _unitOfWork.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("UpdateBeverage")]
        public async Task<ActionResult> UpdateBeverage([FromBody] UpdateBeverageRequestModel dto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem();
            
            try
            {
                _beverageServiceA.UpdateBeverage(dto);
                await _unitOfWork.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}