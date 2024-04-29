using AmonsisTestCase.Models.Dtos.UserDtos;

namespace AmonsisTestCase.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        // Create İşlemi 
        Task<int> CreateUserAsync(CreateUserDto userDto);
        // Tüm Kullanıcıları Getirir
        Task<List<ReadUserDto>> ReadUserListAsync();
        // ID'si verilen kullanıcıyı getirir
        Task<ReadUserDto> GetUserById(int id);
        // UpdateUserDto ile verilen kullanıcıyı günceller
        Task<UpdateUserDto> UpdateUserAsync(UpdateUserDto userDto);
        // ID'si verilen kullanıcıyı siler
        Task<int> DeleteUserAsync(int id);
    }
}
 