using System;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.DataAccess.Models
{
    public partial class Resource
    {
        public Resource()
        {
        }

        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public int? ResourceTypeId { get; set; }
        public int? ResourceCategoryId { get; set; }
        public decimal Price { get; set; }

        public virtual ResourceType ResourceType { get; set; }
    }
}
