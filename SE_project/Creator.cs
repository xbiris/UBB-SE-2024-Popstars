using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_project
{
	public class Creator : IUser
	{
		public int id { get; set; }
		public string username { get; set; }
		public string fullname { get; set; }
		public string email { get; set; }
		public string Country { get; set; }
		public string Birthday { get; set; }
		public string Socialmedialink { get; set; }
        public string Description { get; set; }
        public string ProfilePicPath { get; set; }

        public Creator(string username, string fullname, string email, string country, string birthday, string socialmedialink, string description, string profilePicPath)
		{
            if (username == null)
                throw new ArgumentNullException(nameof(username));
            if (fullname == null)
                throw new ArgumentNullException(nameof(fullname));
            if (email == null)
                throw new ArgumentNullException(nameof(email));
            if (country == null)
                throw new ArgumentNullException(nameof(country));
            if (birthday == null)
                throw new ArgumentNullException(nameof(birthday));
            if (socialmedialink == null)
                throw new ArgumentNullException(nameof(socialmedialink));
            if (description == null)
                throw new ArgumentNullException(nameof(description));
            if (profilePicPath == null)
                throw new ArgumentNullException(nameof(profilePicPath));

            this.username = username;
			this.fullname = fullname;
			this.email = email;
			this.Country = country;
			this.Birthday = birthday;
			this.Socialmedialink = socialmedialink;
			this.Description = description;
			this.ProfilePicPath = profilePicPath;
        }


	}
}
