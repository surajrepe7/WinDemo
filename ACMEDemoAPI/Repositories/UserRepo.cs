using Microsoft.EntityFrameworkCore;
using WinDemoAPI.Data;
using WinDemoAPI.Interfaces;
using WinDemoAPI.Models.Domain;

namespace WinDemoAPI.Repositories
{
	public class UserRepo : IUserRepo
	{
		private readonly AppDbContext dbContext;

		public UserRepo(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<User> AddUserAsync(User user)
		{
			try
			{
				await dbContext.users.AddAsync(user);
				await dbContext.SaveChangesAsync();
				return user;

			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<User> DeleteUserAsync(int Id)
		{
			try
			{
             var user = await dbContext.users.FindAsync(Id);
			if (user == null)
			{
				return user;
			}
			dbContext.users.Remove(user);
			await dbContext.SaveChangesAsync();
			return user;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<List<User>> GetAllUserAsync()
		{
			try
			{
             return await dbContext.users.ToListAsync();

			}
			catch (Exception)
			{

				throw;
			}

		}

		public async Task<User> GetUserByIdAsync(int id)
		{
			try
			{

			return await dbContext.users.FirstOrDefaultAsync(x => x.UserId == id);

			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<User> UpdateUserAsync(int Id, User user)
		{
			var userDomain = await dbContext.users.FirstOrDefaultAsync(x => x.UserId == Id);
			
		   dbContext.users.Update(userDomain);
		   await dbContext.SaveChangesAsync();
			return user;
		}
	}
}
