using aYo.Business.Converter.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aYo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitConverterController : ControllerBase
    {
        private readonly IImperialToMetric _imperialToMetric;
        private readonly IMetricToImperial _metricToImperial;
        public UnitConverterController(IImperialToMetric imperialToMetric, IMetricToImperial metricToImperial)
        {
            _imperialToMetric = imperialToMetric;
            _metricToImperial = metricToImperial;
        }

        [HttpGet("GetImperialToMetric")]
        public async Task<IActionResult> ImperialToMetric(int imperialId, int metricId, decimal input)
        {
            var result = await _imperialToMetric.Calculate(imperialId, metricId, input);
            return Ok(result);
        }

        [HttpGet("GetMetricToImperial")]
        public async Task<IActionResult> MetricToImperial(int metricId, int imperialId, decimal input)
        {
            var result = await _metricToImperial.Calculate(metricId, imperialId, input);
            return Ok(result);
        }
    }
}
