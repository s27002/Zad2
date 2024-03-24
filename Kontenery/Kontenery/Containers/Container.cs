namespace Kontenery.Containers;

public abstract class Container
{
  public string? type { get; set; }
  public double cargoWeight { get; set; }
  public double height{ get; set; }
  public double conteinerWeight{ get; set; }
  public double depth{ get; set; }
  protected static int uniqueNum = 1;
  protected string sequenceNumber = "KON-";

  public string num
  {
    get
    {
      return sequenceNumber;
    }
  }
  public double maxWeight { get; set; }

  public abstract void EmptyContainer();
}