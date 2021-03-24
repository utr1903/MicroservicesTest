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

        #region BEVERAGE

        public IEnumerable<Beverage> GetBeverages()
        {
            return _beverageServiceP.Queryable().AsEnumerable();
        }

        public Beverage InsertBeverage(InsertBeverageRequestModel dto)
        {
            if (dto.Name != null)
                throw new Exception("Name of beverage not valid");

            if (dto.Price != null)
                throw new Exception("Price of beverage not valid");
            
            var category = _categoryServiceP.GetById(dto.Categoryid);
            if (category == null)
                throw new Exception("Category not found");
            
            var beverage = new Beverage {
                Id = Guid.NewGuid(),
                Categoryid = dto.Categoryid,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price.Value
            };

            _beverageServiceP.Insert(beverage);
            return beverage;
        }

        public Beverage UpdateBeverage(UpdateBeverageRequestModel dto)
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

            if (dto.Price != null)
                beverage.Price = dto.Price.Value;

            _beverageServiceP.Update(beverage);
            return beverage;
        }

        #endregion BEVERAGE

        #region CATEGORY

        public IEnumerable<Category> GetCategories()
        {
            return _categoryServiceP.Queryable().AsEnumerable();
        }

        public Category InsertCategory(InsertCategoryRequestModel dto)
        {
            var category = new Category {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description
            };

            _categoryServiceP.Insert(category);
            return category;
        }

        public Category UpdateCategory(UpdateCategoryRequestModel dto)
        {
            var category = _categoryServiceP.GetById(dto.Categoryid);
            if (category == null)
                throw new Exception("Category not found");
            
            if (dto.Name != null)
                category.Name = dto.Name;
            
            if (dto.Description != null)
                category.Description = dto.Description;

            _categoryServiceP.Update(category);
            return category;
        }

        #endregion CATEGORY
    }
}