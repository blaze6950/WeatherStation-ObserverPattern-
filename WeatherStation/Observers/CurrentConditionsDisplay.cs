using System;

namespace WeatherStation
{
    class CurrentConditionsDisplay : IObserver, IDisplayElement
    {
        private float _temperature;
        private float _humidity;
        private ISubject _weatherData;

        public float Temperature { get => _temperature; set => _temperature = value; }
        public float Humidity { get => _humidity; set => _humidity = value; }
        internal ISubject WeatherData { get => _weatherData; set => _weatherData = value; }

        public CurrentConditionsDisplay(ISubject weatherData)
        {
            WeatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void Update(float temperature, float humidity, float pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Display();
        }

        public void Display()
        {
            Console.WriteLine("Current conditions : " + Temperature + "C degrees and " + Humidity + "% humidity");
            Console.WriteLine("==============================================");
        }
    }
}
