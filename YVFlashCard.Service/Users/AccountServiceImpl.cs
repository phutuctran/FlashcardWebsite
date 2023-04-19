using DBModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<List<UserDTO>> GetAllAccountsAsync()
        {
            using var dbs = new YVFlashCardContext();
            var listUsers = await dbs.Accounts.ToListAsync();
            List<UserDTO> result = new List<UserDTO>();
            
            foreach (var user in listUsers)
            {
                var info = await dbs.UserInfos.FirstAsync(u => u.UserName == user.UserName);
                result.Add(new UserDTO(user, info));
            }

            return result;
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
    }
}
