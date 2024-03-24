namespace Kontenery.Containers;


public class LiqiudC : Container, IHazardNotifier
{
    public bool isDangerous { get; set; }
    

    public LiqiudC(double cargoWeight, double height, double conteinerWeight,
    double depth, double maxWeight)
    {
        this.conteinerWeight = conteinerWeight;
        this.depth = depth;
        this.height = height;
        this.cargoWeight = cargoWeight;
        this.maxWeight = maxWeight;
        sequenceNumber += "L-" + uniqueNum;
        uniqueNum++;
    }

    public void LoadContainer(bool isDangerous, string type, double litres)
    {
        if (cargoWeight + litres > maxWeight)
        {
            throw new OverfillException("There is not enough space in the container");
        }
        else 
        {
            if ((isDangerous && cargoWeight + litres > 0.5 * maxWeight) || (!isDangerous && cargoWeight + litres > 0.9 * maxWeight))
            {
                IHazardNotifier.Warning(sequenceNumber);
            }
            this.isDangerous = isDangerous;
            this.type = type;
            cargoWeight += litres;
        }
    }

    public override void EmptyContainer()
    {
        cargoWeight = 0;
        isDangerous = false;
        type = null;
    }

    public override string ToString()
    {
        return "This container contains: " + cargoWeight + " liters of " + (type == null ? "nothing" : type) +
               " with sequence number: " + sequenceNumber;
    }
}