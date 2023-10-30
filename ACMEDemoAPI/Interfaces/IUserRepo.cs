using WinDemoAPI.Models.Domain;

namespace WinDemoAPI.Interfaces
{
	public interface IUserRepo
	{
		Task<List<User>> GetAllUserAsync();
		Task<User> GetUserByIdAsync(int id);
		Task<User> AddUserAsync(User user);
		Task<User> UpdateUserAsync(int Id, User user);
		Task <User> DeleteUserAsync(int Id);


	}
}
