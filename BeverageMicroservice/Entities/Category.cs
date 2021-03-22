using System;
using System.Collections.Generic;
using URF.Core.EF.Trackable;

#nullable disable

namespace BeverageMicroservice.Entities
{
    public partial class Category : Entity
    {
        public Category()
        {
            Beverages = new HashSet<Beverage>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Beverage> Beverages { get; set; }
    }
}
