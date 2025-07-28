using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace EstateAgency;

public class EstateAgency
{
    public int Capacity { get; set; }
    public List<RealEstate> RealEstates { get; set; }
    public int Count => RealEstates.Count;

    public EstateAgency(int capacity)
    {
        Capacity = capacity;
        RealEstates = new();
    }

    public void AddRealEstate(RealEstate realEstate)
    {
        if (Count < Capacity && !RealEstates.Any(x => x.Address == realEstate.Address))
            RealEstates.Add(realEstate);
    }

    public bool RemoveRealEstate(string address)
    {
        foreach (var estate in RealEstates)
        {
            if (estate.Address == address)
            {
                RealEstates.Remove(estate);
                return true;
            }
        }
        return false;
    }

    public List<RealEstate> GetRealEstates(string postalCode)
    {
        List<RealEstate> valid = new();
        foreach (var estate in RealEstates)
        {
            if (estate.PostalCode == postalCode)
            {
                valid.Add(estate);
            }
        }
        return valid;
    }

    public RealEstate GetCheapest() => RealEstates.OrderBy(x => x.Price).FirstOrDefault();

    public double GetLargest() => RealEstates.OrderByDescending(x => x.Size).FirstOrDefault().Size;

    public string EstateReport()
    {
        StringBuilder result = new();
        result.AppendLine("Real estates available:");
        foreach (var estate in RealEstates)
            result.AppendLine(estate.ToString());

        return result.ToString().Trim();
    }
}