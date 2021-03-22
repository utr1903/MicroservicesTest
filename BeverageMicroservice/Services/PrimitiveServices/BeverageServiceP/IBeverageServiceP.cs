using System;
using BeverageMicroservice.Entities;
using URF.Core.Abstractions.Services;

namespace BeverageMicroservice.Services.PrimitiveService.BeverageServiceP
{
    public interface IBeverageServiceP : IService<Beverage>
    {
        Beverage GetById(Guid beverageId);
    }
}