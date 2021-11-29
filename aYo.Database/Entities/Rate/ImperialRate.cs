using System;
using System.Collections.Generic;
using System.Text;

namespace aYo.Database.Entities.Rate
{
    public class ImperialRate: EntityBase
    {
        public int ImperialId { get; set; }
        public decimal Value { get; set; }
        public int MetricId { get; set; }
        public virtual Imperial Imperial { get; set; }
        public virtual Metric Metric { get; set; }
    }
}
