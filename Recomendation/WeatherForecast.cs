namespace Recommendation
{
    public static class WeatherForecast
    {
        public static List<double> GetFiveDaysTemperatura()
        {
            return new List<double> { 23, 20, 20, 19, 20 };
        }
        public static List<bool> GetFiveDaysPrecipitation() 
        {
            return new List<bool> { true, false, false, false, false };
        }

    }
}
