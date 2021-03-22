using System;
using BeverageMicroservice.Entities;
using URF.Core.Abstractions.Trackable;
using URF.Core.Services;

namespace BeverageMicroservice.Services.PrimitiveService.CategoryServiceP
{
    public class CategoryServiceP : Service<Category>, ICategoryServiceP
    {
        public CategoryServiceP(ITrackableRepository<Category> repository) : base(repository)
        {
        }

        public Category GetById(Guid categoryId) =>
            Repository.FindAsync(categoryId).Result;
    }
}