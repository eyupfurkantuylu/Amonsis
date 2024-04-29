using AmonsisTestCase.Repositories.ReportRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AmonsisTestCase.ViewComponents.ReportComponents
{
    public class _AllUserListCard : ViewComponent
    {
        private readonly IReportRepository _reportRepository;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var count = await _reportRepository.GetAllUserCount();

            return View(count);
        }
    }
}
