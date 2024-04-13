using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_project
{
	internal class CreatorRepo : Repo
	{
		// private db connection
		private Creator creator;


		public CreatorRepo()
		{

		}
		public void addCreator(Creator creator)
		{

		}
		public void deleteCreator(Creator creator)
		{

		}
		public Creator getCreatorById(int creatorId)
		{
			return new Creator(creatorId,"","","","","");
		}
	}
}