using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YVFlashCard.Service.ServiceImpl.ThemeService.DTO;

namespace YVFlashCard.Service.Interfaces
{
    public interface IThemeService
	{
		Task<List<ThemeDTO>?> CheckExistsThemeByNameAsync(string themeName);
		Task<List<ThemeDTO>?> GetThemeByAdminAsync(int count, string keySearch);
		Task<List<ThemeDTO>?> GetThemeByUserAsync(string User, int count, string keySearch);
		Task UpdateThemeAsync(ThemeDTO theme);
		Task<bool> CreateNewThemeAsync(ThemeDTO theme);
	}
}
