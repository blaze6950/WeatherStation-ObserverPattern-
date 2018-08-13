using System;

namespace WeatherStation
{
    class ForecastDisplay : IObserver, IDisplayElement
    {
        private float _temperature;
        private float _humidity;
        private float _pressure;
        private ISubject _weatherData;

        public float Temperature { get => _temperature; set => _temperature = value; }
        public float Humidity { get => _humidity; set => _humidity = value; }
        public float Pressure { get => _pressure; set => _pressure = value; }
        internal ISubject WeatherData { get => _weatherData; set => _weatherData = value; }

        public ForecastDisplay(ISubject weatherData)
        {
            WeatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void Update(float temperature, float humidity, float pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
            Display();
        }

        public void Display()
        {
            Console.WriteLine("Current conditions : " + Pressure + " mm hg" + Temperature + "C degrees and " + Humidity + "% humidity");
            Console.WriteLine("==============================================");
        }
    }
}
