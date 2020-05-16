using System;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.DataAccess.Models
{
    public partial class ResourceParameterValue
    {
        public int ResourceParameterValueId { get; set; }
        public string ParameterValue { get; set; }
        public int? ResourceParameterId { get; set; }
        public int? ResourceId { get; set; }

        public virtual Resource Resource { get; set; }
        public virtual ResourceParameter ResourceParameter { get; set; }
    }
}
