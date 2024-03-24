namespace Kontenery.Containers;

public class CoolingC : Container, IHazardNotifier
{
    private double temperatue;
    
    public CoolingC(double cargoWeight, double height, double conteinerWeight,
        double depth, double maxWeight, double temperatue)
    {
        this.conteinerWeight = conteinerWeight;
        this.depth = depth;
        this.height = height;
        this.cargoWeight = cargoWeight;
        this.maxWeight = maxWeight;
        this.temperatue = temperatue;
        sequenceNumber += "C-" + uniqueNum;
        uniqueNum++;
    }

    public override void EmptyContainer()
    {
        cargoWeight = 0;
        type = null;
    }

    public void LoadContainer(string product, double requiredTemperature, double weight)
    {
        if (cargoWeight + weight > maxWeight)
        {
            throw new OverfillException("There is not enough space in the container");
        }
        else if (requiredTemperature < temperatue)
        {
            IHazardNotifier.Warning(sequenceNumber);
        }
        else
        {
            type = product;
            cargoWeight += weight;
        }
    }
    
    public override string ToString()
    {
        return "This container contains: " + cargoWeight + " kg of " + (type == null ? "nothing" : type) +
               " with sequence number: " + sequenceNumber;
    }
}