using DBModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YVFlashCard.Service.Interfaces;
using YVFlashCard.Service.Users;
using YVFlashCard.Service.Users.DTO;
using YVFlashCardWApp.Models;
using YVFlashCardWApp.Adapter.Interfaces;
using YVFlashCardWApp.Adapter;
using FontAwesome.Sharp;
using System.Windows.Input;
using YVFlashCardWApp.Views;

namespace YVFlashCardWApp.ViewModels
{
	class MainViewModel : ViewModelBase
	{
		private UserInfoModel _userInfoModel;
		private ViewModelBase _currentChildViewModel;
		private string _caption;
		private IconChar _icon;

		private IAccountService _accountService;
		private IUserInfoModelService _userInfoModelService;

		public UserInfoModel UserInfoModel
		{
			get => _userInfoModel;
			set
			{
				_userInfoModel = value;
				OnPropertyChanged(nameof(UserInfoModel));
			}
		}
		public IAccountService AccountService
		{
			get => _accountService;
			set
			{
				_accountService = value;
				OnPropertyChanged(nameof(_accountService));
			}
		}

		public ViewModelBase CurrentChildViewModel
		{
			get => _currentChildViewModel; set
			{
				_currentChildViewModel = value;
				OnPropertyChanged(nameof(CurrentChildViewModel));
			}
		}
		public string Caption
		{
			get => _caption; set
			{
				_caption = value;
				OnPropertyChanged(nameof(Caption));
			}
		}
		public IconChar Icon
		{
			get => _icon; set
			{
				_icon = value;
				OnPropertyChanged(nameof(Icon));
			}
		}

	public ICommand ShowHomeViewCommand { get; }
	public ICommand ShowStudyViewCommand { get; }

		public MainViewModel()
	{
		UserInfoModel = new UserInfoModel();
		_accountService = new AccountServiceImpl();

		ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
		ShowStudyViewCommand = new ViewModelCommand(ExecuteShowStudyViewCommand);
		ExecuteShowHomeViewCommand(null);

		GetCurrenUser();
	}

		private void ExecuteShowStudyViewCommand(object obj)
		{
			CurrentChildViewModel = new ChooseStudyViewModel();
			Caption = "Your home";
			Icon = IconChar.UserGroup;
		}

		private void ExecuteShowHomeViewCommand(object obj)
		{
			CurrentChildViewModel = new HomeViewModel();
			Caption = "Your home";
			Icon = IconChar.UserGroup;
		}

		private bool GetCurrenUser()
	{
		string currentUsername = Thread.CurrentPrincipal.Identity.Name;
		UserDTO userInfoDTO = Task.Run(() => _accountService.GetUserInfoByUsernameAsync(currentUsername)).Result;
		_userInfoModelService = new UserInfoModelServiceImpl(userInfoDTO);
		UserInfoModel = _userInfoModelService.GetUserInfoModel();
		return userInfoDTO != null;
	}
}
}
