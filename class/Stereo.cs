using CSharpObjects.constants;

namespace CSharpObjects.classes
{
    internal class Stereo
    {
        private readonly string brand;
        private readonly string color;

        public Stereo(string brand, string color) { 
            this.brand = brand;
            this.color = color;
            this.Power_state = false;
            this.mode = StereoMode.Radio;
            this.track_state = false;
            this.auxDevice = false;
        }

        // Properties public field
        public bool Power_state { get; set; } = false;
        public StereoMode mode { get; set; } // Stereo Mode
        public double? freq { get; set; } // Frequency in HZ
        public string? CDtrack { get; set; } // CDTrack only 1 CD, need Mode to play.
        public bool track_state { get; set; } // CD Track have a CD inside?
        public bool? auxDevice { get; set; } // auxDive On/Off 
        public double? lastFreq { get; set;}

        //methods
        public void Press_power_btn()
        {
            this.Power_state = !Power_state;
            Console.WriteLine($"Stero is {(Power_state ? "ON" : "OFF")}");
        }

        public void change_mode(StereoMode mode)
        {
            if (is_on())
            {
                if(this.mode == StereoMode.Aux && auxDevice is true)
                {
                    Console.WriteLine("The sound sent from the auxiliary connected device has stopped being heard.");
                }
                this.mode = mode;
                Console.WriteLine($"Change mode to {this.mode}");
            }
        }

        public void change_freq(double freq)
        {
            if (is_on())
            {
                if (this.mode == StereoMode.Radio)
                {
                    lastFreq = this.freq;
                    this.freq = freq;
                    Console.WriteLine($"The frequency {lastFreq} was changed to {freq}");
                }
                else
                {
                    Console.WriteLine($"The frequency {freq} is not exist.");
                }
            }
        }

        public void put_CDTrack(string CD)
        {
            // Read CD only put one CD per time
            if (is_on())
            {
                if(CDtrack == null) { 
                    this.CDtrack = CD;
                    this.track_state = true;
                }
                else
                {
                    Console.WriteLine($"you need taking out '{this.CDtrack}' first...");
                }

            }
        }

        public void Taking_out_CDTrack()
        {
            if(is_on() && this.track_state == true)
            {
                Console.WriteLine($"Taking out'{this.CDtrack}'");
                Thread.Sleep(1000);
                this.track_state = false;
            }
        }

        public void connect_device_to_aux()
        {
            if (is_on())
            {
                if(this.mode == StereoMode.Aux && auxDevice is false)
                {
                    Console.WriteLine("Device has been conected to AUX port.");
                    auxDevice = true;
                }
                else
                {
                    Console.WriteLine("[ERROR] Check the mode or a device is already connected.");
                }
            }
        }

        public void disconnect_device_to_aux()
        {
            if (is_on())
            {
                if(auxDevice == true)
                {
                    Console.WriteLine("Device as been disconected.");
                }
                else
                {
                    Console.WriteLine("No device connected.");
                }
            }
        }


        public bool is_on()
        {
            if (this.Power_state)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Stero is OFF");
                return false;
            }
        }

    }
}
