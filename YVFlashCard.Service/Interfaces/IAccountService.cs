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
		Accounts? Authenticate(string username, string password);
		Task<List<UserDTO>> GetAllAccountsAsync();
        Task<List<UserDTO>> GetAccountsByTopAsync(int count);
        Task<List<UserDTO>> GetAccountsByKeyAsync(string keySreach, int count);
        Task<List<UserDTO>> GetAccountsAsync(string keySearch, int count);
        Task<Accounts> GetAccountByUsernameAsync(string username);
        Task<UserDTO> GetUserInfoByUsernameAsync(string username);
        Task<bool> CheckAccountExistsAsync(string username);
        Task UpdatePasswordAsync(UpdateInfoRequest request);
        Task UpdateInfoAsync(UpdateInfoRequest request);
        Task<bool> CreateNewUserAsync(UpdateInfoRequest request);

        Task<bool> DeleteAccountandAllUserInfoAsync(UpdateInfoRequest request);
    }


}
