using DBModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YVFlashCard.Service.Users.DTO;

namespace YVFlashCard.Service.Interfaces
{
    public interface IAccountService
    {
        Task<Accounts?> AuthenticateAsync(string username, string password);
        Task<List<UserDTO>> GetAllAccountsAsync();
        Task<List<UserDTO>> GetAccountsByTopAsync(int count);
        Task<List<UserDTO>> GetAccountsByKeyAsync(string keySreach, int count);
        Task<List<UserDTO>> GetAccountsAsync(string keySearch, int count);
        Task<Accounts> GetAccountByUsernameAsync(string username);
        Task<bool> CheckAccountExistsAsync(string username);
        Task UpdatePassword(UpdateInfoRequest request);
        Task UpdateInfo(UpdateInfoRequest request);
        Task<bool> CreateNewUser(UpdateInfoRequest request);
    }


}
