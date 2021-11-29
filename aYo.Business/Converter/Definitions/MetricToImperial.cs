using aYo.Business.Converter.Abstracts;
using aYo.Database.Abstract;
using aYo.Database.Entities;
using aYo.Database.Entities.Rate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aYo.Business.Converter.Definitions
{
    public class MetricToImperial : IMetricToImperial
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<MetricRate> _metricRateRepository;
        public MetricToImperial(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _metricRateRepository = unitOfWork.Repository<MetricRate>();
        }

        public async Task<decimal> Calculate(int metricId, int imperialId, decimal input)
        {
            var metric = await _metricRateRepository.GetByFirstOrDefaultAsync(i => i.ImperialId == imperialId && i.MetricId == metricId);
            if (metric == null) throw new NullReferenceException();
            var result = input / metric.Value;
            return result;
        }
    }
}
