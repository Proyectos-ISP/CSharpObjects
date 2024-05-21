
using CSharpObjects.constants;
using CSharpObjects.classes;

internal class Program
{
    private static void Main(string[] args)
    {
        Kettle myKettle = new Kettle("Liliana", "Red", "Stainless Steel", 1.5);
        myKettle.Press_power_btn();
        myKettle.Change_mode(Mode.Max);
        myKettle.heat_water();

    }
}