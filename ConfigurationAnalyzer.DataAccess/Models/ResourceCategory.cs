using System;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.DataAccess.Models
{
    public partial class ResourceCategory
    {
        public ResourceCategory()
        {
            Resource = new HashSet<Resource>();
            ResourceType = new HashSet<ResourceType>();
        }

        public int ResourceCategoryId { get; set; }
        public string ResourceCategoryName { get; set; }

        public virtual ICollection<Resource> Resource { get; set; }
        public virtual ICollection<ResourceType> ResourceType { get; set; }
    }
}
