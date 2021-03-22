using System.Collections.Generic;
using BeverageMicroservice.Entities;

namespace BeverageMicroservice.Services.AdvancedService.BeverageServiceA
{
    public interface IBeverageServiceA
    {
        IEnumerable<Beverage> GetBeverages();
    }
}