namespace Kontenery.Containers;

public interface IHazardNotifier
{
    protected static void Warning(string number)
    {
        Console.WriteLine("Warning! You are trying action that can end danger up! Container sequence number: " + number);
    }
}