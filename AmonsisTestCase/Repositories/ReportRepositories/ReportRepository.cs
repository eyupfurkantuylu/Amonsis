
using AmonsisTestCase.Models.Dapper;
using AmonsisTestCase.Models.Dtos.ReportDtos;
using AmonsisTestCase.Models.Dtos.UserDtos;
using Dapper;

namespace AmonsisTestCase.Repositories.ReportRepositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly Context _context;

        public ReportRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ReadUserDto>> DateBasedRecordFilter()
        {
            string selectQuery = "SELECT * FROM tblData Order By tblData.CreaDate DESC";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ReadUserDto>(selectQuery);
                return result.ToList();
            }
        }

        public async Task<List<AllUserCountDto>> GetAllUserCount()
        {

            using (var connection = _context.CreateConnection())
            {
                string selectQuery = "SELECT COUNT(*) AS TotalRecords FROM tblData";

                var result = await connection.QueryAsync<AllUserCountDto>(selectQuery);

                return result.ToList();
            }
        }

        public async Task<List<ReadUserDto>> GetAllUserList()
        {
            using (var connection = _context.CreateConnection())
            {
                string selectQuery = "SELECT * FROM tblData Order By tblData.CreaDate DESC";

                var users = await connection.QueryAsync<ReadUserDto>(selectQuery);

                if (users != null)
                {
                    return users.ToList();
                }
                return null;

            }
        }

        public async Task<List<BirthYearPersonCountDto>> GetBirthYearPersonCount()
        {
            using (var connection = _context.CreateConnection())
            {
                string selectQuery = @"SELECT
                                        YEAR(BirthDate) AS BirthYear, 
                                        COUNT(*) AS PersonCount 
                                    FROM
                                        tblData -- Verilerin yer aldığı tablo
                                    GROUP BY
                                        YEAR(BirthDate)
                                    ORDER BY
                                        BirthYear; 
                                    ";

                var result = await connection.QueryAsync<BirthYearPersonCountDto>(selectQuery);

                return result.ToList();
            }
        }

        


    }
}
