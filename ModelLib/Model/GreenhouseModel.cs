namespace ModelLib.Model
{
    public class GreenhouseModel
    {
        private string _name;
        private int _humidity;
        private int _temperature;
        private int _lightLevel;

        public GreenhouseModel(int id, string name, int humidity, int temperature, int lightLevel)
        {
            Id = id;
            _name = name;
            _humidity = humidity;
            _temperature = temperature;
            _lightLevel = lightLevel;
        }
        public GreenhouseModel()
        {
        }

        public int Id { get; set; }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Humidity
        {
            get => _humidity;
            set => _humidity = value;
        }

        public int Temperature
        {
            get => _temperature;
            set => _temperature = value;
        }

        public int LightLevel
        {
            get => _lightLevel;
            set => _lightLevel = value;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Humidity: {Humidity}, Temperature: {Temperature}, Light Level: {LightLevel}";
        }
    }
}
