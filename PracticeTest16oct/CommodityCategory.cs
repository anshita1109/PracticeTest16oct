using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum CommodityCategory
{
    Furniture,
    Grocery,
    Service
}
class Commodity
{
    public Commodity(CommodityCategory category, string commodityName, int commodityQuantity, double commodityPrice)
    {
        Category = category;
        CommodityName = commodityName;
        CommodityQuantity = commodityQuantity;
        CommodityPrice = commodityPrice;
    }
    public CommodityCategory Category { get; set; }

    public string CommodityName { get; set; }
    public int CommodityQuantity { get; set; }
    public double CommodityPrice { get; set; }
}
class PrepareBill
{
    private readonly IDictionary<CommodityCategory, double> _taxRates;

    public PrepareBill()
    {
        _taxRates = new Dictionary<CommodityCategory, double>();
    }
    public void SetTaxRates(CommodityCategory category, double taxRate)
    {
        if (!_taxRates.ContainsKey(category))
        {
            _taxRates[category] = taxRate;
        }
    }
    public double CalculateBillAmount(IList<Commodity> items)
    {
        double totalAmount = 0;
        foreach (var item in items)
        {
            if (!_taxRates.ContainsKey(item.Category))
            {
                throw new ArgumentException($"Tax rate for {item.Category} is not defined.");
            }
            double taxRate = _taxRates[item.Category];
            double itemTotal = item.CommodityQuantity * item.CommodityPrice;
            double itemTotalWithTax = taxRate + itemTotal;
            totalAmount += itemTotalWithTax;
        }
        return totalAmount;
    }
}
class Program3
{
    static void Main(string[] args)
    {
        var Commodities = new List<Commodity>
        {
            new Commodity(CommodityCategory.Furniture, "Bed", 2, 5000),
            new Commodity(CommodityCategory.Grocery, "Flour", 5, 80),
            new Commodity(CommodityCategory.Service, "Insurance", 8, 8500),
        };
        var prepareBill = new PrepareBill();
        prepareBill.SetTaxRates(CommodityCategory.Furniture, 18);
        prepareBill.SetTaxRates(CommodityCategory.Grocery, 18);
        prepareBill.SetTaxRates(CommodityCategory.Service, 18);

        var billAmount = prepareBill.CalculateBillAmount(Commodities);
        Console.WriteLine($"{billAmount}");
    }
}