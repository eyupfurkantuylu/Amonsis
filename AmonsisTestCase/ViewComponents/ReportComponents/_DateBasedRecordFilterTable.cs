using AmonsisTestCase.Repositories.ReportRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AmonsisTestCase.ViewComponents.ReportComponents
{
    public class _DateBasedRecordFilterTable : ViewComponent
    {
        private readonly IReportRepository _reportRepository;

        public _DateBasedRecordFilterTable(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _reportRepository.DateBasedRecordFilter();

            return View(result);
        }
    }
}
