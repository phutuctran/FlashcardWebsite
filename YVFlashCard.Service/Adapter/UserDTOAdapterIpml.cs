using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YVFlashCard.Service.Adapter.Interface;
using YVFlashCard.Service.Users.DTO;
using DBModels.Models;
using Microsoft.EntityFrameworkCore;

namespace YVFlashCard.Service.Adapter
{
    internal class UserDTOAdapterIpml : IUserDTOAdapter
    {
        private List<Accounts> accounts;

        public UserDTOAdapterIpml(List<Accounts> accounts)
        {
            this.accounts = accounts;
        }

        public async Task<List<UserDTO>>  GetUserDTOsAsync()
        {
            List<UserDTO> users = new List<UserDTO>();  
            using var dbs = new YVFlashCardContext();
            foreach (var user in accounts)
            {
                var info = await dbs.UserInfos.FirstAsync(u => u.UserName == user.UserName);
                users.Add(new UserDTO(user, info));
            }
            return users;
        }
    }
}
