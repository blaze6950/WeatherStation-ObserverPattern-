namespace WeatherStation
{
    interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }
    interface IObserver
    {
        void Update(float temp, float humidity, float pressure);
    }

    interface IDisplayElement
    {
        void Display();
    }
}
