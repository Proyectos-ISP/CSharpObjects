using CSharpObjects.constants;

namespace CSharpObjects.classes
{
    internal class Kettle
    {
        // Private fields unique data
        private string brand;
        private string? color;
        private string? material;
        private double? capacity_in_liters;

        // Constructor
        public Kettle(string brand, string color, string material, double capacity_in_liters)
        {
            this.brand = brand;
            this.color = color;
            this.material = material;
            this.capacity_in_liters = capacity_in_liters;
            this.Mode = KettlerMode.Mid; // default mode
            this.water_temperature = 0;
            this.Power_state = false;
        }

        // Properties public fields
        public KettlerMode Mode { get; set; }
        public bool Power_state { get; set; }
        public int water_temperature { get; set; }


        //methods
        public void Press_power_btn()
        {
            this.Power_state = !Power_state;
            this.water_temperature = 0;
            Console.WriteLine($"Electric Kettle is {(Power_state ? "ON" : "OFF")}.");
        }

        public void Change_mode(KettlerMode Mode)
        {
            if (this.Power_state)
            {
                this.Mode = Mode;
                Console.WriteLine($"Mode change to {this.Mode}");
            }
            else
            {
                Console.WriteLine($"[ERROR] Electric Kettle is {(this.Power_state ? "ON" : "OFF")}");
            }
        }

        public void heat_water()
        {
            if (this.Power_state)
            {
                // Min 1 - 60 C° | Mid 2 - 85 C° | Max 3 - 100 C°
                if(this.Mode == KettlerMode.Min) { 
                    while (this.water_temperature <= 60)
                    {
                        water_temperature++;
                        Console.Clear();
                        Console.WriteLine($"The kettle is getting hot: {this.water_temperature} C° ");
                        Thread.Sleep(100);
                        if (water_temperature == 60)
                        {
                            Console.WriteLine($"The water in kettle is ready. {this.water_temperature} C° ");
                            Press_power_btn();
                            break;
                        }

                    }
                }
                else if(this.Mode == KettlerMode.Mid)
                {
                    while (this.water_temperature <= 85)
                    {
                        water_temperature++;
                        Console.Clear();
                        Console.WriteLine($"The kettle is getting hot: {this.water_temperature} C° ");
                        Thread.Sleep(100);
                        if (water_temperature == 85)
                        {
                            Console.WriteLine($"The water in kettle is ready. {this.water_temperature} C° ");
                            Press_power_btn();
                            break;
                        }

                    }

                }
                else
                {
                    while (this.water_temperature <= 100)
                    {
                        water_temperature++;
                        Console.Clear();
                        Console.WriteLine($"The kettle is getting hot: {this.water_temperature} C° ");
                        Thread.Sleep(100);
                        if (water_temperature == 100)
                        {
                            Console.WriteLine($"The water in kettle is ready. {this.water_temperature} C° ");
                            Press_power_btn();
                            break;
                        }

                    }

                }
            }
            else
            {
                Console.WriteLine($"[ERROR] Electric Kettle is {(this.Power_state ? "ON" : "OFF")}");
            }
        }
    }

}