namespace ModelLib.Model
{
    public class PlanteModel
    {
        private string _name;
        private int _humidity;
        private int _nutrition;

        public PlanteModel(int id, string name, int humidity, int nutrition)
        {
            Id = id;
            _name = name;
            _humidity = humidity;
            _nutrition = nutrition;
        }

        public PlanteModel()
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

        public int Nutrition
        {
            get => _nutrition;
            set => _nutrition = value;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Humidity: {Humidity}, Nutrition: {Nutrition}";
        }
    }
}