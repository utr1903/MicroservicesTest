using System;

namespace BeverageMicroservice.Services.AdvancedService.BeverageServiceA.Models
{
    public class UpdateCategoryRequestModel
    {
        public Guid Categoryid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}