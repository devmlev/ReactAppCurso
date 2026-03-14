using ReactAppCurso.Server;

namespace ReactAppCurso.Server.Tests
{
    public class WeatherForecastTests
    {
        [Fact]
        public void WeatherForecast_ShouldSetAndGetDate()
        {
            var forecast = new WeatherForecast();
            var expectedDate = new DateOnly(2024, 1, 15);

            forecast.Date = expectedDate;

            Assert.Equal(expectedDate, forecast.Date);
        }

        [Fact]
        public void WeatherForecast_ShouldSetAndGetTemperatureC()
        {
            var forecast = new WeatherForecast();
            var expectedTemp = 25;

            forecast.TemperatureC = expectedTemp;

            Assert.Equal(expectedTemp, forecast.TemperatureC);
        }

        [Fact]
        public void WeatherForecast_ShouldSetAndGetSummary()
        {
            var forecast = new WeatherForecast();
            var expectedSummary = "Warm";

            forecast.Summary = expectedSummary;

            Assert.Equal(expectedSummary, forecast.Summary);
        }

        [Theory]
        [InlineData(0, 32)]
        [InlineData(100, 212)]
        [InlineData(-40, -40)]
        [InlineData(25, 77)]
        [InlineData(-20, -4)]
        public void TemperatureF_ShouldConvertFromCelsiusToFahrenheit(int celsius, int expectedFahrenheit)
        {
            var forecast = new WeatherForecast
            {
                TemperatureC = celsius
            };

            Assert.Equal(expectedFahrenheit, forecast.TemperatureF);
        }

        [Fact]
        public void WeatherForecast_ShouldAllowNullSummary()
        {
            var forecast = new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TemperatureC = 20,
                Summary = null
            };

            Assert.Null(forecast.Summary);
        }

        [Fact]
        public void TemperatureF_ShouldUpdateDynamicallyWhenTemperatureCChanges()
        {
            var forecast = new WeatherForecast
            {
                TemperatureC = 0
            };

            Assert.Equal(32, forecast.TemperatureF);

            forecast.TemperatureC = 100;

            Assert.Equal(212, forecast.TemperatureF);
        }
    }
}
