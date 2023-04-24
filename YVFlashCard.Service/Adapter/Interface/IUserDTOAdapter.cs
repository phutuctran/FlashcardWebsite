using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YVFlashCard.Service.Users.DTO;

namespace YVFlashCard.Service.Adapter.Interface
{
    public interface IUserDTOAdapter
    {
        Task<List<UserDTO>> GetUserDTOsAsync();
    }
}
