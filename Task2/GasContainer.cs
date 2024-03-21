namespace Task2
{
    public class GasContainer : Container, IHazardNotifier
    {
        public double Pressure { get; private set; }

        public GasContainer(double pressure, double cargoMass, double height, double tareWeight, double depth, double maxPayload)
            : base(GenerateSerialNumber("G"), cargoMass, height, tareWeight, depth, maxPayload)
        {
            Pressure = pressure;
        }

        public override void EmptyCargo()
        {
            CargoMass *= 0.05;
        }

        public override void LoadCargo(double mass)
        {
            if (mass > MaxPayload)
            {
                NotifyHazard("Cargo mass exceeds maximum payload.");
            }
            CargoMass = mass;
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"Hazard notification: Container {SerialNumber} - {message}");
        }
    }
}