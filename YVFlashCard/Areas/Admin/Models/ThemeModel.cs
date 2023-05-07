using YVFlashCard.Service.ServiceImpl.ThemeService.DTO;

namespace YVFlashCard.Areas.Admin.Models
{
	public class ThemeModel : ThemeDTO
	{
		public ThemeModel() : base() { }
		public ThemeModel(ThemeDTO theme) : base(theme) { }
	}
}
