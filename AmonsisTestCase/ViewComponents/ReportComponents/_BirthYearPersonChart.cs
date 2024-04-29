using AmonsisTestCase.Repositories.ReportRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AmonsisTestCase.ViewComponents.ReportComponents
{
    public class _BirthYearPersonChart : ViewComponent
    {
        private readonly IReportRepository _reportRepository;

        public _BirthYearPersonChart(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var count = await _reportRepository.GetBirthYearPersonCount();

            return View(count);
        }
    }
}
