using System;

namespace Models
{
	[Serializable]
	public class Post
	{
		public int id;

		public int userId;

		public string title;

		public string body;

		public override string ToString(){
			return UnityEngine.JsonUtility.ToJson (this, true);
		}
	}
}

