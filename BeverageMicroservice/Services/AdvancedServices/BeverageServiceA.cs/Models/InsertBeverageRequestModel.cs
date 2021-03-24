using System;

namespace BeverageMicroservice.Services.AdvancedService.BeverageServiceA.Models
{
    public class InsertBeverageRequestModel
    {
        public Guid Categoryid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float? Price { get; set; }
    }
}