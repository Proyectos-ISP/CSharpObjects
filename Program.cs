
using CSharpObjects.constants;
using CSharpObjects.classes;

internal class Program
{
    private static void Main(string[] args)
    {
        Kettle myKettle = new Kettle("Liliana", "Red", "Stainless Steel", 1.5);
        Stereo myStereo = new Stereo("UX", "Black");


        Console.WriteLine("-- ENCENDIDO --");
        myStereo.Press_power_btn();
        myStereo.change_mode(StereoMode.Radio);
        myStereo.change_mode(StereoMode.Aux);
        myStereo.connect_device_to_aux();
        //myStereo.disconnect_device_to_aux();
        myStereo.change_mode(StereoMode.CD);

        Console.WriteLine("-- APAGADO --");
        myStereo.Press_power_btn();
        myStereo.change_mode(StereoMode.Radio);
    }
}
