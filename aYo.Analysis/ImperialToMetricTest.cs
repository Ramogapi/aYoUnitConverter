using aYo.Business.Converter.Abstracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace aYo.Analysis
{
    public class ImperialToMetricTest: IClassFixture<InversionOfControl>
    {
        private readonly ServiceProvider _serviceProvider;
        public ImperialToMetricTest(InversionOfControl fixture) => _serviceProvider = fixture.ServiceProvider;

        [Fact]
        public async void Positive()
        {
            try
            {
                var result = await _serviceProvider.GetService<IImperialToMetric>().Calculate(1, 1, 3);
                Assert.True(result > 0);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async void Negative()
        {
            try
            {
                await _serviceProvider.GetService<IImperialToMetric>().Calculate(0, 1, 3);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }
    }
}
