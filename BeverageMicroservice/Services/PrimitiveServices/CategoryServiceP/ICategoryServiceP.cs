using System;
using BeverageMicroservice.Entities;
using URF.Core.Abstractions.Services;

namespace BeverageMicroservice.Services.PrimitiveService.CategoryServiceP
{
    public interface ICategoryServiceP : IService<Category>
    {
        Category GetById(Guid categoryId);
    }
}