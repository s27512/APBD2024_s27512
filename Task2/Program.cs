namespace Task2
{
    class Program
    {
        static List<ContainerShip> containerShips = new List<ContainerShip>();
        static List<Container> containers = new List<Container>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("List of container ships:");
                PrintContainerShips();

                Console.WriteLine("\nList of containers:");
                PrintContainers();

                Console.WriteLine("\nPossible actions:");
                Console.WriteLine("1. Add a container ship");
                Console.WriteLine("2. Remove a container ship");
                Console.WriteLine("3. Add a container");
                Console.WriteLine("4. Load a container onto a ship");
                Console.WriteLine("5. Unload a container from a ship");
                Console.WriteLine("6. Print information about a container");
                Console.WriteLine("7. Print information about a ship and its cargo");
                Console.WriteLine("8. Exit");

                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddContainerShip();
                        break;
                    case "2":
                        RemoveContainerShip();
                        break;
                    case "3":
                        AddContainer();
                        break;
                    case "4":
                        LoadContainerOnShip();
                        break;
                    case "5":
                        UnloadContainerFromShip();
                        break;
                    case "6":
                        PrintContainerInfo();
                        break;
                    case "7":
                        PrintShipInfo();
                        break;
                    case "8":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void PrintContainerShips()
        {
            if (containerShips.Count == 0)
            {
                Console.WriteLine("None");
                return;
            }

            foreach (var ship in containerShips)
            {
                Console.WriteLine($"- {ship.GetType().Name} (Speed={ship.MaxSpeed}, MaxContainerNum={ship.MaxContainerNumber}, MaxWeight={ship.MaxWeight})");
            }
        }

        static void PrintContainers()
        {
            if (containers.Count == 0)
            {
                Console.WriteLine("None");
                return;
            }

            foreach (var container in containers)
            {
                Console.WriteLine($"- {container.GetType().Name} (Serial={container.SerialNumber}, CargoMass={container.CargoMass})");
            }
        }

        static void AddContainerShip()
        {
            Console.WriteLine("Enter maximum speed:");
            int speed = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter maximum container number:");
            int maxContainerNum = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter maximum weight:");
            double maxWeight = double.Parse(Console.ReadLine());

            ContainerShip newShip = new ContainerShip(speed, maxContainerNum, maxWeight);
            containerShips.Add(newShip);

            Console.WriteLine("Container ship added successfully.");
        }

        static void RemoveContainerShip()
        {
            Console.WriteLine("Enter the index of the container ship to remove:");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < containerShips.Count)
            {
                containerShips.RemoveAt(index);
                Console.WriteLine("Container ship removed successfully.");
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }

        static void AddContainer()
        {
            Console.WriteLine("Select the type of container:");
            Console.WriteLine("1. Refrigerated");
            Console.WriteLine("2. Liquid");
            Console.WriteLine("3. Gas");
            string containerTypeChoice = Console.ReadLine();

            Container container = null;

            switch (containerTypeChoice)
            {
                case "1":
                    container = CreateRefrigeratedContainer();
                    break;
                case "2":
                    container = CreateLiquidContainer();
                    break;
                case "3":
                    container = CreateGasContainer();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            if (container != null)
            {
                containers.Add(container);
                Console.WriteLine("Container added successfully.");
            }
        }

        static Container CreateRefrigeratedContainer()
        {
            Console.WriteLine("Enter product type:");
            string productType = Console.ReadLine();

            Console.WriteLine("Enter temperature:");
            double temperature = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter cargo mass:");
            double cargoMass = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter height:");
            double height = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter tare weight:");
            double tareWeight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter depth:");
            double depth = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter max payload:");
            double maxPayload = double.Parse(Console.ReadLine());

            return new RefrigeratedContainer(productType, temperature, cargoMass, height, tareWeight, depth, maxPayload);
        }

        static Container CreateLiquidContainer()
        {
            Console.WriteLine("Enter cargo mass:");
            double cargoMass = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter height:");
            double height = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter tare weight:");
            double tareWeight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter depth:");
            double depth = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter max payload:");
            double maxPayload = double.Parse(Console.ReadLine());

            return new LiquidContainer(cargoMass, height, tareWeight, depth, maxPayload);
        }

        static Container CreateGasContainer()
        {
            Console.WriteLine("Enter pressure:");
            double pressure = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter cargo mass:");
            double cargoMass = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter height:");
            double height = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter tare weight:");
            double tareWeight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter depth:");
            double depth = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter max payload:");
            double maxPayload = double.Parse(Console.ReadLine());

            return new GasContainer(pressure, cargoMass, height, tareWeight, depth, maxPayload);
        }

        static void LoadContainerOnShip()
        {
            if (containerShips.Count == 0 || containers.Count == 0)
            {
                Console.WriteLine("No container ships or containers available.");
                return;
            }

            Console.WriteLine("Select a container ship to load onto:");
            for (int i = 0; i < containerShips.Count; i++)
            {
                Console.WriteLine($"{i}. {containerShips[i].GetType().Name}");
            }

            int shipIndex = int.Parse(Console.ReadLine());
            if (shipIndex < 0 || shipIndex >= containerShips.Count)
            {
                Console.WriteLine("Invalid ship index.");
                return;
            }

            Console.WriteLine("Select a container to load:");
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine($"{i}. {containers[i].GetType().Name} (Serial: {containers[i].SerialNumber})");
            }

            int containerIndex = int.Parse(Console.ReadLine());
            if (containerIndex < 0 || containerIndex >= containers.Count)
            {
                Console.WriteLine("Invalid container index.");
                return;
            }

            ContainerShip selectedShip = containerShips[shipIndex];
            Container selectedContainer = containers[containerIndex];

            try
            {
                selectedShip.AddContainer(selectedContainer);
                containers.RemoveAt(containerIndex);
                Console.WriteLine("Container loaded onto the ship successfully.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void UnloadContainerFromShip()
        {
            if (containerShips.Count == 0)
            {
                Console.WriteLine("No container ships available.");
                return;
            }

            Console.WriteLine("Select a container ship to unload from:");
            for (int i = 0; i < containerShips.Count; i++)
            {
                Console.WriteLine($"{i}. {containerShips[i].GetType().Name}");
            }

            int shipIndex = int.Parse(Console.ReadLine());
            if (shipIndex < 0 || shipIndex >= containerShips.Count)
            {
                Console.WriteLine("Invalid ship index.");
                return;
            }

            ContainerShip selectedShip = containerShips[shipIndex];

            Console.WriteLine("Select a container to unload:");
            for (int i = 0; i < selectedShip.Containers.Count; i++)
            {
                Console.WriteLine($"{i}. {selectedShip.Containers[i].GetType().Name} (Serial: {selectedShip.Containers[i].SerialNumber})");
            }

            int containerIndex = int.Parse(Console.ReadLine());
            if (containerIndex < 0 || containerIndex >= selectedShip.Containers.Count)
            {
                Console.WriteLine("Invalid container index.");
                return;
            }

            Container selectedContainer = selectedShip.Containers[containerIndex];
            selectedShip.RemoveContainer(selectedContainer);
            containers.Add(selectedContainer);

            Console.WriteLine("Container unloaded from the ship successfully.");
        }

        static void PrintContainerInfo()
        {
            if (containers.Count == 0)
            {
                Console.WriteLine("No containers available.");
                return;
            }

            Console.WriteLine("Select a container to print information:");
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine($"{i}. {containers[i].GetType().Name} (Serial: {containers[i].SerialNumber})");
            }

            int containerIndex = int.Parse(Console.ReadLine());
            if (containerIndex < 0 || containerIndex >= containers.Count)
            {
                Console.WriteLine("Invalid container index.");
                return;
            }

            Container selectedContainer = containers[containerIndex];
            Console.WriteLine("\nContainer Information:");
            Console.WriteLine($"Type: {selectedContainer.GetType().Name}");
            Console.WriteLine($"Serial Number: {selectedContainer.SerialNumber}");
            Console.WriteLine($"Cargo Mass: {selectedContainer.CargoMass} kg");
            Console.WriteLine($"Height: {selectedContainer.Height} cm");
            Console.WriteLine($"Tare Weight: {selectedContainer.TareWeight} kg");
            Console.WriteLine($"Depth: {selectedContainer.Depth} cm");
            Console.WriteLine($"Max Payload: {selectedContainer.MaxPayload} kg");

            if (selectedContainer is RefrigeratedContainer refrigeratedContainer)
            {
                Console.WriteLine($"Product Type: {refrigeratedContainer.ProductType}");
                Console.WriteLine($"Temperature: {refrigeratedContainer.Temperature}°C");
            }
            else if (selectedContainer is LiquidContainer liquidContainer)
            {
                Console.WriteLine("Container Type: Liquid Container");
            }
            else if (selectedContainer is GasContainer gasContainer)
            {
                Console.WriteLine($"Pressure: {gasContainer.Pressure} atm");
            }
        }

        static void PrintShipInfo()
        {
            if (containerShips.Count == 0)
            {
                Console.WriteLine("No container ships available.");
                return;
            }

            Console.WriteLine("Select a container ship to print information:");
            for (int i = 0; i < containerShips.Count; i++)
            {
                Console.WriteLine($"{i}. {containerShips[i].GetType().Name}");
            }

            int shipIndex = int.Parse(Console.ReadLine());
            if (shipIndex < 0 || shipIndex >= containerShips.Count)
            {
                Console.WriteLine("Invalid ship index.");
                return;
            }

            ContainerShip selectedShip = containerShips[shipIndex];
            Console.WriteLine("\nContainer Ship Information:");
            Console.WriteLine($"Type: {selectedShip.GetType().Name}");
            Console.WriteLine($"Max Speed: {selectedShip.MaxSpeed} knots");
            Console.WriteLine($"Max Container Capacity: {selectedShip.MaxContainerNumber}");
            Console.WriteLine($"Current Number of Containers: {selectedShip.Containers.Count}");
            Console.WriteLine($"Total Weight: {selectedShip.Containers.Sum(c => c.CargoMass + c.TareWeight)} kg");

            Console.WriteLine("\nList of Containers on the Ship:");
            foreach (var container in selectedShip.Containers)
            {
                Console.WriteLine($"- {container.GetType().Name} (Serial: {container.SerialNumber}, CargoMass: {container.CargoMass} kg)");
            }
        }
    }
}
