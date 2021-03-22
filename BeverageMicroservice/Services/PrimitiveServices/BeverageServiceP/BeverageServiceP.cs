using System;
using BeverageMicroservice.Entities;
using URF.Core.Abstractions.Trackable;
using URF.Core.EF.Trackable;
using URF.Core.Services;

namespace BeverageMicroservice.Services.PrimitiveService.BeverageServiceP
{
    public class BeverageServiceP : Service<Beverage>, IBeverageServiceP
    {
        public BeverageServiceP(ITrackableRepository<Beverage> repository) : base(repository)
        {
        }

        public Beverage GetById(Guid beverageId) =>
            Repository.FindAsync(beverageId).Result;
    }
}