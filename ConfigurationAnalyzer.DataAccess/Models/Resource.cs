using System;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.DataAccess.Models
{
    public partial class Resource
    {
        public Resource()
        {
            ResourceParameterValue = new HashSet<ResourceParameterValue>();
        }

        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public int? ResourceTypeId { get; set; }
        public int? ResourceCategoryId { get; set; }
        public decimal Price { get; set; }

        public virtual ResourceCategory ResourceCategory { get; set; }
        public virtual ResourceType ResourceType { get; set; }
        public virtual ICollection<ResourceParameterValue> ResourceParameterValue { get; set; }
    }
}
