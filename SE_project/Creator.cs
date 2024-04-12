using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_project
{
	internal class Creator : IUser
	{
		public int id { get; set; }
		public string username { get; set; }
		public string fullname { get; set; }
		public string email { get; set; }

		public string country { get; set; }
		public string birthday { get; set; }

		public Creator(int id, string username, string fullname, string email, string country, string birthday)
		{
			this.id = id;
			this.username = username;
			this.fullname = fullname;
			this.email = email;
			this.country = country;
			this.birthday = birthday;
		}
	}
}
