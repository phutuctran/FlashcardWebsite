using DBModels.Models;
using Google.Api;
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
		public readonly int DEFAULT_COUNT = 100;
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
				var sql = "INSERT INTO Themes (ThemeName, Mean, IllustrationImg, Author) VALUES (@Col1, @Col2, @Col3, @Col4);";

				int row = await context.Database.ExecuteSqlRawAsync(sql, new SqlParameter("@Col1", theme.themeName), new SqlParameter("@Col2", theme.mean), new SqlParameter("@Col3", theme.IllustrationImg), new SqlParameter("@Col4", theme.author));
				//Console.WriteLine(row.ToString());
				if (row > 0)
				{
					return true;
				}
				throw new Exception("Không thể thêm theme mới!!!");

			}
			throw new Exception("lỗi khi thêm theme mới!!!");
		}


		public async Task<List<ThemeDTO>?> GetThemeByAdminAsync(int count = 0, string keySearch = "")
		{
			return await GetThemeByUserAsync("Admin", count, keySearch);

		}

		public async Task<List<ThemeDTO>?> GetThemeByUserAsync(string User, int count = 0, string keySearch = "")
		{
			count = count == 0 ? DEFAULT_COUNT : count;
			var dbs = new YVFlashCardContext();
			keySearch = string.IsNullOrEmpty(keySearch)? "" : keySearch.Trim();
			
			var themes = await dbs.Themes.Where(u => u.Author == User && (u.ThemeName.Contains(keySearch) || u.Mean.Contains(keySearch))).Take(count).ToListAsync();
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
