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
using DBModels.Models;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Windows;
using System.Configuration;

namespace YVFlashCardWApp.ViewModels
{
	public class LoginViewModel : ViewModelBase
	{
		//Fields
		private string _username;
		private SecureString _password;
		private string _errorMessage;
		private bool _isViewVisible = true;

		private IAccountService _accountService;

		//Properties
		public string Username
		{
			get
			{
				return _username;
			}

			set
			{
				_username = value;
				OnPropertyChanged(nameof(Username));
			}
		}

		public SecureString Password
		{
			get
			{
				return _password;
			}

			set
			{
				_password = value;
				OnPropertyChanged(nameof(Password));
			}
		}

		public string ErrorMessage
		{
			get
			{
				return _errorMessage;
			}

			set
			{
				_errorMessage = value;
				OnPropertyChanged(nameof(ErrorMessage));
			}
		}

		public bool IsViewVisible
		{
			get
			{
				return _isViewVisible;
			}

			set
			{
				_isViewVisible = value;
				OnPropertyChanged(nameof(IsViewVisible));
			}
		}

		//-> Commands
		public ICommand LoginCommand { get; }
		public ICommand RecoverPasswordCommand { get; }
		public ICommand ShowPasswordCommand { get; }
		public ICommand RememberPasswordCommand { get; }

		//Constructor
		public LoginViewModel()
		{
			_accountService = new AccountServiceImpl();
			LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
			RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
		}

		private bool CanExecuteLoginCommand(object obj)
		{
			bool validData;
			if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
				Password == null || Password.Length < 3)
			{
				validData = false;
			}	
			else
			{
				validData = true;
			}
			

			return validData;
		}

		private void ExecuteLoginCommand(object obj)
		{
			var loginAcc = new NetworkCredential(Username, Password);
			var isValidUser = false;
			Accounts? account = Task.Run(() => _accountService.AuthenticateAsync(loginAcc.UserName, loginAcc.Password)).Result;
	
			isValidUser = !(account == null);
			if (isValidUser)
			{
				Thread.CurrentPrincipal = new GenericPrincipal(
					new GenericIdentity(Username), null);
				IsViewVisible = false;
			}
			else
			{
				ErrorMessage = "* Invalid username or password";
			}
		}

		private void ExecuteRecoverPassCommand(string username, string email)
		{
			throw new NotImplementedException();
		}
	}
}
