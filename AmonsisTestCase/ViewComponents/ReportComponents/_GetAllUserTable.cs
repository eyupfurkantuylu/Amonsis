using AmonsisTestCase.Repositories.ReportRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AmonsisTestCase.ViewComponents.ReportComponents
{
    public class _GetAllUserTable : ViewComponent
    {
        private readonly IReportRepository _reportRepository;

        public _GetAllUserTable(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _reportRepository.GetAllUserList();

            return View(result);
        }
    }
}
