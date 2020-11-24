namespace ModelLib.Model
{
    public class PlanteModel
    {
        private int _id;
        private int _humidity;

        public PlanteModel(int id, int humidity)
        {
            Id = id;
            _humidity = humidity;
        }

        public PlanteModel()
        {
        }

        public int Id { get; set; }

        public int Humidity
        {
            get => _humidity;
            set => _humidity = value;
        }
    }
}