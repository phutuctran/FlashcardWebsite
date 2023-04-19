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
        Task<Accounts> GetAccountByUsernameAsync(string username);
        Task UpdatePassword(UpdateInfoRequest request);
        Task UpdateInfo(UpdateInfoRequest request);
    }
}
