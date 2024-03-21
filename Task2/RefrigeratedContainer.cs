namespace Task2
{
    public class RefrigeratedContainer : Container
    {
        public string ProductType { get; private set; }
        public double Temperature { get; private set; }

        public RefrigeratedContainer(string productType, double temperature, double cargoMass, double height, double tareWeight, double depth, double maxPayload)
            : base(GenerateSerialNumber("C"), cargoMass, height, tareWeight, depth, maxPayload)
        {
            ProductType = productType;
            Temperature = temperature;
        }

        public override void EmptyCargo()
        {
            CargoMass = 0;
        }

        public override void LoadCargo(double mass)
        {
            if (mass > MaxPayload)
            {
                throw new OverfillException("Cargo mass exceeds maximum payload.");
            }
            CargoMass = mass;
        }
    }
}