namespace Kontenery.Containers;

public class GasC : Container, IHazardNotifier
{
    private double pressure;
    
    
    public GasC(double cargoWeight, double height, double conteinerWeight,
        double depth, double maxWeight)
    {
        this.conteinerWeight = conteinerWeight;
        this.depth = depth;
        this.height = height;
        this.cargoWeight = cargoWeight;
        this.maxWeight = maxWeight;
        sequenceNumber += "G-" + uniqueNum;
        uniqueNum++;
    }

    public override void EmptyContainer()
    {
        cargoWeight -= 0.95 * cargoWeight;
        IHazardNotifier.Warning(sequenceNumber);
    }

    public void LoadContainer(string gas, double cubicMeters)
    {
        if (cargoWeight + cubicMeters > maxWeight)
        {
            throw new OverfillException("There is not enough space in the container");
        }
        else
        {
            type = gas;
            cargoWeight = cubicMeters;
        }
    }
    
    public override string ToString()
    {
        return "This container contains: " + cargoWeight + " cubic meters of " + (type == null ? "nothing" : type) +
                      " with sequence number: " + sequenceNumber;
    }
}