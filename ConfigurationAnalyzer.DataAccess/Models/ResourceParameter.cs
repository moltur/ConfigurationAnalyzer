using System;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.DataAccess.Models
{
    public partial class ResourceParameter
    {
        public ResourceParameter()
        {
            ResourceParameterValue = new HashSet<ResourceParameterValue>();
        }

        public int ResourceParameterId { get; set; }
        public string ResourceParameterName { get; set; }
        public string ResourceParameterAlias { get; set; }
        public int? ResourceTypeId { get; set; }

        public virtual ResourceType ResourceType { get; set; }
        public virtual ICollection<ResourceParameterValue> ResourceParameterValue { get; set; }
    }
}
