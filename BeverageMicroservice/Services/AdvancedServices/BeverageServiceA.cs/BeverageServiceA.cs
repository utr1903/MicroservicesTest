using System;
using System.Collections.Generic;
using System.Linq;
using BeverageMicroservice.Entities;
using BeverageMicroservice.Services.AdvancedService.BeverageServiceA.Models;
using BeverageMicroservice.Services.PrimitiveService.BeverageServiceP;
using BeverageMicroservice.Services.PrimitiveService.CategoryServiceP;

namespace BeverageMicroservice.Services.AdvancedService.BeverageServiceA
{
    public class BeverageServiceA : IBeverageServiceA
    {
        private readonly IBeverageServiceP _beverageServiceP;
        private readonly ICategoryServiceP _categoryServiceP;

        public BeverageServiceA(
            IBeverageServiceP beverageServiceP,
            ICategoryServiceP categoryServiceP)
        {
            _beverageServiceP = beverageServiceP;
            _categoryServiceP = categoryServiceP;
        }

        public IEnumerable<Beverage> GetBeverages()
        {
            return _beverageServiceP.Queryable().AsEnumerable();
        }

        public void InsertBeverage(InsertBeverageRequestModel dto)
        {
            var category = _categoryServiceP.GetById(dto.Categoryid);
            if (category == null)
                throw new Exception("Category not found");
            
            var beverage = new Beverage {
                Id = Guid.NewGuid(),
                Categoryid = dto.Categoryid,
                Name = dto.Name,
                Description = dto.Description
            };

            _beverageServiceP.Insert(beverage);
        }

        public void UpdateBeverage(UpdateBeverageRequestModel dto)
        {
            var beverage = _beverageServiceP.GetById(dto.Beverageid);
            if (beverage == null)
                throw new Exception("Beverage not found");
            
            if (dto.Categoryid.HasValue)
            {
                var category = _categoryServiceP.GetById(dto.Categoryid.Value);
                if (category == null)
                    throw new Exception("Category not found");
                
                beverage.Categoryid = dto.Categoryid.Value;
            }
            
            if (dto.Name != null)
                beverage.Name = dto.Name;
            
            if (dto.Description != null)
                beverage.Description = dto.Description;

            _beverageServiceP.Update(beverage);
        }
    }
}