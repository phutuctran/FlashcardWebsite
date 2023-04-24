using DBModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace YVFlashCard.Service.Users.DTO
{
	/// <summary>
	/// Mọi thứ trong đây -> đổ ra ngoài vview
	/// </summary>
	public class UserDTO
	{
		public string Username { get; set; }
		public DateTime DateCreate { get; set; }

		public string FirstName {get; set;}
		public string LastName {get; set;}
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public int? Age { get; set; }
		public string Sex { get; set; }
		public byte[] Avatar { get; set; }
		public string Role { get; set; }

		public UserDTO() { }

		public UserDTO(UserDTO user)
		{
			SetUserDTO(user);
		}

		public void SetUserDTO(UserDTO user)
		{
            Username = user.Username;
            DateCreate = user.DateCreate;
            FirstName = user.FirstName;
            LastName = user.LastName;
            PhoneNumber = user.PhoneNumber;
            Address = user.Address;
            Email = user.Email;
            Age = user.Age;
            Sex = user.Sex;
            Avatar = user.Avatar;
            Role = user.Role;
        }

		public UserDTO(Accounts acc, UserInfos userInfo)
		{
			this.Username = acc.UserName;
			this.DateCreate = (DateTime)(acc.DateCreate == null ? DateTime.Now : acc.DateCreate);
			this.FirstName = userInfo.FirstName;
			this.LastName = userInfo.LastName;
			this.PhoneNumber = userInfo.PhoneNumber;
			this.Address = userInfo.Address;
			this.Email = userInfo.Email;
			this.Age = userInfo.Age;
			this.Sex = userInfo.Sex;
			this.Avatar = userInfo.AvatarData;
			if (acc.Role == "A")
				this.Role = "Quản trị viên";
			else
				this.Role = "Người dùng";
		}
	}
}
