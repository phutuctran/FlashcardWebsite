using DBModels.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YVFlashCard.Service.Interfaces;
using YVFlashCard.Service.ServiceImpl.ThemeService.DTO;
using YVFlashCard.Service.Types;

namespace YVFlashCard.Service.ServiceImpl.ThemeService
{
	public class ThemeServiceImpl : IThemeService
	{
		public async Task<List<ThemeDTO>?> CheckExistsThemeByNameAsync(string themeName)
		{
			var dbs = new YVFlashCardContext();
			var themes = await dbs.Themes.Where(u => u.ThemeName == themeName).ToListAsync();
			List<ThemeDTO> result = new List<ThemeDTO>();	
			foreach(var theme in themes)
			{
				result.Add(new ThemeDTO(theme));
			}
			return result;
		}

		public async Task<bool> CreateNewThemeAsync(ThemeDTO theme)
		{
			using (var context = new YVFlashCardContext())
			{
				var sql = "CreateNewTheme @themeName, @mean, @img, @author, @role";

				int row = await context.Database.ExecuteSqlRawAsync(sql, new SqlParameter("@themeName", theme.themeName), new SqlParameter("@mean", theme.mean), new SqlParameter("@img", theme.IllustrationImg), new SqlParameter("@author", theme.author), new SqlParameter("@role", theme.role));
				//Console.WriteLine(row.ToString());
				if (row > 0)
				{
					return true;
				}
				return false;

			}
			throw new Exception("lỗi khi thêm theme mới!!!");
		}
		public async Task<bool> DeleteThemeAsync(ThemeDTO theme)
		{
			using (var context = new YVFlashCardContext())
			{
				var sql = "DeleteTheme @themeid";

				int row = await context.Database.ExecuteSqlRawAsync(sql, new SqlParameter("@themeid", theme.themeId));
				if (row > 0)
				{
					return true;
				}
				return false;

			}
			throw new Exception("Lỗi khi xóa theme mới!!!");
		}


		public async Task<List<ThemeDTO>?> GetThemeByAdminAsync(int count = 0, string keySearch = "")
		{
			return await GetThemeByUserAsync("A", count, keySearch);

		}

		public async Task<List<ThemeDTO>?> GetThemeByUserAsync(string role, int count = 0, string keySearch = "")
		{
			count = count == 0 ? SettingTypes.DEFAULT_COUNT : count;
			var dbs = new YVFlashCardContext();
			keySearch = string.IsNullOrEmpty(keySearch)? "" : keySearch.Trim();
			
			var themes = await dbs.Themes.Where(u => u.Role == role && (u.ThemeName.Contains(keySearch) || u.Mean.Contains(keySearch))).Take(count).ToListAsync();
			List<ThemeDTO> result = new List<ThemeDTO>();
			themes.ForEach(i =>  result.Add(new ThemeDTO(i)));
			return result;
		}

		public async Task UpdateThemeAsync(ThemeDTO theme)
		{

			var dbs = new YVFlashCardContext();
			Themes? _theme = await dbs.Themes.FirstOrDefaultAsync(u => u.ThemeId == theme.themeId);
			if (_theme == null)
			{
				throw new Exception("Không tìm thấy theme này!");
			}
			var sql = "UPDATE Themes set ThemeName = @Col1, Mean = @Col2, IllustrationImg = @Col3, Author = @Col4 where ThemeId = @Col5";

			int row = await dbs.Database.ExecuteSqlRawAsync(sql, new SqlParameter("@Col1", theme.themeName), new SqlParameter("@Col2", theme.mean), new SqlParameter("@Col3", new byte[] { 0, 0, 0}), new SqlParameter("@Col4", theme.author), new SqlParameter("@Col5", theme.themeId));
			//Console.WriteLine(row.ToString());
			if (row == 0)
			{
				throw new Exception("lỗi khi cập nhật thêm!!!");
			}
		}
	}
}
