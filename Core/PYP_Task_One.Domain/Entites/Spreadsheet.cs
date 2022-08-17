

using PYP_Task_One.Domain.Common;

namespace PYP_Task_One.Domain.Entites;

    public class Spreadsheet:BaseEntity
    {
    public string Segment { get; set; }
    public string Country { get; set; }
    public string Product { get; set; }
    public string DiscountBand { get; set; }
    public double UnitsSold { get; set; }
    public double ManufacturingPrice { get; set; }
    public double SellPrice { get; set; }
    public double GrossSales { get; set; }
    public double Discount { get; set; }
    public double Sale { get; set; }
    public double COGS { get; set; }
    public double Profit { get; set; }
    public DateTime Date { get; set; }
}
