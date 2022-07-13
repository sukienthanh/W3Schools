using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace w3schools_API.Models
{
	public class UserInfo
	{		
		public string UserName { get; set; }
		public string Role { get; set; }
		public string PassWord { get; set; }
		public string Email { get; set; }
		public string Token { get; set; }

		public UserInfo() { }
		public UserInfo(string  username ,string email, string role)
        {
			UserName = username;
			Email = email;
			Role = role;
        }
	}
}
