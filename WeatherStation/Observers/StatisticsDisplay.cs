using System;
using System.Collections;

namespace WeatherStation
{
    class StatisticsDisplay : IObserver, IDisplayElement
    {
        private ArrayList _temperature, _humidity;
        private float _minTemperature, _averageTemperature, _maxTemperature;
        private float _minHumidity, _averageHumidity, _maxHumidity;
        private ISubject _weatherData;

        internal ISubject WeatherData { get => _weatherData; set => _weatherData = value; }
        public float MinTemperature { get => _minTemperature; set => _minTemperature = value; }
        public float AverageTemperature { get => _averageTemperature; set => _averageTemperature = value; }
        public float MaxTemperature { get => _maxTemperature; set => _maxTemperature = value; }
        public float MinHumidity { get => _minHumidity; set => _minHumidity = value; }
        public float AverageHumidity { get => _averageHumidity; set => _averageHumidity = value; }
        public float MaxHumidity { get => _maxHumidity; set => _maxHumidity = value; }

        public StatisticsDisplay(ISubject weatherData)
        {
            _temperature = new ArrayList();
            _humidity = new ArrayList();
            WeatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void Update(float temperature, float humidity, float pressure)
        {
            _temperature.Add(temperature);
            _humidity.Add(humidity);
            for (int i = 0; i < _humidity.Count; i++)
            {
                AverageTemperature += (float)_temperature[i];
                AverageHumidity += (float)_humidity[i];
            }
            AverageHumidity /= _humidity.Count;
            AverageTemperature /= _temperature.Count;

            if (MinHumidity > humidity)
            {
                MinHumidity = humidity;
            }
            else if(MaxHumidity < humidity)
            {
                MaxHumidity = humidity;
            }
            if (MinTemperature > temperature)
            {
                MinTemperature = temperature;
            }else if (MaxTemperature < temperature)
            {
                MaxTemperature = temperature;
            }

            Display();
        }

        public void Display()
        {
            Console.WriteLine("Minimal temperature : " + MinTemperature + "C degrees and minimal humidity : " + MinHumidity + "% humidity");
            Console.WriteLine("Average temperature : " + AverageTemperature + "C degrees and average humidity : " + AverageHumidity + "% humidity");
            Console.WriteLine("Maximal temperature : " + MaxTemperature + "C degrees and maximal humidity : " + MaxHumidity + "% humidity");
            Console.WriteLine("==============================================");
        }
    }
}
