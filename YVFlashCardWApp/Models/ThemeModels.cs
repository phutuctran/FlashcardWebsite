using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YVFlashCard.Service.ServiceImpl.ThemeService.DTO;

namespace YVFlashCardWApp.Models
{
    class ThemeModels
    {
		public int themeId { get; set; }
		public string themeName { get; set; }
		public string mean { get; set; }
		public byte[] IllustrationImg { get; set; }

		public ThemeModels() { }
		public ThemeModels(ThemeDTO _theme)
		{
			themeId = _theme.themeId;
			themeName = _theme.themeName;
			mean = _theme.mean;
			IllustrationImg = _theme.IllustrationImg;
		}
	}
}
