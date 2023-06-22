using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using YVFlashCard.Service.Users.DTO;
using YVFlashCardWApp.Adapter.Interfaces;
using YVFlashCardWApp.Models;

namespace YVFlashCardWApp.Adapter
{
	public class UserInfoModelServiceImpl : IUserInfoModelService
	{
		private UserDTO _userDTO;
		public UserInfoModelServiceImpl(UserDTO userDTO)
		{
			_userDTO = userDTO;
		}
		public UserInfoModel GetUserInfoModel()
		{
			var info = new UserInfoModel();
			info.Username = _userDTO.Username;
			info.DateCreate = _userDTO.DateCreate;
			info.FirstName = _userDTO.FirstName;
			info.LastName = _userDTO.LastName;	
			info.PhoneNumber = _userDTO.PhoneNumber;
			info.Address = _userDTO.Address;
			info.Email = _userDTO.Email;
			info.Age = _userDTO.Age;
			info.Sex = _userDTO.Sex;
			info.Avatar = _userDTO.Avatar;
			info.Role = _userDTO.Role;
			return info;
		}
	
	}
}
