using DBModels.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using YVFlashCard.Service.Adapter;
using YVFlashCard.Service.Interfaces;
using YVFlashCard.Service.Users.DTO;

namespace YVFlashCard.Service.Users
{
    public class AccountServiceImpl : IAccountService
    {
        public AccountServiceImpl()
        {

        }

        public async Task<Accounts?> AuthenticateAsync(string username, string password)
        {
            using var dbs = new YVFlashCardContext();
            return await dbs.Accounts.Where(u => u.UserName == username && u.PassWord == password).FirstOrDefaultAsync();
        }

        public async Task<Accounts> GetAccountByUsernameAsync(string username)
        {
            using var dbs = new YVFlashCardContext();
            return await dbs.Accounts.FirstOrDefaultAsync(u => u.UserName == username);
        }
        public async Task<List<UserDTO>> GetAccountsByKeyAsync(string keySreach, int count = 0)
        {
            using var dbs = new YVFlashCardContext();
            var listUsers = await dbs.Accounts.Where(u => u.UserName.Contains(keySreach) || u.UserInfos.FirstName.Contains(keySreach) || u.UserInfos.LastName.Contains(keySreach)).Take(count).ToListAsync();

            return await (new UserDTOAdapterIpml(listUsers)).GetUserDTOsAsync();
        }
        public async Task<List<UserDTO>> GetAccountsAsync(string keySearch = "", int count = 0)
        {
            if (string.IsNullOrEmpty(keySearch))
            {
                if (count == 0)
                {
                    return await GetAllAccountsAsync();
                }
                else
                {
                    return await GetAccountsByTopAsync(count);
                }
            }
            else
            {
                return await GetAccountsByKeyAsync(keySearch, count);
            }
        }
        public async Task<List<UserDTO>> GetAllAccountsAsync()
        {
            using var dbs = new YVFlashCardContext();
            var listUsers = await dbs.Accounts.OrderBy(u => u.UserName).ToListAsync();

            //result.Sort((x, y) => DateTime.Compare(y.DateCreate, x.DateCreate));

            return await (new UserDTOAdapterIpml(listUsers)).GetUserDTOsAsync();
        }

        public async Task<List<UserDTO>> GetAccountsByTopAsync(int count)
        {
            using var dbs = new YVFlashCardContext();
            var listUsers = await dbs.Accounts.OrderBy(u => u.UserName).Take(count).ToListAsync();

            return await (new UserDTOAdapterIpml(listUsers)).GetUserDTOsAsync(); ;
        }

        public async Task UpdateInfo(UpdateInfoRequest request)
        {
          
            using var dbs = new YVFlashCardContext();
            UserInfos? user = await dbs.UserInfos.FirstOrDefaultAsync(u => u.UserName == request.Username);
            if (user == null)
            {
                throw new Exception("Không tìm thấy người dùng này!");
            }
            user.FirstName = WebUtility.HtmlDecode(request.FirstName); 
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;
            user.Email = request.Email;
            user.Address = request.Address;
            user.Age = request.Age;
            user.Sex = request.Sex;
            user.AvatarData = request.Avatar;
            await dbs.SaveChangesAsync();
        }

        public async Task UpdatePassword(UpdateInfoRequest request)
        {
            using var dbs = new YVFlashCardContext();
            Accounts account = await dbs.Accounts.FirstOrDefaultAsync(u => u.UserName == request.Username);
            if (account == null)
            {
                throw new Exception("Không tìm thấy người dùng này!");
            }
            if (!string.IsNullOrEmpty(request.NewPassword))
            {
                account.PassWord = request.NewPassword;
                await dbs.SaveChangesAsync();
            }  
        }

        public async Task<bool> CheckAccountExistsAsync(string username)
        {
            using var dbs = new YVFlashCardContext();
            return await dbs.Accounts.AnyAsync(u => u.UserName == username);
        }

        public async Task<bool> CreateNewUser(UpdateInfoRequest request)
        {
			
			using (var context = new YVFlashCardContext())
			{
				var sql = "INSERT INTO Accounts (UserName, PassWord, DateCreate, Role) VALUES (@Col1, @Col2, @Col3, @Col4);";
        
				int row = await context.Database.ExecuteSqlRawAsync(sql, new SqlParameter("@Col1", request.Username), new SqlParameter("@Col2", request.NewPassword), new SqlParameter("@Col3", DateTime.Now), new SqlParameter("@Col4", request.Role));
				Console.WriteLine(row.ToString());
				if (row > 0)
				{
					await UpdateInfo(request);
					return true;
				}
                throw new Exception("Không thể thêm User mới!!!");

			}
			throw new Exception("lỗi khi thêm User mới!!!");
        }
    }
}
