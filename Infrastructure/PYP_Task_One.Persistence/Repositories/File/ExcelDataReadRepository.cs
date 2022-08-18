using PYP_Task_One.Aplication.Repositories.File;
using PYP_Task_One.Domain.Entites;
using PYP_Task_One.Persistence.Contexts;

namespace PYP_Task_One.Persistence.Repositories.File;

public class ExcelDataReadRepository :ReadRepository<Spreadsheet>, IExcelDataReadRepository
{
    public ExcelDataReadRepository(PYP_Task_OneDBContext context) : base(context)
    {

    }
}
