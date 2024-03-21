namespace Task2
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        public LiquidContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload)
            : base(GenerateSerialNumber("L"), cargoMass, height, tareWeight, depth, maxPayload)
        {
        }

        public override void EmptyCargo()
        {
            CargoMass = 0;
        }

        public override void LoadCargo(double mass)
        {
            if (mass > MaxPayload * 0.9)
            {
                NotifyHazard("Attempted to load cargo beyond 90% capacity.");
            }
            CargoMass = mass;
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"Hazard notification: Container {SerialNumber} - {message}");
        }
    }
}