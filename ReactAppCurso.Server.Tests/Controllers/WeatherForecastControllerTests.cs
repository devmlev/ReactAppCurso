using Microsoft.AspNetCore.Mvc;
using ReactAppCurso.Server.Controllers;

namespace ReactAppCurso.Server.Tests.Controllers
{
    public class WeatherForecastControllerTests
    {
        [Fact]
        public void Get_ShouldReturnFiveWeatherForecasts()
        {
            var controller = new WeatherForecastController();

            var result = controller.Get();

            Assert.NotNull(result);
            Assert.Equal(5, result.Count());
        }

        [Fact]
        public void Get_ShouldReturnWeatherForecastsWithValidProperties()
        {
            var controller = new WeatherForecastController();

            var result = controller.Get().ToList();

            foreach (var forecast in result)
            {
                Assert.NotNull(forecast);
                Assert.True(forecast.Date >= DateOnly.FromDateTime(DateTime.Now));
                Assert.InRange(forecast.TemperatureC, -20, 54);
                Assert.NotNull(forecast.Summary);
                Assert.NotEmpty(forecast.Summary);
            }
        }

        [Fact]
        public void Get_ShouldReturnDifferentForecastsForFutureDates()
        {
            var controller = new WeatherForecastController();

            var result = controller.Get().ToList();

            var dates = result.Select(f => f.Date).ToList();
            Assert.Equal(5, dates.Distinct().Count());
        }

        [Fact]
        public void Get_ShouldReturnValidTemperatureFahrenheit()
        {
            var controller = new WeatherForecastController();

            var result = controller.Get().ToList();

            foreach (var forecast in result)
            {
                int expectedF = 32 + (int)(forecast.TemperatureC * 1.8);
                Assert.Equal(expectedF, forecast.TemperatureF);
            }
        }

        [Fact]
        public void Get_ShouldReturnSummaryFromPredefinedList()
        {
            var validSummaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
            var controller = new WeatherForecastController();

            var result = controller.Get().ToList();

            foreach (var forecast in result)
            {
                Assert.Contains(forecast.Summary, validSummaries);
            }
        }
    }
}
