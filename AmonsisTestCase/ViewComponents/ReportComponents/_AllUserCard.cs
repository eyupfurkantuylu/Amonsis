using AmonsisTestCase.Repositories.ReportRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AmonsisTestCase.ViewComponents.ReportComponents
{
    public class _AllUserCard : ViewComponent
    {
        private readonly IReportRepository _reportRepository;

        public _AllUserCard(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var count = await _reportRepository.GetAllUserCount();

            return View(count);
        }
    }
}
