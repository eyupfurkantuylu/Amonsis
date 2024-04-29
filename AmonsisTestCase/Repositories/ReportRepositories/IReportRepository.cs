using AmonsisTestCase.Models.Dtos.ReportDtos;
using AmonsisTestCase.Models.Dtos.UserDtos;

namespace AmonsisTestCase.Repositories.ReportRepositories
{
    public interface IReportRepository
    {
        Task<List<AllUserCountDto>> GetAllUserCount();

        Task<List<BirthYearPersonCountDto>> GetBirthYearPersonCount();

        Task<List<ReadUserDto>> DateBasedRecordFilter();
        Task<List<ReadUserDto>> GetAllUserList();
    }
}
