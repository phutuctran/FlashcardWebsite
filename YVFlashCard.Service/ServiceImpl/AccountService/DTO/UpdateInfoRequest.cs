using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YVFlashCard.Service.Users.DTO
{
	public class UpdateInfoRequest
	{
		public string Username { get; set; }
        public DateTime? DateCreate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public string Sex { get; set; }
        public byte[] Avatar { get; set; }
        public string Role { get; set; }
        public string NewPassword { get; set; }

		public UpdateInfoRequest() { }

	}
}
