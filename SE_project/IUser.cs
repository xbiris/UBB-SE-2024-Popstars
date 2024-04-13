using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_project
{
	public interface IUser
	{
		public int id { get; set; }
		public string username { get; set; } 
		public string fullname { get; set; }
		public string email { get; set; }
	}
}
