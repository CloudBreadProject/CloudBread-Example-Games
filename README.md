# CloudBread-Example-Games
본 레포는 CloudBread 와 유니티의 연동을 쉽게 따라 할 수 있도록 만들어진 예제 게임 레포입니다.
Flappy Bird 라는 매우 쉬운 러닝게임에 CloudBread 를 연동하는 방법에 대해 설명합니다.
이 레포의 master 브랜치를 클론 하신 후, 따라하시면 됩니다.

## 0. Flappy Bird 게임 만들기 소개

Flappy Bird 라는 게임은 매우 단순한 Running 게임 입니다.
![gmae screenshot](http://www.windowscentral.com/sites/wpcentral.com/files/styles/larger/public/field/image/2014/02/Flappy_Bird_Screen.jpg?itok=wrfghn6M)


원본 게임은 현재 앱 스토어에는 제공되지 않고 있지만 지속적으로 패러디 게임들이 개발되고 있습니다. 뿐만 아니라 개발 하기 매우 쉽기 때문에 처음 게임을 개발을 해보시는 분들에게 부담 없이 만들어 볼 수 있을 최적의 게임이라고 생각합니다.

실제 유니티를 사용하여 게임을 만드는 과정은 이 [블로그](https://dgkanatsios.com/2014/07/02/a-flappy-bird-clone-in-unity-source-code-included-3/)를 참고하시면, Unity 3D를 사용하여 개발을 진행할 수 있습니다. 실제 데모는 [이 곳](http://unitysamples.azurewebsites.net/flappybirdclone.html)에서 해 볼 수 있습니다.


CloudBread 를 사용하여 게임 만들기 는 다음과 같은 순서로 진행됩니다.

1. Flappy Bird 게임 만들기 준비과정
2. Facebook SDK 를 사용한 로그인 기능 구현
3. CloudBread SDK 설치
4. Azure 에서 제공하는 Facebook 인증 기능 사용하기
5. CloudBread 의 회원가입 API, 게임 정보 업데이트 API 랭킹 API 호출


## 1. Unity 에서 Flappy Bird 실행하기
![Unity Play Scene](https://raw.githubusercontent.com/wiki/CloudBreadProject/CloudBread/Resources/FlappyBirdGame/image001.png)
**Asset - Scenes - mainGame** 을 열면 위와 같이 게임을 실행 할 수 있습니다.


#### Unity 에 로그인 씬 만들기
**마우스 오른쪽 버튼 클릭 - Create - Scene** 을 클릭하여 loginGame 씬 생성

![Unity Play Scene](https://raw.githubusercontent.com/wiki/CloudBreadProject/CloudBread/Resources/FlappyBirdGame/image002.png)

**Assets – Scrips** 에 **FacebookLoginScript.cs** (C# Script) 생성하기

![Unity Play Scene](https://raw.githubusercontent.com/wiki/CloudBreadProject/CloudBread/Resources/FlappyBirdGame/image003.png)

loginGame 씬에서 **마우스 오른쪽 – UI – Button** 클릭 해서 버튼 만들기

![Unity ui button add](https://raw.githubusercontent.com/wiki/CloudBreadProject/CloudBread/Resources/FlappyBirdGame/image004.png)

**마우스 오른쪽 – Create Empty** 클릭해서 FacebookLoginManager라는 Gameobject 만들기

![Unity create empty](https://raw.githubusercontent.com/wiki/CloudBreadProject/CloudBread/Resources/FlappyBirdGame/image005.png)

아까 만든 FacebookLoginScript를 드래그 해서 FacebookLoginManager에 추가하기

![Unity inspector](https://raw.githubusercontent.com/wiki/CloudBreadProject/CloudBread/Resources/FlappyBirdGame/image006.png)

아래 순서대로 **새로 만든 버튼 클릭 – Inspector - On Click () - + 버튼** 클릭
None (Object)에 FacebookLoginManager 드래그해서 놓기
![Unity add button1](https://raw.githubusercontent.com/wiki/CloudBreadProject/CloudBread/Resources/FlappyBirdGame/image007.png) ![Unity add button2](https://raw.githubusercontent.com/wiki/CloudBreadProject/CloudBread/Resources/FlappyBirdGame/image008.png)


FacebookLoginScipt.cs 에 아래와 같이 FacebookLoginBtnClick() 메소드 추가
```c#
using UnityEngine;
using System.Collections;

public class FacebookLoginScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    public void FacebookLoginBtnClick()
    {

    }
}
```

**No Function – FacebookLoginScript – FacebookLoginBtnClicked()** 클릭
![register button event](https://raw.githubusercontent.com/wiki/CloudBreadProject/CloudBread/Resources/FlappyBirdGame/image009.png)

## 2. Facebook SDK 를 사용한 로그인 기능 구현
#### Facebook 앱 추가 및 Azure Mobile App 에 Facebook 등록하기 (생략)

1. Facebook에 앱 추가하기
2. Azure Mobile App 에 페이스북 앱 추가하기

아래 사이트에서 자세하게 볼 수 있습니다.
https://azure.microsoft.com/ko-kr/documentation/articles/mobile-services-how-to-register-facebook-authentication/

중요
Advanced 탭을 클릭하고, Valid OAuth redirect URIs에 아래URL 형식 입력한 다음 Save Changes를 클릭합니다.
https://[mobile_service].azure-mobile.net/login/facebook

#### Facebook SDK 를 이용한 로그인 구현

```
Facebook App ID : 207398879650397
```

3. SDK 다운로드 하기 (https://developers.facebook.com/docs/unity)
4. Unity 프로젝트에 SDK 추가하기 (위 사이트의 Getting Started 참고)
5. loginGame 에서 버튼 클릭했을 때, Facebook Permission 받아오도록 구현 (위 사이트의 Example 참고해서 FacebookLoginScript 구현)

```c#
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine.SceneManagement;


public class FacebookLoginScript : MonoBehaviour {

    // Awake function from Unity's MonoBehavior
    void Awake()
    {
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void LoginwithPermissions()
    {
        var perms = new List<string>() { "public_profile", "email", "user_friends" };
        FB.LogInWithReadPermissions(perms, AuthCallback);
    }

    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }

            FB.API("me?fields=name", HttpMethod.GET, (IGraphResult results) => {
            				var userName = (string)results.ResultDictionary["name"];
            				print(userName + "님 안녕하세요^^");
            				PlayerPrefs.SetString("nickName", userName);
            			});

        }
        else {
            Debug.Log("User cancelled login");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }

    public void FacebookLoginBtnClick()
    {
        if (!FB.IsLoggedIn)
            LoginwithPermissions();
    }
}
```

페이스북 SDK 를 사용하여 로그인 성공했을 때
![Facebook Login Success](https://raw.githubusercontent.com/wiki/CloudBreadProject/CloudBread/Resources/FlappyBirdGame/image010.png)


지금까지 페이스북 SDK 를 사용하여 User Access Token, User ID, User Name 을 받는 것을 진행하였습니다.
앞으로 이어질 내용에서는 Http Rest 통신을 사용하여 애저 인증을 사용하는 것과 CloudBread 서버를 사용하는 것에 대해 자세히 다루겠습니다.


### 데모 서버 페이스북 테스트 토큰
데모 서버를 사용 할 시, 개인 페이스북 아이디를 사용하지 말고 꼭 아래 토큰을 사용해주세요!
```
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
```

## 3. CloudBread SDK 설치
아래 문서를 참고하여 CloudBread SDK 설치하기
https://github.com/CloudBreadProject/CloudBread/wiki/How-to-use-Unity-SDK-kor

## 4. Azure 에서 제공하는 Facebook 인증 기능 사용하기
#### Facebook 에서 제공하는 AccessToken 을 CloudBread 등록하고, 사용자 데이터 가져오기
API 주소
```
https://cb2-auth-demo.azurewebsites.net/.auth/login/facebook
```

Post Data Json : 페이스북에서 발급받은 토큰을 넣음
```javascripts
{
  "access_token" : "<Facebook SDK를 통해 발급받은 토큰>"
}
```

Receive Data : Azure에서 Token과 UserID를 json 형식 제공
```javascripts
{
  "authenticationToken" : "<발급받은 Token>",
  "user" : {
    "userId" : "sid:<발급받은 sid>"
  }
}
```
* authenticationToken 을 호출 할 때마다 헤더에 `X-ZUMO-AUTH` 값으로 넣어야만 서버로부터 응답을 받을 수 있다.
* userId의 sid 를 게임에서 유일한 값 (`memberID`)로 사용

아래왁 같은 프로토콜 파일을 사용하여 API 호출 할 수 있음
```C#
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

	}
}
```

FacebookLoginScript.cs 파일에서 FacebookAuthentication 사용하기
```C#
private void AuthCallback(ILoginResult result)
{
    if (FB.IsLoggedIn)
    {
        // AccessToken class will have session details
        var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
        // Print current access token's User ID
        Debug.Log(aToken.UserId);
        // Print current access token's granted permissions
        foreach (string perm in aToken.Permissions)
        {
            Debug.Log(perm);
        }

        FB.API("me?fields=name", HttpMethod.GET, (IGraphResult results) => {
                var userName = (string)results.ResultDictionary["name"];
                print(userName + "님 안녕하세요^^");
                PlayerPrefs.SetString("nickName", userName);

                CloudBread.FacebookAuthentication.Post postData = new FacebookAuthentication.Post();
                postData.access_token = aToken.TokenString;
                CloudBread.FacebookAuthentication.Request(postData, (FacebookAuthentication.Receive obj) => {
                  print(obj.authenticationToken);
                  CloudBread.CBSetting.authToken = obj.authenticationToken;
                });
              });

    }
    else {
        Debug.Log("User cancelled login");
    }
}
```

## 5. CloudBread 의 회원가입 API, 게임 정보 업데이트 API 랭킹 API 호출


FacebookLoginScript.cs 파일에서 CBInsRegMember API 사용하기

```C#
private void AuthCallback(ILoginResult result)
{
    if (FB.IsLoggedIn)
    {
        // AccessToken class will have session details
        var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
        // Print current access token's User ID
        Debug.Log(aToken.UserId);
        // Print current access token's granted permissions
        foreach (string perm in aToken.Permissions)
        {
            Debug.Log(perm);
        }

        FB.API("me?fields=name", HttpMethod.GET, (IGraphResult results) => {
                var userName = (string)results.ResultDictionary["name"];
                print(userName + "님 안녕하세요^^");
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

    }
    else {
        Debug.Log("User cancelled login");
    }
}
```

Flappy.cs 파일에서 CBComUdtMemberGameInfoes API 호출하기
```C#
else if (GameStateManager.GameState == GameState.Dead)
{
    if (!isUpdatetoServer) {
        CloudBread.CBComUdtMemberGameInfoes.Request (
            new CloudBread.CBComUdtMemberGameInfoes.Post {
                Points = ScoreManagerScript.Score.ToString()
            },
            (CloudBread.CBComUdtMemberGameInfoes.Receive obj) => {
                print("[CBComUdtMemberGameInfoes Result] : " + obj.result);
            }
        );
        isUpdatetoServer = true;
    }
}

```
