using System;

namespace Task2
{
    public abstract class Container
    {
        protected Container(string serialNumber, double cargoMass, double height, double tareWeight, double depth, double maxPayload)
        {
            SerialNumber = serialNumber;
            CargoMass = cargoMass;
            Height = height;
            TareWeight = tareWeight;
            Depth = depth;
            MaxPayload = maxPayload;
        }

        public string SerialNumber { get; }
        public double CargoMass { get; protected set; }
        public double Height { get; }
        public double TareWeight { get; }
        public double Depth { get; }
        public double MaxPayload { get; }

        public abstract void LoadCargo(double mass);
        public abstract void EmptyCargo();

        private static int containerCount = 1;

        protected static string GenerateSerialNumber(string type)
        {
            string serial = $"KON-{type}-C-{containerCount}";
            containerCount++;
            return serial;
        }
    }
}