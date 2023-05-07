using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security;
using YVFlashCard.Service.Users.DTO;

namespace YVFlashCard.Areas.Admin.Models
{
    public class UserInfoModel 
    {

        public string NewPassword { get; set; }

		[System.ComponentModel.DataAnnotations.Required]
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

		public UserInfoModel() : base()
        {
        }

        public UserInfoModel(UserDTO user) 
        {
			this.Username = user.Username;
			this.DateCreate = user.DateCreate;
			this.FirstName = user.FirstName;
			this.LastName = user.LastName;
			this.PhoneNumber = user.PhoneNumber;
			this.Address = user.Address;
			this.Email = user.Email;
			this.Age = user.Age;
			this.Sex = user.Sex;
			this.Avatar = user.Avatar;
            this.Role = user.Role;
		}
		
		public UpdateInfoRequest GetUpdateInfoRequest()
		{
			var request = new UpdateInfoRequest();
			request.Username = this.Username;
			request.DateCreate = this.DateCreate;
			request.FirstName = this.FirstName;
			request.LastName = this.LastName;
			request.PhoneNumber = this.PhoneNumber;
			request.Address = this.Address;
			request.Email = this.Email;
			request.Age = this.Age;
			request.Sex = this.Sex;
			request.Avatar = this.Avatar;
			request.Role = this.Role;
			request.NewPassword = this.NewPassword;
			return request;
				
		}

        public override string ToString()
        {
            return $"Username: {Username}\nDateCreate: {DateCreate}\nName: {FirstName + LastName}\nPhone: {PhoneNumber}\nAddress: {Address}\nEmail: {Email}\nAge: {Age.ToString()}\nSex:{Sex}\nRole: {Role}\nNewPassword: {NewPassword}";
        }
    }
}
