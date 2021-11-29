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
    public class ImperialToMetric: IImperialToMetric
    {
        private readonly IRepository<ImperialRate> _imperialRateRepository;
        public ImperialToMetric(IUnitOfWork unitOfWork)
        {
            _imperialRateRepository = unitOfWork.Repository<ImperialRate>();
        }

        public async Task<decimal> Calculate(int imperialId, int metricId, decimal input)
        {
            var imperial = await _imperialRateRepository.GetByFirstOrDefaultAsync(i => i.ImperialId == imperialId && i.MetricId == metricId);
            if (imperial == null) throw new NullReferenceException();
            var result = input * imperial.Value;
            return result;
        }
    }
}
