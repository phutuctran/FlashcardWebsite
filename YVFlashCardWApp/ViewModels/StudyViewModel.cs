using DBModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using YVFlashCard.Service.Interfaces;
using YVFlashCard.Service.Users;
using FontAwesome.Sharp;
using YVFlashCardWApp.Adapter.Interfaces;
using YVFlashCardWApp.Models;
using YVFlashCard.Service.Users.DTO;
using YVFlashCardWApp.Adapter;

namespace YVFlashCardWApp.ViewModels
{
	class StudyViewModel : ViewModelBase
	{

		//Constructor
		private UserInfoModel _userInfoModel;
		private int _selectedIndexGender;
		private string _errorMessage;
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
		public int SelectedIndexGender
		{
			get => _selectedIndexGender; set
			{
				_selectedIndexGender = value;
				OnPropertyChanged(nameof(SelectedIndexGender));
			}
		}

		public string ErrorMessage
		{
			get => _errorMessage; set
			{
				_errorMessage = value;
				OnPropertyChanged(nameof(ErrorMessage));
			}
		}

		public ICommand SaveInfoCommand { get; }


		public StudyViewModel()
		{
			_errorMessage = "hihi";
			_userInfoModel = new UserInfoModel();
			_accountService = new AccountServiceImpl();
			SaveInfoCommand = new ViewModelCommand(ExecuteSaveInfoCommand, CanExecuteSaveInfoCommand);
			GetCurrenUser();
		}

		private bool CanExecuteSaveInfoCommand(object obj)
		{
			return true;
		}

		private void ExecuteSaveInfoCommand(object obj)
		{
			throw new NotImplementedException();
		}

		private bool GetCurrenUser()
		{
			string currentUsername = Thread.CurrentPrincipal.Identity.Name;
			UserDTO userInfoDTO = Task.Run(() => _accountService.GetUserInfoByUsernameAsync(currentUsername)).Result;
			_userInfoModelService = new UserInfoModelServiceImpl(userInfoDTO);
			UserInfoModel = _userInfoModelService.GetUserInfoModel();
			if (userInfoDTO != null)
			{
				SelectedIndexGender = SelectGender(UserInfoModel.Sex);
			}
			return userInfoDTO != null;
		}

		private int SelectGender(string _gender)
		{
			switch (_gender)
			{
				case "Male":
					return 0;
				case "Female":
					return 1;
				default:
					return 2;
			}
			return 2;
		}
	}


}


