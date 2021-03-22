using System.Collections.Generic;
using System.Linq;
using BeverageMicroservice.Entities;
using BeverageMicroservice.Services.PrimitiveService.BeverageServiceP;

namespace BeverageMicroservice.Services.AdvancedService.BeverageServiceA
{
    public class BeverageServiceA : IBeverageServiceA
    {
        private readonly IBeverageServiceP _beverageServiceP;

        public BeverageServiceA(IBeverageServiceP beverageServiceP)
        {
            _beverageServiceP = beverageServiceP;
        }

        public IEnumerable<Beverage> GetBeverages()
        {
            return _beverageServiceP.Queryable().AsEnumerable();
        }
    }
}