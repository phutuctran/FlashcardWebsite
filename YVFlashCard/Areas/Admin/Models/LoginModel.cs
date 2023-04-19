using Microsoft.Build.Framework;
using System.Diagnostics.CodeAnalysis;

namespace YVFlashCard.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required]
        public string userName { get; set; }
        public string password { get; set; }
        public string rememberMe { get; set; }
        public DateTime creatDate { get; set; }
    }
}
