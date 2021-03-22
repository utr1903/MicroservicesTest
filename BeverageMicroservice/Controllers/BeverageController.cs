using System.Collections.Generic;
using BeverageMicroservice.Entities;
using BeverageMicroservice.Services.AdvancedService.BeverageServiceA;
using Microsoft.AspNetCore.Mvc;

namespace BeverageMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeverageController : ControllerBase
    {
        private readonly IBeverageServiceA _beverageServiceA;

        public BeverageController(
            IBeverageServiceA beverageServiceA)
        {
            _beverageServiceA = beverageServiceA;
        }

        [HttpGet]
        public IEnumerable<Beverage> Get()
        {
            var result = _beverageServiceA.GetBeverages();
            return result;
        }
    }
}