
using Kontenery;
using Kontenery.Containers;

public class Program
{
    public static void Main(string[] args)
    {
        LiqiudC l1 = new LiqiudC(0, 22, 10,  15, 30);
        GasC g1 = new GasC(0, 22, 10,  15, 30);
        CoolingC c1 = new CoolingC(9, 22, 10,  15, 30, -8);
        l1.LoadContainer(false, "Milk", 16);
        c1.LoadContainer("Bananas", 13.3,3);
        Console.WriteLine(l1);
        Console.WriteLine(c1);
        Console.WriteLine(g1);
        l1.EmptyContainer();
        Console.WriteLine(l1);
        g1.LoadContainer("Fresh air", 29.5);
        g1.EmptyContainer();
        Console.WriteLine(g1);

        ContainerShip cs1 = new ContainerShip(33, 40, 10);
        ContainerShip cs2 = new ContainerShip(40, 15, 3);
        
        cs1.AddContainer(g1);
        cs2.AddContainer(c1);
        cs2.AddContainer(l1);
        
        Console.WriteLine(cs1);
        Console.WriteLine(cs2);
        cs1.DeleteContainer(g1);
        cs2.ChangeContainer("KON-L-1", g1);
        Console.WriteLine(cs1);
        Console.WriteLine(cs2);
        cs2.MoveContainer(g1, cs1);
        Console.WriteLine(cs1);
        Console.WriteLine(cs2);
        cs2.DeleteContainer(c1);
        List<Container> l = new List<Container>() { l1, c1 };
        cs1.AddContainers(l);
        Console.WriteLine(cs1);
        Console.WriteLine(cs2);



    }
}