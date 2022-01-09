using System;

namespace Models
{
	[Serializable]
	public class User
	{
		public int id;

		public string name;

		public string username;

		public string email;

		public string phone;

		public string website;

		public override string ToString(){
			return UnityEngine.JsonUtility.ToJson (this, true);
		}
	}
}

