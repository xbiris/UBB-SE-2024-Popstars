using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_project.Services
{
	public class CreatorService : IService
	{
		private CreatorRepo _creatorRepo;

		public CreatorService()
		{
			_creatorRepo = new CreatorRepo();
		}

		public void AddCreator(string fullname, string username, string email, string country, string birthday, string socialMediaLink, string description, string profilePicPath, string hashedPass)
		{
			var creator = new Creator(fullname, username, email, country, birthday, socialMediaLink, description, profilePicPath);
			_creatorRepo.AddCreator(creator, hashedPass);
		}

		public void DeleteCreator(int creatorId)
		{
			Creator creator = _creatorRepo.GetCreatorById(creatorId);
			if (creator != null)
			{
				_creatorRepo.DeleteCreator(creator);
			}
		}

		public Creator GetCreatorById(int creatorId)
		{
			return _creatorRepo.GetCreatorById(creatorId);
		}
	}

}
