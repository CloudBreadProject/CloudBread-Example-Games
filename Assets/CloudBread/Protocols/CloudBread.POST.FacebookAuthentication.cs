using UnityEngine;
using System;


namespace CloudBread
{
	public partial class FacebookAuthentication
	{
		//https://cb2-auth-demo.azurewebsites.net/.auth/login/facebook
		const string _url = ".auth/login/facebook";

		[Serializable]
		public struct Post
		{
			[SerializeField]
			public string access_token;
		}

		[Serializable]
		public struct Receive
		{
			[SerializeField]
			public string authenticationToken;

			[SerializeField]
			public User user;
		}

		[Serializable]
		public struct User
		{
			[SerializeField]
			public string userId;
		}

		static public void Request(Post postData_, System.Action<Receive> callback_, System.Action<string> errorCallback_ = null)
		{
			CloudBread.Request(CloudBread.MakeFullUrl(_url), JsonUtility.ToJson(postData_), callback_, errorCallback_);
		}

		static public void UpdateAuthTokenCallback(Receive data){
			
		}
	}
}