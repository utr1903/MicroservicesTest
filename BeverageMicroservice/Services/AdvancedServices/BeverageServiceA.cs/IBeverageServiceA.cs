using System.Collections.Generic;
using BeverageMicroservice.Entities;
using BeverageMicroservice.Services.AdvancedService.BeverageServiceA.Models;

namespace BeverageMicroservice.Services.AdvancedService.BeverageServiceA
{
    public interface IBeverageServiceA
    {
        IEnumerable<Beverage> GetBeverages();
        Beverage InsertBeverage(InsertBeverageRequestModel dto);
        Beverage UpdateBeverage(UpdateBeverageRequestModel dto);

        IEnumerable<Category> GetCategories();
        Category InsertCategory(InsertCategoryRequestModel dto);
        Category UpdateCategory(UpdateCategoryRequestModel dto);
    }
}