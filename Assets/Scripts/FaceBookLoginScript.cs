using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Facebook.Unity;
using CloudBread;

public class FaceBookLoginScript : MonoBehaviour {

	// Awake function from Unity's MonoBehavior
	void Awake ()
	{
		if (!FB.IsInitialized) {
			// Initialize the Facebook SDK
			FB.Init(InitCallback, OnHideUnity);
		} else {
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
		}
	}

	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			// Signal an app activation App Event
			FB.ActivateApp();
			// Continue with Facebook SDK
			// ...

		} else {
			Debug.Log("Failed to Initialize the Facebook SDK");
		}
	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FacebookLoginButtonClick(){
		var perms = new List<string>(){"public_profile", "email", "user_friends"};
		FB.LogInWithReadPermissions(perms, AuthCallback);
	}

	private void AuthCallback (ILoginResult result) {
		if (FB.IsLoggedIn) {
			// AccessToken class will have session details
			var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
			// Print current access token's User ID
			Debug.Log(aToken.UserId);
			// Print current access token's granted permissions
			foreach (string perm in aToken.Permissions) {
				Debug.Log(perm);
			}

			FB.API("me?fields=name", HttpMethod.GET, (IGraphResult results) => {
				var userName = (string)results.ResultDictionary["name"];
				print((string)results.ResultDictionary["name"]);
				PlayerPrefs.SetString("nickName", userName);

				CloudBread.FacebookAuthentication.Post postData = new FacebookAuthentication.Post();
				postData.access_token = aToken.TokenString;
				CloudBread.FacebookAuthentication.Request(postData, (FacebookAuthentication.Receive obj) => {
					print(obj.authenticationToken);
					CloudBread.CBSetting.authToken = obj.authenticationToken;

					CBInsRegMember.Request(
						new CBInsRegMember.Post{
							MemberID_Members = aToken.UserId,
							EmailAddress_Members = aToken.UserId,
							Name1_Members = userName
						},
						(CBInsRegMember.Receive CBReceiveData) => {
							if (CBReceiveData.result == "2") {
								print("New User");
								SceneManager.LoadScene("mainGame");
							}
						},
						(string error) => {
							print("already Registered!");
							SceneManager.LoadScene("mainGame");
						}
					);
				});
			});

		} else {
			Debug.Log("User cancelled login");
		}
	}
}
