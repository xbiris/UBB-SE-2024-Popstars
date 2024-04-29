using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_project.Services
{
	public class CreatorService : IService
	{
		private CreatorRepo creatorRepo;
		public CreatorService()
		{
			creatorRepo = new CreatorRepo();
		}

		public void AddCreator(string fullname, string username, string email, string country, string birthday, string socialMediaLink, string description, string profilePicPath, string hashedPass)
		{
			var creator = new Creator(fullname, username, email, country, birthday, socialMediaLink, description, profilePicPath);
			creatorRepo.AddCreator(creator, hashedPass);
		}
		public void DeleteCreator(int creatorId)
		{
			Creator creator = creatorRepo.GetCreatorById(creatorId);
			if (creator != null)
			{
				creatorRepo.DeleteCreator(creator);
			}
		}
		public int GetNoOfSavesPerCreator(int creatorId)
		{
			return creatorRepo.GetNoOfSavesPerCreator(creatorId);
		}
		public int GetNoSharesPerCreator(int creatorId)
		{
			return creatorRepo.GetNoOfSharesPerCreator(creatorId);
		}

		public int GetNoStreamsPerCreator(int creatorId)
		{
			return creatorRepo.GetNoOfStreamsPerCreator(creatorId);
		}

		public int GetNoPlaylists(int creatorId)
		{
			return creatorRepo.GetNoOfPlaylistsPerCreator(creatorId);
		}

		public Creator GetCreatorById(int creatorId)
		{
			return creatorRepo.GetCreatorById(creatorId);
		}

		public void UpdateCreator(int creatorId, string fullname, string username, string email, string country, string birthday, string socialMediaLink, string description, string profilePicPath)
		{
			var creator = new Creator(fullname, username, email, country, birthday, socialMediaLink, description, profilePicPath);
			creatorRepo.UpdateCreator(creatorId, creator);
		}
		public (string, string, string) GetCreatorInfoById(int creatorId)
		{
			Creator creator = creatorRepo.GetCreatorById(creatorId);
			return (creator.Fullname, creator.Description, creator.ProfilePicPath);
		}
	}
}
