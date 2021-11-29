using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aYo.Business.Converter.Abstracts
{
    public interface IImperialToMetric
    {
        Task<decimal> Calculate(int imperialId, int metricId, decimal input);
    }
}
