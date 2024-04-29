using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_project
{
	public class Creator : IUser
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Fullname { get; set; }
		public string Email { get; set; }
		public string Country { get; set; }
		public string Birthday { get; set; }
		public string Socialmedialink { get; set; }
        public string Description { get; set; }
        public string ProfilePicPath { get; set; }

        public Creator(string username, string fullname, string email, string country, string birthday, string socialmedialink, string description, string profilePicPath)
		{
			this.Username = username;
			this.Fullname = fullname;
			this.Email = email;
			this.Country = country;
			this.Birthday = birthday;
			this.Socialmedialink = socialmedialink;
			this.Description = description;
			this.ProfilePicPath = profilePicPath;
        }
	}
}
