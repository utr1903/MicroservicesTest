using System;
using System.Collections.Generic;
using URF.Core.EF.Trackable;

#nullable disable

namespace BeverageMicroservice.Entities
{
    public partial class Beverage : Entity
    {
        public Guid Id { get; set; }
        public Guid Categoryid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public virtual Category Category { get; set; }
    }
}
