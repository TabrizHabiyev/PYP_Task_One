using Microsoft.EntityFrameworkCore;
using PYP_Task_One.Aplication.DTOs;
using Type = PYP_Task_One.Aplication.Enums.ReportType;
using PYP_Task_One.Domain.Entites;

namespace PYP_Task_One.Aplication.Extensions;

public static class ReportExtension
{
    public static IQueryable<ReportDto> GetReportByTypeFromDb(this IQueryable<Spreadsheet> query, Type type, DateTime StartDate, DateTime EndDate)
    {

        query = query.Where(d => d.Date >= StartDate && d.Date <= EndDate);

        var groupBy = type switch
        {
            
            Type.SalesBySegment => query.GroupBy(x => x.Segment),
            Type.SalesByCountry => query.GroupBy(x => x.Country),
            Type.SalesByProduct => query.GroupBy(x => x.Product),
            Type.DiscountByProduct => query.GroupBy(x => x.Product),
            _ => throw new NotImplementedException()
        };

            return groupBy.Select(g => new ReportDto
            {
                Type = g.Key,
                TotalUnitsSold = g.Sum(x => x.UnitsSold),
                TotalGrossSales = g.Sum(x => x.GrossSales),
                TotalDiscount = g.Sum(x => x.Discount),
                Profit = g.Sum(x => x.Profit),
                Percent = type == Type.DiscountByProduct ? g.Sum(x => x.Discount) / g.Sum(x => x.GrossSales) * 100 : 0,
            }).AsNoTracking();
        
        
    }
}
