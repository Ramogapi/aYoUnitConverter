using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aYo.Business.Converter.Abstracts
{
    public interface IMetricToImperial
    {
        Task<decimal> Calculate(int metricId, int imperialId, decimal input);
    }
}
