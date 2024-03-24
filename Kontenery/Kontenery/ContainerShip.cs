using Kontenery.Containers;

namespace Kontenery;

public class ContainerShip
{
    private List<Container> containersList;
    private double weight;
    private double maxSpeed;
    private int maxContNumber;
    private double maxWeight;

    public ContainerShip(double maxSpeed, int maxContNumber, double maxWeight)
    {
        this.maxSpeed = maxSpeed;
        this.maxWeight = maxWeight;
        weight = 0;
        this.maxContNumber = maxContNumber;
        containersList = new List<Container>();
    }

    public void AddContainer(Container c)
    {
        if ((weight + c.cargoWeight + c.conteinerWeight)*0.001 > maxWeight || containersList.Count > maxContNumber)
        {
            Console.WriteLine("This is too heavy for this ship");
        }
        else
        {
            containersList.Add(c);
            weight += c.cargoWeight + c.conteinerWeight;
        }
    }
    
    public void AddContainers(List<Container> l)
    {
        foreach (Container a in l)
        {
            if ((weight + a.cargoWeight + a.conteinerWeight) * 0.001 > maxWeight || containersList.Count > maxContNumber)
            {
                Console.WriteLine("This is too heavy for this ship");
                break;
            }
            else
            {
                containersList.Add(a);
                weight += a.cargoWeight + a.conteinerWeight;
            }
        }
    }

    public void DeleteContainer(Container c)
    {
        foreach (Container a in containersList)
        {
            if (a == c)
            {
                containersList.Remove(a);
                break;
            }
        }
    }

    public void ChangeContainer(string number, Container c)
    {
        foreach (Container a in containersList)
        {
            if (a.num == number && (weight + c.cargoWeight + c.conteinerWeight - a.conteinerWeight - a.cargoWeight) *0.001 < maxWeight)
            {
                containersList.Remove(a);
                containersList.Add(c);
                break;
            }
        }
    }

    public void MoveContainer(Container c, ContainerShip s)
    {
        foreach (Container a in containersList)
        {
            if (a == c && (s.weight + c.cargoWeight + c.conteinerWeight)*0.001 < s.maxWeight && s.containersList.Count + 1 < s.maxContNumber)
            {
                containersList.Remove(a);
                s.containersList.Add(a);
                break;
            }
        }
    }

    private string ShowList()
    {
        string aa = "";
        foreach (var a in containersList)
        {
            aa += a + ", ";
        }

        return aa;
    }

    public override string ToString()
    {
        return "This container ship has max speed of " + this.maxSpeed + " and max weight of " + maxWeight +
               " and consist of " + containersList.Count + " containers : " + ShowList();
    }
}