using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YVFlashCardWApp.Models
{
	public class UserInfoModel
	{

		//public string Password { get; set; }

		public string Username { get; set; }
		public DateTime DateCreate { get; set; }
		//[StringLength(100)]
		public string FirstName { get; set; }
		//[StringLength(100)]
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		//[StringLength(300)]
		public string Address { get; set; }
		//[EmailAddress]
		public string Email { get; set; }
		//[Range(5, 90)]
		public int? Age { get; set; }
		public string Sex { get; set; }
		public byte[] Avatar { get; set; }
		public string Role { get; set; }
	}
}
