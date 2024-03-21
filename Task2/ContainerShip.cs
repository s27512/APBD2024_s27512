namespace Task2
{
    public class ContainerShip
    {
        public ContainerShip(int maxSpeed, int maxContainerNumber, double maxWeight)
        {
            MaxSpeed = maxSpeed;
            MaxContainerNumber = maxContainerNumber;
            MaxWeight = maxWeight;
        }

        public List<Container> Containers { get; private set; } = new List<Container>();
        public int MaxSpeed { get; }
        public int MaxContainerNumber { get; }
        public double MaxWeight { get; }

        public void AddContainer(Container container)
        {
            if (Containers.Count >= MaxContainerNumber)
            {
                throw new InvalidOperationException("Container ship is full.");
            }

            Containers.Add(container);
        }

        public void RemoveContainer(Container container)
        {
            Containers.Remove(container);
        }

        public void LoadContainers(List<Container> containers)
        {
            if (containers.Count + Containers.Count > MaxContainerNumber)
            {
                throw new InvalidOperationException("Cannot load all containers, ship will exceed capacity.");
            }

            Containers.AddRange(containers);
        }

        public void UnloadContainers()
        {
            Containers.Clear();
        }

        public void ReplaceContainer(Container oldContainer, Container newContainer)
        {
            int index = Containers.IndexOf(oldContainer);
            if (index != -1)
            {
                Containers[index] = newContainer;
            }
        }

        public void PrintShipInfo()
        {
            Console.WriteLine($"Container Ship Info:");
            Console.WriteLine($"Max Speed: {MaxSpeed} knots");
            Console.WriteLine($"Max Container Capacity: {MaxContainerNumber}");
            Console.WriteLine($"Current Number of Containers: {Containers.Count}");
            Console.WriteLine($"Total Weight: {Containers.Sum(c => c.CargoMass + c.TareWeight)} kg");
        }

        public void PrintContainerInfo(Container container)
        {
            Console.WriteLine($"Container Info:");
            Console.WriteLine($"Serial Number: {container.SerialNumber}");
            Console.WriteLine($"Cargo Mass: {container.CargoMass} kg");
            Console.WriteLine($"Height: {container.Height} cm");
            Console.WriteLine($"Tare Weight: {container.TareWeight} kg");
            Console.WriteLine($"Depth: {container.Depth} cm");
            Console.WriteLine($"Max Payload: {container.MaxPayload} kg");

            if (container is RefrigeratedContainer refrigeratedContainer)
            {
                Console.WriteLine($"Product Type: {refrigeratedContainer.ProductType}");
                Console.WriteLine($"Temperature: {refrigeratedContainer.Temperature}°C");
            }
            else if (container is LiquidContainer liquidContainer)
            {
                Console.WriteLine("Container Type: Liquid Container");
            }
            else if (container is GasContainer gasContainer)
            {
                Console.WriteLine($"Pressure: {gasContainer.Pressure} atm");
            }
        }
    }
}
#