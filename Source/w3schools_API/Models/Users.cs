using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace w3schools_API.Models
{
    public class Users
    {
		public int? UserId { get; set; }
		public string UserName { get; set; }
		public int? RoleId { get; set; }
		public string PassWord { get; set; }
		public string Email { get; set; }
		public DateTime? DateCreated { get; set; }
		public DateTime? DateModified { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }

	}
}
