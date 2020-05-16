using System;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.DataAccess.Models
{
    public partial class ResourceType
    {
        public ResourceType()
        {
            Resource = new HashSet<Resource>();
            ResourceParameter = new HashSet<ResourceParameter>();
        }

        public int ResourceTypeId { get; set; }
        public string ResourceTypeName { get; set; }
        public int? ResourceCategoryId { get; set; }

        public virtual ResourceCategory ResourceCategory { get; set; }
        public virtual ICollection<Resource> Resource { get; set; }
        public virtual ICollection<ResourceParameter> ResourceParameter { get; set; }
    }
}
