using DBModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YVFlashCard.Service.ServiceImpl.ThemeService.DTO
{
    public class ThemeDTO
    {
        public int themeId { get; set; }
        public string themeName { get; set; }
        public string mean { get; set; }
        public byte[] IllustrationImg { get; set; }
        public string author { get; set; }
        public string role { get; set; }

        public ThemeDTO() { }
        public ThemeDTO(Themes theme)
        {
            themeId = theme.ThemeId;
            themeName = theme.ThemeName;
            mean = theme.Mean;
            IllustrationImg = theme.IllustrationImg;
            author = theme.Author;
            role = theme.Role;
        }
        public ThemeDTO(ThemeDTO theme)
        {
            themeId = theme.themeId;
			themeName = theme.themeName;
			mean = theme.mean;
			IllustrationImg = theme.IllustrationImg;
			author = theme.author;
            role = theme.role;
		}
    }
}
