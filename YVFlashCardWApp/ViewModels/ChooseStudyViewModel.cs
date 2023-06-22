using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Mvvm.Contracts;
using YVFlashCard.Service.ServiceImpl.ThemeService;
using YVFlashCardWApp.Models;
using IThemeService = YVFlashCard.Service.Interfaces;

namespace YVFlashCardWApp.ViewModels
{
	class ChooseStudyViewModel : ViewModelBase
	{
		private ThemeModels theme;
		private IThemeService.IThemeService themeService;

		internal ThemeModels Theme
		{
			get => theme; set
			{
				theme = value;
				OnPropertyChanged(nameof(theme));
			}
		}

		public ChooseStudyViewModel()
		{
			themeService = new ThemeServiceImpl();
		}
	}
}
