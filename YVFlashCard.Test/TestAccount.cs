using DBModels.Models;
using Microsoft.AspNetCore.Authentication;
using NUnit.Framework;
using System.Linq;
using YVFlashCard.Service;

namespace YVFlashCard.Test
{
	[TestFixture]
	public class TestAccountDb
	{
		// IAuthenticationService authenticationService;

		public TestAccountDb()
		{
			//this.authenticationService = authenticationService;
		}

		[Test]
		public void Test01()
		{
			//Assert.AreEqual(1, 1);
		}

		[Test]
		public void TestAccounts()
		{
			var service = new AccountServiceImpl();
			Accounts user = service.AuthenticateAsync("admin", "123");
			Assert.IsTrue(user != null);
			Assert.AreEqual(user?.Role, "A");
		}
	}
}