using System.Collections.Generic;
using BeverageMicroservice.Entities;
using BeverageMicroservice.Services.AdvancedService.BeverageServiceA.Models;

namespace BeverageMicroservice.Services.AdvancedService.BeverageServiceA
{
    public interface IBeverageServiceA
    {
        IEnumerable<Beverage> GetBeverages();
        void InsertBeverage(InsertBeverageRequestModel dto);
        void UpdateBeverage(UpdateBeverageRequestModel dto);
    }
}