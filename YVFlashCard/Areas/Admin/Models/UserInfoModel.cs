using Microsoft.Build.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Security;
using YVFlashCard.Service.Users.DTO;

namespace YVFlashCard.Areas.Admin.Models
{
    public class UserInfoModel : UserDTO
    {
        public string NewPassword { get; set; }

        public UserInfoModel() : base()
        {
        }

        public UserInfoModel(UserDTO user) : base(user)
        {

        }

        public void SetUserIfoModel(UserInfoModel user)
        {
            NewPassword = user.NewPassword;
            
            this.SetUserDTO(user);  
        }

        public void SetUserIfoModel(UserDTO user)
        {
            this.SetUserDTO(user);
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
