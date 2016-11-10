using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ExampleCBHTTPUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	private string ServerAddress = "https://<Your Address>.azurewebsites.net/";
	private string PathString = "api/ping";

	private string ResponseData = "";
	private string RequestData = "";

	/*
	 * 	// Headers
	/*
		ZUMO-API-VERSION:2.0.0
		Accept:application/json
		Content-Type:application/json
	 *
	 */
	// @TODO
	private void HTTPRequestSend (){

	}
		
	private void HTTPRequestAuthSend(){
		
	}

	private IEnumerator  WaitForRequest(WWW www) {
		
	}

	public int scrollWidth = 530;
	public int scrollHeight = 600;

	private Vector2 scrollPosition = Vector2.zero;

	public void OnGUI(){
		
		scrollPosition = GUI.BeginScrollView(new Rect(0, 0, scrollWidth, scrollHeight), scrollPosition, new Rect(0, 0, 520, 600), true, true);

		GUILayout.BeginVertical ();
			GUILayout.BeginHorizontal ("box");
				GUILayout.Label("Server Address : ", GUILayout.Width(100));
				ServerAddress = GUILayout.TextField(ServerAddress, GUILayout.Width(400));
			GUILayout.EndHorizontal ();

			GUILayout.BeginHorizontal ("box");
				GUILayout.Label("Path : ", GUILayout.Width(100));
				PathString = GUILayout.TextField(PathString, GUILayout.Width(400));
			GUILayout.EndHorizontal ();

			GUILayout.BeginHorizontal ();
				if (GUILayout.Button ("Send", GUILayout.Width (80))) {
					HTTPRequestSend ();
				}
				if (GUILayout.Button ("Auth Send ", GUILayout.Width (80))) {
					HTTPRequestAuthSend ();
				}
			GUILayout.EndHorizontal ();

			GUILayout.Label ("");

			GUILayout.Label ("Request Data : ");
			RequestData = GUILayout.TextArea (RequestData, GUILayout.Width(520), GUILayout.Height(50));

			GUILayout.Label ("");
			GUILayout.Label ("Response Data : ");
			ResponseData = GUILayout.TextArea (ResponseData, GUILayout.Width(520), GUILayout.Height(300));
		GUILayout.EndVertical ();

		GUI.EndScrollView();
	}
}
