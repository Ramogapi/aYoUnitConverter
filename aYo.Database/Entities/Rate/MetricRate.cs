using System;
using System.Collections.Generic;
using System.Text;

namespace aYo.Database.Entities.Rate
{
    public class MetricRate: EntityBase
    {        
        public int MetricId { get; set; }
        public decimal Value { get; set; }
        public int ImperialId { get; set; }
        public virtual Metric Metric { get; set; }
        public virtual Imperial Imperial { get; set; }
    }
}
