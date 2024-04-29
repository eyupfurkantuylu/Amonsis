using AmonsisTestCase.Models.Dapper;
using AmonsisTestCase.Models.Dtos.UserDtos;
using Dapper;
using Microsoft.AspNetCore.Http;

namespace AmonsisTestCase.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        // Data ile bağlantı sağlayabilmek için değişken tanımladık.
        private readonly Context _context;

        // UserRepository'den her nesne oluşturulduğunda data ile bağlantıda kurulmuş olacak. Bu sayede alt metodlar dataya erişebilecek.
        public UserRepository(Context context)
        {
            _context = context;
        }


        // CreateUserDto modelinde gönderilen kullanıcıyı oluşturma metodu
        public async Task<int> CreateUserAsync(CreateUserDto userDto)
        {
            // Dapper aracılığı ile çalıştıracağız.
            using (var connection = _context.CreateConnection())
            {
                string query = @"
                INSERT INTO tblData (Name, Surname, Location, BirthDate, CreaDate)
                VALUES (
                    @Name, 
                    @Surname, 
                    @Location, 
                    @BirthDate, 
                    @CreaDate
                )";

                // Kayıt tarihi sunucunun tarihini alır ve CreaDate'e ekler.
                DateTime creaDate = DateTime.Now;

                // SQL sorgusunun beklediği parametreleri dinamik olarak belirledik.
                var parameters = new
                {
                    Name = userDto.Name,
                    Surname = userDto.Surname,
                    Location = userDto.Location,
                    BirthDate = userDto.BirthDate,
                    CreaDate = creaDate
                };

                // Sorguyu burada çalıştırıyoruz. 
                var result = await connection.ExecuteAsync(query, parameters);
                return result;
            }
        }

        // Id'sini verdiğimiz kullanıcıyı silme metodu
        public async Task<int> DeleteUserAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                // Kullanıcı var mı kontrol edeceğiz
                string selectQuery = "SELECT * FROM tblData WHERE ID = @ID";

                // tek parametre beklediği için metod içerisinde gönderdim new {Id=id} olarak. Okunabilirliği arttırmak için Create metodundaki gibi
                // parameters adında değişken tanımlanıp yapılabilir.
                // Bu kod bize silinebilir kullanıcı olup olmadığını döndürecek.
                int userToDelete = await connection.ExecuteAsync(selectQuery, new { ID = id });

                if (userToDelete != null)
                {
                    // Dinamik sql query'sini oluşturur
                    string deleteQuery = "DELETE FROM tblData WHERE ID = @ID";
                    // Sql query'sini çalıştırır
                    await connection.ExecuteAsync(deleteQuery, new { ID = id });

                    // Silinen Id'yi döndürür
                    return userToDelete;
                }

                // Kullanıcı bulunamadıysa null döner.
                return 0;
            }
        }

        // Id'si belirtilen kullanıcıyı döndürme metodu
        public async Task<ReadUserDto> GetUserById(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                string selectQuery = "SELECT * FROM tblData WHERE ID = @ID";

                ReadUserDto userToRead = await connection.QueryFirstOrDefaultAsync<ReadUserDto>(selectQuery, new { ID = id });

                if (userToRead != null)
                {
                    return userToRead;
                }
                return null;
            }
        }

        // Tüm kullanıcıların listesini dönme
        public async Task<List<ReadUserDto>> ReadUserListAsync()
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

        // UpdateUserDto modelinde gönderilen kullanıcıyı datada güncelleme metodu
        public async Task<UpdateUserDto> UpdateUserAsync(UpdateUserDto userDto)
        {
            using (var connection = _context.CreateConnection())
            {

                string query = @"
                                UPDATE tblData
                                SET Name = @Name,
                                    Surname = @Surname,
                                    Location = @Location,
                                    BirthDate = @BirthDate, 
                                    CreaDate = @CreaDate
                                WHERE ID = @ID";

               
           

                // Query'i çalıştıracak ve eğer rowsAffected 0'sa böyle bir kullanıcı bulunamadığı anlamına gelecek 
                int rowsAffected = await connection.ExecuteAsync(query, userDto);

                if (rowsAffected == 0)
                {
                    return null;
                }
                return userDto;
            }

        }
    }
}
